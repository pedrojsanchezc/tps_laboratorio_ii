using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.IO;
using System;

namespace Test
{
    [TestClass]
    public class FileTest
    {
        [TestMethod]
        public void FileTest_WriteJson()
        {
            //Arrange
            string fileName = "FileTest";
            string saveData = "Prueba de Guardado de Test Unitario para File.cs";

            //Act
            File<string>.WriteJson(fileName, saveData);

            //Assert
            Assert.IsTrue(File.Exists(AppDomain.CurrentDomain.BaseDirectory + fileName + ".json"));
        }
    }
}
