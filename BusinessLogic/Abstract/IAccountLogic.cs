using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAccountLogic
    {
        Task<Account> Save(Account account);
        Task Delete(Account account);
        Task<Account> GetAccountById(int id);
        Task<Account> GetAccountByEmployeeId(int id);
        Task<Account> GetAccountByCredential(string username, string password);
    }
}
