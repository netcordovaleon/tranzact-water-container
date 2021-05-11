

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
        }

        [Test]
        public void return_error_if_dont_have_coordinates()
        {
            CoordinateDTO dto = new CoordinateDTO();
            dto.CoordinateY = new int[] { 1 };
            waterContainerOperator.Setup(p => p.ResultWaterContainer(It.IsAny<CoordinateDTO>())).Returns(() =>
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

            Assert.Throws<WaterContainerException>(
            () =>
            {
                waterContainerOperator.Object.ResultWaterContainer(dto);
            });
        }


        [Test]
        public void return_correct_value_with_result_one()
        {
            CoordinateDTO dto = new CoordinateDTO();
            dto.CoordinateY = new int[] { 1, 1 };
            waterContainerOperator.Setup(p => p.ResultWaterContainer(It.IsAny<CoordinateDTO>())).Returns(() =>
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
            int result = waterContainerOperator.Object.ResultWaterContainer(dto).Result;
            int expected = 1;
            Assert.AreEqual(expected, result);
        }
    }
}