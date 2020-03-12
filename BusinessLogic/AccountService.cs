﻿using DataAccess.Concrete;
using Domain.Models;
using System.Linq;

namespace BusinessLogic
{
    public class AccountService
    {
        private readonly ServiceDesk serviceDesk = new ServiceDesk();

        public Account GetAccountByCredentials(string username, string password)
        {
            return serviceDesk.AccountRepository.Get(a => a.Username == username && a.Password == password).FirstOrDefault();
        } 
    }
}