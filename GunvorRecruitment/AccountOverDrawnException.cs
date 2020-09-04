using System;

namespace GunvorRecruitment
{
    public class AccountOverDrawnException : Exception
    {
        public AccountOverDrawnException() : base("Withdrawal amount cannot be greater than Overdraft amount.")
        {
        }

        public AccountOverDrawnException(string message)
            : base(message)
        {

        }
    }
}