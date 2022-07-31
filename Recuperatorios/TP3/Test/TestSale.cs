using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Entidades;
using System.Collections.Generic;

namespace Test
{
    [TestClass]
    public class TestSale
    {
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void Sale_AddSealException()
        {
            //Arrange
            float price = 150;
            List<string> list = null;

            //Act
            Sale sale = new Sale(price, list);

            //Assert
            Assert.IsTrue(true);
        }
    }
}
