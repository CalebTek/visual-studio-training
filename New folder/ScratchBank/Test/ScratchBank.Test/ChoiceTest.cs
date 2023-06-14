using ScratchBank;
using System.ComponentModel.DataAnnotations;

namespace ScratchBank.Test
{
    public class ChoiceTest
    {
        [Fact]
        public void Choice_ValidInput()
        {
            // Arrange

            // Act
            var expect = true;
            var actual = Validate.Choice("1");

            // Assert
            Assert.Equal(expect, actual);
        }
    }
}