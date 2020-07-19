﻿using FonNature.Areas.Admin.Models;
using FonNature.Services.IServices;
using Models.Entity;
using Models.Repository;

namespace FonNature.Services.Services
{
    public class AccountAdminServices : IAccountAdminServices
    {
        private readonly AccountAdminRepository _accountAdminRepository;
        public AccountAdminServices()
        {
            _accountAdminRepository = AccountAdminRepository.getInstance();
        }
        public int checkLoginAdmin(LoginModel loginModel)
        {
            if (!_accountAdminRepository.CheckUserName(loginModel.UserName)) return 0;
            if (!_accountAdminRepository.CheckPassword(loginModel.UserName, loginModel.PassWord)) return -1;
            if (!_accountAdminRepository.CheckStatusAccount(loginModel.UserName, loginModel.PassWord)) return -2;
            return 1;
        }

        public bool CreateAccount(AccountAdmin accountAdmin)
        {
            var accountExits = _accountAdminRepository.CheckUserName(accountAdmin.userName);
            if (accountExits)
            {
                return false;
            }
                
            var idAccount = _accountAdminRepository.AddAccount(accountAdmin);
            if (idAccount == 0) return false;
            return true;
        }

        public bool EditAccount(AccountAdmin accountAdmin)
        {
            var EditAccount = _accountAdminRepository.EditAccount(accountAdmin);
            if (!EditAccount) return false;
            return true;
        }
    }
}