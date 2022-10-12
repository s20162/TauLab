using System;

namespace BankAccountNS
{
    /// <summary>
    /// Bank account demo class.
    /// </summary>
    public class BankAccount
    {
        private readonly string m_customerName;
        private double m_balance;
        private double m_limit;
        public const string DebitAmountExceedsBalanceMessage = "Debit amount exceeds balance";
        public const string DebitAmountLessThanZeroMessage = "Debit amount is less than zero";
        public const string CreditAmountLessThanZeroMessage = "Credit amount is less than zero";
        public const string CreditAmountExceedsBalanceCreditLimitMessage = "Credit amount exceeds balance credit limit";
        private BankAccount() { }

        public BankAccount(string customerName, double balance)
        {
            m_customerName = customerName;
            m_balance = balance;
            m_limit = balance * 1.5;
        }

        public string CustomerName
        {
            get { return m_customerName; }
        }

        public double Balance
        {
            get { return m_balance; }
        }

        public void Debit(double amount)
        {
            if (amount > m_balance)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountExceedsBalanceMessage);
            }

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, DebitAmountLessThanZeroMessage);
            }

            m_balance -= amount; // intentionally incorrect code
        }

        public void Credit(double amount)
        {
            if (amount < 0 )
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, CreditAmountLessThanZeroMessage);
            }
            
            if (amount > m_limit)
            {
                throw new System.ArgumentOutOfRangeException("amount", amount, CreditAmountExceedsBalanceCreditLimitMessage);
            }

            m_balance -= amount;
        }

        public static void Main()
        {
            BankAccount ba = new BankAccount("Adam Lichy", 15);

            ba.Credit(5);
            ba.Debit(7);
            Console.WriteLine("Current balance is ${0}", ba.Balance);
        }
    }
}