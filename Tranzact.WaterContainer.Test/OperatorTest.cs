

using Tranzact.WaterContainer.App.Operators;
using Tranzact.WaterContainer.App.Dto;
using Moq;
using Tranzact.WaterContainer.App.Responses;
using Tranzact.WaterContainer.App.Shared.BussinessExceptions;
using NUnit.Framework;

namespace Tranzact.WaterContainer.Test
{
    public class OperatorTest
    {

        private Mock<IWaterContainerOperator> waterContainerOperator;

        [SetUp]
        public void Setup()
        {
            this.waterContainerOperator = new Mock<IWaterContainerOperator>();
            this.waterContainerOperator.Setup(p => p.ResultWaterContainer(It.IsAny<CoordinateDTO>())).Returns((CoordinateDTO dto) =>
            {
                var response = new WaterContainerResponse();
                if (dto.CoordinateY.Length < 2)
                {
                    throw new WaterContainerException("Coordinates not found");
                }
                else
                {
                    int lenght = dto.CoordinateY.Length;
                    int output = 0;
                    for (int i = 0; i < lenght; i++)
                    {
                        for (int j = lenght - 1; j > i; j--)
                        {
                            int baser = (j - i);
                            int height = (dto.CoordinateY[i] < dto.CoordinateY[j]) ? dto.CoordinateY[i] : dto.CoordinateY[j];
                            int area = baser * height;
                            output = (area > output) ? area : output;
                        }
                    }
                    response.Result = output;
                    return response;
                }
            });
        }

        [Test]
        public void return_error_if_dont_have_coordinates()
        {
            CoordinateDTO request = new CoordinateDTO();
            request.CoordinateY = new int[] { 1 };
            Assert.Throws<WaterContainerException>(
            () =>
            {
                waterContainerOperator.Object.ResultWaterContainer(request);
            });
        }


        [Test]
        public void return_correct_value_with_result_one()
        {
            CoordinateDTO request = new CoordinateDTO();
            request.CoordinateY = new int[] { 1, 1 };
            int expected = 1;
            int result = waterContainerOperator.Object.ResultWaterContainer(request).Result;
            Assert.AreEqual(expected, result);
        }
    }
}