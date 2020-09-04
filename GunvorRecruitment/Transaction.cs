using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GunvorRecruitment
{
    public class Transaction
    {
        public decimal Withdrawal { get; set; }
        public decimal Deposit { get; set; }
        public decimal CurrentBalance { get; set; }
        public bool IsDeposit { get; set; }
        public DateTime Date { get; set; }
    }
}
