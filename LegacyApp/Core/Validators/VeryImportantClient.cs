using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    public class VeryImportantClient : IUserCreditLimit
    {
        public string clientType => "VeryImportantClient";

        public void SetUserCreditLimit(User user, IUserCreditService _userCreditService)
        {
            user.HasCreditLimit = false;
        }
    }
}
