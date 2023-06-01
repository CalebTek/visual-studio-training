using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using demo.OOP;
using System.Collections.Generic;

namespace demo.OOP.Test
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void RetrieveValid()
        {
            //-- Arrange
            var customerRepo = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins"
            };

            //-- Act

            var actual = customerRepo.Retrieve(1);

            //-- Assert
            //Assert.AreEqual(expected, actual); // This will fail because we have two different object
            Assert.AreEqual(expected.FullName, actual.FullName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.CustomerID, actual.CustomerID);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);

        }

        [TestMethod]
        public void RetrieveWithAddress()
        {
            //-- Arrange
            var customerRepo = new CustomerRepository();
            var expected = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                AddressList = new List<Address>()

                {
                    new Address()
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag End",
                        StreetLine2 = "Bagshot row",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "144"
                    },
                    new Address()
                    {
                        AddressType = 2,
                        StreetLine1 = "Green Dragon",
                        City = "Bywater",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "146"
                    }
                }
            };

            //-- Act
            var actual = customerRepo.Retrieve(1);

            //-- Assert
            Assert.AreEqual (expected.FirstName, actual.FirstName);
            Assert.AreEqual(expected.LastName, actual.LastName);
            Assert.AreEqual(expected.EmailAddress, actual.EmailAddress);
            Assert.AreEqual(expected.CustomerID, actual.CustomerID);

            Assert.AreEqual(expected.AddressList[0].AddressType, actual.AddressList[0].AddressType);
            Assert.AreEqual(expected.AddressList[0].StreetLine1, actual.AddressList[0].StreetLine1);
            Assert.AreEqual(expected.AddressList[0].City, actual.AddressList[0].City);
            Assert.AreEqual(expected.AddressList[0].State, actual.AddressList[0].State);
            Assert.AreEqual(expected.AddressList[0].Country, actual.AddressList[0].Country);
            Assert.AreEqual(expected.AddressList[0].PostalCode, actual.AddressList[0].PostalCode);

        }

        [TestMethod]
        public void SaveTestValid()
        {
            //-- Arrange
            var customerRepo = new CustomerRepository();
            var customerUpdate = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                LastName = "Baggins",
                HasChanges = false,
                AddressList = new List<Address>()

                {
                    new Address()
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag End",
                        StreetLine2 = "Bagshot row",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "145",
                        HasChanges = true
                    },
                    new Address()
                    {
                        AddressType = 2,
                        StreetLine1 = "Green Dragon",
                        City = "Bywater",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "146",
                        HasChanges = false
                    }
                }
            };

            //-- Act
            var actual = customerRepo.Save(customerUpdate);

            //-- Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void SaveTestMissingLastName()
        {
            //-- Arrange
            var customerRepo = new CustomerRepository();
            var customerUpdate = new Customer(1)
            {
                EmailAddress = "fbaggins@hobbiton.me",
                FirstName = "Frodo",
                //LastName = "Baggins",
                HasChanges = true,
                AddressList = new List<Address>()

                {
                    new Address()
                    {
                        AddressType = 1,
                        StreetLine1 = "Bag End",
                        StreetLine2 = "Bagshot row",
                        City = "Hobbiton",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "145",
                        HasChanges = true
                    },
                    new Address()
                    {
                        AddressType = 2,
                        StreetLine1 = "Green Dragon",
                        City = "Bywater",
                        State = "Shire",
                        Country = "Middle Earth",
                        PostalCode = "146",
                        HasChanges = false
                    }
                }
            };

            //-- Act
            var actual = customerRepo.Save(customerUpdate);

            //-- Assert
            Assert.AreEqual(false, actual);
        }

    }
}
    
