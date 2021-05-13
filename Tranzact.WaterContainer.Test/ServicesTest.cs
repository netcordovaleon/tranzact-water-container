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
        public void get_lenght_in_array_without_values() {
            var request = new int[] {};
            var expected = 0;
            var result = waterContainerServices.Object.getLength(request);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void get_lenght_in_array_with_values() {
            var request = new int[] { 1, 2, 3, 6 };
            var expected = 4;
            var result = waterContainerServices.Object.getLength(request);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void get_base_by_height()
        {
            var baseRequest = 10;
            var heightRequest = 20;
            var expected = 200;
            var result = waterContainerServices.Object.calculateArea(baseRequest, heightRequest);
            Assert.AreEqual(expected, result);
        }

    }
}
