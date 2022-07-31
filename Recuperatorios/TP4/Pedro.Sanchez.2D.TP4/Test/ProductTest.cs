using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.IO;
using System;

namespace Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void Product_AddProduct()
        {
            //Arrange
            Product.ProducType type = Product.ProducType.Madera;
            string description = "Prueba de Alta de Producto de Test Unitario";
            float price = 150;
            int quantity = 30;

            //Act
            Product product = new Product(type, description, price, quantity);

            //Assert
            Assert.IsNotNull(product);
        }
    }
}
