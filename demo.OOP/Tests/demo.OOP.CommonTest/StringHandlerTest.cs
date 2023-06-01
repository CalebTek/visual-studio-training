using demo.OOP.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace demo.OOP.CommonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesTestValid()
        {
            //-- Arrange
            var source = "SonicScrewdriver";
            var expected = "Sonic Screwdriver";
            //var handler = new StringHandler();

            //-- Act
            //var actual = StringHandler.InsertSpaces(source);
            var actual = source.InsertSpaces();

            //-- Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void InsertSpacesTestWithExistingSpace()
        {
            //-- Arrange
            var source = "Sonic Screwdriver";
            var expected = "Sonic Screwdriver";
            //var handler = new StringHandler();

            //-- Act
            //var actual = StringHandler.InsertSpaces(source);
            var actual = source.InsertSpaces();

            //-- Assert
            Assert.AreEqual(expected, actual);

        }
    }
}
