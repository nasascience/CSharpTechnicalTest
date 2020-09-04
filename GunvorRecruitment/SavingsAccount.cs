using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorRecruitment
{
    public class SavingsAccount : CurrentAccount
    {
        public override void Withdraw(decimal amount)
        {
            if (WasWithdrawnThisMonth())
                 throw new Exception("is not possible to withdraw money more than once a month.");

            if ((amount - Balance) >= 0)
                throw new Exception("Savings Account may not have an overdraft.");

            Balance -= amount;
            AddTransaction(amount, false);
        }

        private bool WasWithdrawnThisMonth()
        {
            return TransactionHistory.Any(x => !x.IsDeposit && x.Date.Month == DateTime.Today.Month);
        }

        private void AddYearInterest()
        {
            var yearInterest = 0.02m * Balance;
            Balance += yearInterest;
        }
        private decimal CalculateBalanceInYears(int years)
        {
            var yearBalance = Balance;
            for(var i = 0; i < years; i++)
            {
                var yearInterest = 0.02m * yearBalance;
                yearBalance += yearInterest;
            }
            return yearBalance;
        }
    }
}
