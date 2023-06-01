using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace demo.OOP.Test
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //-- Arrange
            var productRepo = new ProductRepository();
            var expected = new Product(2)
            {
                ProductName = "Sunflowers",
                ProductDescription = "Assorted size set of 4 Bright Yellow Mini Sunflowers",
                CurrentPrice = 15.96M
            };

            //-- Act

            var actual = productRepo.Retrieve(2);

            //-- Assert
            //Assert.AreEqual(expected, actual); // This will fail because we have two different object
            Assert.AreEqual(expected.ProductName, actual.ProductName);
            Assert.AreEqual(expected.ProductDescription, actual.ProductDescription);
            Assert.AreEqual(expected.CurrentPrice, actual.CurrentPrice);

        }

        [TestMethod]
        public void SaveTestValid()
        {
            //-- Arrange
            var productRepo = new ProductRepository();
            var updatedProduct = new Product(2)
            {
                ProductName = "Sunflowers",
                ProductDescription = "Assorted size set of 4 Bright Yellow Mini Sunflowers",
                CurrentPrice = 18M,
                HasChanges = true,
            };

            //-- Act
            var actual = productRepo.Save(updatedProduct);

            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void SaveTestMissingPrice()
        {
            //-- Arrange
            var productRepo = new ProductRepository();
            var updatedProduct = new Product(2)
            {
                ProductName = "Sunflowers",
                ProductDescription = "Assorted size set of 4 Bright Yellow Mini Sunflowers",
                CurrentPrice = null,
                HasChanges = true,
            };

            //-- Act
            var actual = productRepo.Save(updatedProduct);

            //-- Assert
            Assert.AreEqual(false, actual);
        }
    }
}
