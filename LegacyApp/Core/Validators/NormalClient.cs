using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    public class NormalClient : IUserCreditLimit
    {
        public string clientType => "NormalClient";

        public void SetUserCreditLimit(User user, IUserCreditService _userCreditService)
        {
            user.HasCreditLimit = true;
            int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            user.CreditLimit = creditLimit;
        }
    }
}
