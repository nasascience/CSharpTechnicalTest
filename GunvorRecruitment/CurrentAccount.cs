using System;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Linq;

namespace GunvorRecruitment
{
    public class CurrentAccount
    {
        public decimal Balance { get; set; }

        public int OverDraft { get; set; }

        public string PersonName { get; set; }
        public List<Transaction> TransactionHistory { get; set; }
        public void Deposit(decimal amount)
        {
            Balance += amount;

            AddTransaction(amount,true);
        }

        public virtual void Withdraw(decimal amount)
        {
            Balance -= amount;
            AddTransaction(amount, false);
        }

        public void AddTransaction(decimal amount, bool isDeposit)
        {
            TransactionHistory.Add(new Transaction
            {
                Withdrawal = !isDeposit ? amount : 0,
                Deposit = isDeposit? amount:0,
                CurrentBalance = Balance,
                Date = DateTime.Now,
                IsDeposit = isDeposit
            });
        }

        public List<Transaction> GetStatements()
        {
            return TransactionHistory.OrderByDescending(x => x.Date).ToList();
        }
    }
}
