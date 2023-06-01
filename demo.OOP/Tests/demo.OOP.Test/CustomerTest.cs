using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace demo.OOP.Test
{
    [TestClass]
    public class CustomerTest
    {
        [TestMethod]
        public void FullNameTestValid()
        {
            //-- Arrange
            Customer customer = new Customer
            {
                FirstName = "Bilbo",
                LastName = "Baggins"
            };

            string expected = "Baggins, Bilbo";

            //-- Act
            string actual = customer.FullName;

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FullNameLastNameEmpty()
        {
            //-- Arrange
            Customer customer = new Customer { FirstName = "Bilbo", LastName = "" };

            bool expected = false;

            //-- Act
            bool actual = customer.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StaticTest()
        {
            //-- Arrange
            var c1 = new Customer { FirstName = "Bilbo" };
            Customer.InstanceCount++;

            var c2 = new Customer { FirstName = "Frodo" };
            Customer.InstanceCount++;

            var c3 = new Customer { FirstName = "Rosie" };
            Customer.InstanceCount++;


            //-- Act

            //-- Assert
            Assert.AreEqual(3, Customer.InstanceCount);
        }

        [TestMethod]
        public void ValidateValid()
        {
            //-- Arrange
            var customer = new Customer { LastName = "Baggins", EmailAddress = "fbaggins@hobbiton.me", PhoneNumber = "1-345-874-9883" };

            var expected = true;

            //-- Act
            var actual = customer.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingPhoneNumber()
        {
            //-- Arrange
            var customer = new Customer { LastName = "Baggins", EmailAddress = "fbaggins@hobbiton.me" };

            var expected = false;

            //-- Act
            var actual = customer.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ValidateMissingLastName()
        {
            //-- Arrange
            var customer = new Customer { LastName = " ", EmailAddress = "fbaggins@hobbiton.me" };

            var expected = false;

            //-- Act
            var actual = customer.Validate();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
