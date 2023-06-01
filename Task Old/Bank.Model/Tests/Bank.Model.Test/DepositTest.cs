using Bank.Model.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Bank.Model.Test
{
    [TestClass]
    public class DepositTest
    {
        [TestMethod]
        public void depositMethod1()
        {
            Deposit deposit = new Deposit()
            {
                TargetAccount = 1,
                Amount = 10000,
            };

            //-- Act
            var expected = deposit.Balance + deposit.Amount;
            var actual = deposit.DepositAmount(deposit.Amount);

            //-- Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
