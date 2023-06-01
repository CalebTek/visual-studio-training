using Bank.Model.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bank.Model.Test
{
    [TestClass]
    public class RegistrationTest
    {
        [TestMethod]
        public void FullNameTest()
        {
            //-- Arrange
            Registration customer1 = new Registration()
            {
                FirstName = "Chris",
                LastName = "Hemsworth",
                OtherName = "Thor"
            };

            //-- Act
            var expect = "Hemsworth Chris Thor";
            var acutal = customer1.FullName;
            
            //-- Assert
            Assert.AreEqual(expect, acutal);
        }

        [TestMethod]
        public void FullNameWithNoOtherName()
        {
            //-- Arrange
            Registration customer1 = new Registration()
            {
                FirstName = "Chris",
                LastName = "Hemsworth"
            };

            //-- Act
            var expect = "Hemsworth Chris";
            var acutal = customer1.FullName;

            //-- Assert
            Assert.AreEqual(expect, acutal);
        }

        [TestMethod]
        public void ValidateTest()
        {
            //-- Arrange
            
            Registration customer1 = new Registration()
            {
                FirstName = "Chris",
                LastName = "Hemsworth",
                OtherName = "Thor",
                EmailAddress = "chrishems@avenger.com",
                Password = "ChrisThor12!"
            };

            //-- Act
            //var expected = true;
            //var actual = customer1.Validate(customer1);

            //-- Assert
            //Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void ValidateWrongEmail()
        {
            //-- Arrange

            Registration customer1 = new Registration()
            {
                FirstName = "Chris",
                LastName = "Hemsworth",
                OtherName = "Thor",
                EmailAddress = "chrishems.com",
                Password = "ChrisThor12!"
            };

            //-- Act
            //var expected = false;
            //var actual = customer1.Validate(customer1);

            //-- Assert
            //Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void CreateAccout()
        {
            Registration registration = new Registration()
            {
                FirstName = "Chris",
                LastName = "Hemsworth",
                OtherName = "Thor",
                EmailAddress = "chrishems@avenger.com",
                Password = "ChrisThor12!",
                AccountType = 1
            };

            // Act
            //var expect = "0";
            //var actual = registration.CreateAccount(registration).Substring(0,1);

            // Assert
            //Assert.AreEqual(expect, actual);
        }
    }
}
