using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AccountLogic : IAccountLogic
    {
        private readonly IAccountRepository accountRepository;

        public AccountLogic(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        public async Task Delete(Account account)
        {
            await accountRepository.DeleteAccount(account);
        }

        public async Task<Account> GetAccountByCredential(string username, string password)
        {
            var accounts = await accountRepository.GetAccounts();
            return accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
        }

        public async Task<Account> GetAccountByEmployeeId(int id)
        {
            var accounts = await accountRepository.GetAccounts();
            return accounts.FirstOrDefault(a => a.EmployeeId == id);
        }

        public async Task<Account> GetAccountById(int id)
        {
            var accounts = await accountRepository.GetAccounts();
            return accounts.FirstOrDefault(e=>e.Id ==id);
        }

        public async Task<Account> Save(Account account)
        {
            Account result = null;
            if(account.Id == 0)
            {
                result = await accountRepository.AddAccount(account);
            } else
            {
                result = await accountRepository.UpdateAccount(account);
            }
            return result;
        }
    }
}
