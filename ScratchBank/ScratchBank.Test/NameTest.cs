using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ScratchBank.Test
{
    
    public class NameTest
    {
        [Theory]
        [InlineData("John", true)]
        [InlineData("john", false)]
        [InlineData("john1", false)]
        [InlineData("1234", false)]
        [InlineData("John !", false)]
        [InlineData("JJohn", false)]
        public void NameTest_ValidInput(string input, bool expected) 
        {
            var actual = Validate.Input(input, @"^[A-Z][a-z]+$");
            Assert.Equal(expected, actual);
        }
    }
}
