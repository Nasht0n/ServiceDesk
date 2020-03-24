using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IAccountRepository
    {
        Task<Account> AddAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task DeleteAccount(Account account);
        Task<List<Account>> GetAccounts();
    }
}
