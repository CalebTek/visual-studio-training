using System;

namespace ScratchBank
{
    public static class Validate
    {
        // Choice
        public static bool Choice(string input)
        {
            
            if (string.IsNullOrWhiteSpace(input))
            {
                return false;
            }

            return int.TryParse(input, out _);
        }
        // Amount
        // Email
        // Password
        // Name
        // AccountNumber
    }
}
