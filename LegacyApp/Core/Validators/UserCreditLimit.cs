using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegacyApp
{
    public class UserCreditLimit
    {
        private readonly List<IUserCreditLimit> _userCreditLimits;
        public UserCreditLimit(List<IUserCreditLimit> userCreditLimits)
        {
            _userCreditLimits = userCreditLimits;
        }

        public UserCreditLimit()
        {
            _userCreditLimits = new List<IUserCreditLimit>
            {
                new VeryImportantClient(),
                new ImportantClient(),
                new NormalClient()
             };
        }

        public void ApplyCreditLimitForClient(Client client, User user, IUserCreditService _userCreditService)
        {
            var userCreditLimitSetter = _userCreditLimits.FirstOrDefault(p => p.clientType == client.Type);
            userCreditLimitSetter?.SetUserCreditLimit(user, _userCreditService);
        }
    }
}



