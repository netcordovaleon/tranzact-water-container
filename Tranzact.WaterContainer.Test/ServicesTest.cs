using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Tranzact.WaterContainer.App.Services;

namespace Tranzact.WaterContainer.Test
{

    public class ServicesTest
    {

        private Mock<IWaterContainerServices> waterContainerServices;

        [SetUp]
        public void Setup()
        {
            this.waterContainerServices = new Mock<IWaterContainerServices>();

            this.waterContainerServices.Setup(p => p.getLength(It.IsAny<int[]>())).Returns((int[] len) => len.Length);

            this.waterContainerServices.Setup(p => p.calculateArea(It.IsAny<int>(), It.IsAny<int>())).Returns((int baser, int height) => baser * height);
        }

        [Test]
        [TestCase(0, new int[] { })]
        [TestCase(2, new int[] { 1, 1 })]
        [TestCase(5, new int[] { 7, 9, 8, 5, 2 })]

        public void get_lenght_in_array_without_values(int expected, int[] arg) {
            var result = waterContainerServices.Object.getLength(arg);
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(200, 10, 20)]
        [TestCase(50, 10, 5)]
        [TestCase(6, 3, 2)]
        public void get_base_by_height(int expected, int baser, int height)
        {
            var result = waterContainerServices.Object.calculateArea(baser, height);
            Assert.AreEqual(expected, result);
        }

    }
}
