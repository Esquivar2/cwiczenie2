using System;
using System.Collections.Generic;

namespace LegacyApp
{

    public class UserService
    {
        private IClientRepository _clientRepository;
        private IUserCreditService _userCreditService;
        private IInputValidator _inputValidator;
        private IUserDataAccess _userDataAccess;
        private ICreditLimitCheck _creditLimitCheck;

        public UserService(IClientRepository clientRepository, IUserCreditService userCreditService, 
            IUserDataAccess userDataAccess, ICreditLimitCheck creditLimitCheck)
        {
            _clientRepository = clientRepository;
            _userCreditService = userCreditService;
            _inputValidator = new InputValidator();
            _userDataAccess = userDataAccess;
            _creditLimitCheck = creditLimitCheck;
        }

        [Obsolete]
        public UserService()
        { 
            _clientRepository = new ClientRepository();
            _userCreditService = new UserCreditService();
            _inputValidator = new InputValidator();
            _userDataAccess = new AdapterUserDataAccess();
            _creditLimitCheck = new CreditLimitCheck();
        }

        public bool AddUser(string firstName, string lastName, string email, DateTime dateOfBirth, int clientId)
        {

            if (!_inputValidator.ValidateName(firstName, lastName))
            {
                return false;
            }

            if (!_inputValidator.ValidateEmail(email))
            {
                return false;
            }

            if (!_inputValidator.ValidateAge(dateOfBirth))
            {
                return false;
            }

            var client = _clientRepository.GetById(clientId);

            var user = new User
            {
                Client = client,
                DateOfBirth = dateOfBirth,
                EmailAddress = email,
                FirstName = firstName,
                LastName = lastName
            };

            var userCreditLimitManager = new UserCreditLimit();
            userCreditLimitManager.ApplyCreditLimitForClient(client, user, _userCreditService);

            if (!_creditLimitCheck.ValidateCreditLimit(user))
            {
                return false;
            }

            _userDataAccess.AddUser(user);
            return true;
        }
    }
}