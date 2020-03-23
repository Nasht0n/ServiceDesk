using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class AccountService
    {
        private readonly ServiceDesk serviceDesk = new ServiceDesk();

        public List<Account> GetAccounts()
        {
            return serviceDesk.AccountRepository.Get(includeProperties: "Employee,Employee.Subdivision, Permissions").ToList();
        }

        public Account GetAccountByCredentials(string username, string password)
        {
            return serviceDesk.AccountRepository.Get(a => a.Username == username && a.Password == password).FirstOrDefault();
        }

        public Account GetAccountById(int id)
        {
            return serviceDesk.AccountRepository.Get(filter: a => a.Id == id, includeProperties: "Employee, Employee.Subdivision, Permissions").FirstOrDefault();
        }
        
        public void AddAccount(Account account)
        {
            serviceDesk.AccountRepository.Insert(account);
            serviceDesk.Save();
        }

        

        public void UpdateAccount(Account account)
        {
            serviceDesk.AccountRepository.Update(account);
            serviceDesk.Save();
        }
    }
}
