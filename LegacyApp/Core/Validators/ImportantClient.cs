using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    public class ImportantClient : IUserCreditLimit
    {
        public string clientType => "ImportantClient";

        public void SetUserCreditLimit(User user, IUserCreditService _userCreditService)
        {
            int creditLimit = _userCreditService.GetCreditLimit(user.LastName, user.DateOfBirth);
            creditLimit = creditLimit * 2;
            user.CreditLimit = creditLimit;
        }

    }
}
