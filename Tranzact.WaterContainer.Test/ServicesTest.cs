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
        }


        [Test]
        public void get_lenght_cero() {
            var len = new int[] {};
            waterContainerServices.Setup(p => p.getLength(It.IsAny<int[]>())).Returns(() => {
                return len.Length;
            });
            var result = waterContainerServices.Object.getLength(len);
            var expected = 0;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void get_lenght_in_array() {
            var len = new int[] { 1, 2, 3, 6 };
            waterContainerServices.Setup(p => p.getLength(It.IsAny<int[]>())).Returns(() => {
                return len.Length;
            });
            var result = waterContainerServices.Object.getLength(len);
            var expected = 4;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void get_base_by_height()
        {
            var baser = 10;
            var height = 20;
            waterContainerServices.Setup(p => p.calculateArea(baser, height)).Returns(() => {
                return baser * height;
            });
            var result = waterContainerServices.Object.calculateArea(baser, height);
            var expected = 200;
            Assert.AreEqual(expected, result);
        }

    }
}
