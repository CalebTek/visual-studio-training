using Bank.Model.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bank.Model.Test
{
    [TestClass]
    public class WithdrawTest
    {
        [TestMethod]
        public void WithdrawalMethod()
        {
            // Arrange
            Registration customer = new Registration()
            {

            };
            Withdraw withdraw = new Withdraw()
            {
                SourceAccount = 0,
                Amount = 5000
            };

            //-- Act
            var expected = withdraw.Balance - withdraw.Amount;
            var actual = withdraw.Withdarawal(5000, customer);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
