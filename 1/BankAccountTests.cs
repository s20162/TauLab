using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests

    {
        BankAccount account;

        [TestInitialize]
        public void setup()
        {
            account = new BankAccount("Adam Lichy", 20);
        }
        [TestCleanup]
        public void testClean()
        {
            account = null;
        }

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange            
            double debitAmount = 5;
            double expected = 15;
            // Act
            account.Debit(debitAmount);
            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double debitAmount = -20.0;

            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {

                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            double debitAmount = 30.0;

            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        [TestMethod]
        public void Credit_LessThanBalance_UpdatesBalance()
        {
            double creditAmount = 10;
            double expected = 10;

            account.Credit(creditAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }
        [TestMethod]
        public void Credit_NotOverLimit_UpdatesBalance()
        {
            double creditAmount = 25;
            double expected = -5;

            account.Credit(creditAmount);

            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }
        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            double creditAmount = -20.0;
            
            try
            {
                account.Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {              
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Credit_WhenAmountIsMoreThanBalanceLimit_ShouldThrowArgumentOutOfRange()
        {
            double creditAmount = 50;
            
            try
            {
                account.Credit(creditAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
               
                StringAssert.Contains(e.Message, BankAccount.CreditAmountExceedsBalanceCreditLimitMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }

}