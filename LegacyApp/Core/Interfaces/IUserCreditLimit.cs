using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    public interface IUserCreditLimit
    {
        string clientType { get; }
        public void SetUserCreditLimit(User user, IUserCreditService _userCreditService);
    }
}
