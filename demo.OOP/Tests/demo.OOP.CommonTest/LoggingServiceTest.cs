using demo.OOP.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Runtime.Remoting;
using demo.OOP;

namespace demo.OOP.CommonTest
{
    [TestClass]
    public class LoggingServiceTest
    {
        [TestMethod]
        public void WriteToFileTest()
        {
            //-- Arrange
            var changedItems = new List<ILoggable>();

            var customer = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = null
            };
            changedItems.Add(customer);

            var product = new Product(2)
            {
                ProductName = "Rake",
                ProductDescription = "Garden Rake with Steel Head",
                CurrentPrice = 6M
            };
            changedItems.Add(@product);

            //-- Act 
            LoggingService.WriteToFile(changedItems);

            var expected = new List<string>
            {
                "Baggins, Frodo Email: fbaggins @hobbiton.me Status: Active",
                "Rake Email: Garden Rake with Steel Head Status: Active"
            };

            //-- Assert
            //Assert.AreEqual(expected, changedItems);
        }
    }
}
