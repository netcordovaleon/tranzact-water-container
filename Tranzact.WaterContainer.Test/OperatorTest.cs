

using Tranzact.WaterContainer.App.Operators;
using Tranzact.WaterContainer.App.Dto;
using Moq;
using Tranzact.WaterContainer.App.Responses;
using Tranzact.WaterContainer.App.Shared.BussinessExceptions;
using NUnit.Framework;
using System;
namespace Tranzact.WaterContainer.Test
{
    public class OperatorTest
    {

        private Mock<IWaterContainerOperator> waterContainerOperator;


        private Func<CoordinateDTO, WaterContainerResponse> operationWaterContainer = (coordinate) =>
        {
            var response = new WaterContainerResponse();
            int lenght = coordinate.CoordinateY.Length;
            int output = 0;
            for (int i = 0; i < lenght; i++)
            {
                for (int j = lenght - 1; j > i; j--)
                {
                    int baser = (j - i);
                    int height = (coordinate.CoordinateY[i] < coordinate.CoordinateY[j]) ? coordinate.CoordinateY[i] : coordinate.CoordinateY[j];
                    int area = baser * height;
                    output = (area > output) ? area : output;
                }
            }
            response.Result = output;
            return response;
        };


        [SetUp]
        public void Setup()
        {
            this.waterContainerOperator = new Mock<IWaterContainerOperator>();

            this.waterContainerOperator.Setup(p => p.ResultWaterContainer(It.IsAny<CoordinateDTO>())).Returns(operationWaterContainer);

            this.waterContainerOperator.Setup(p => p.ResultWaterContainer(It.Is<CoordinateDTO>(c => c.CoordinateY.Length < 2)))
                .Throws(new WaterContainerException("Coordinates not found"));
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
        [TestCase(new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 }, ExpectedResult = 49)]
        [TestCase(new int[] { 1, 1 }, ExpectedResult = 1)]
        [TestCase(new int[] { 1, 2, 1 }, ExpectedResult = 2)]
        public int return_response_correct_with_coordinates(int[] arg)
        {
            CoordinateDTO request = new CoordinateDTO();
            request.CoordinateY = arg;
            int result = waterContainerOperator.Object.ResultWaterContainer(request).Result;
            return result;
        }
    }
}