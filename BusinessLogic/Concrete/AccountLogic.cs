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

        public async Task<Account> GetAccount(string username, string password)
        {
            var accounts = await accountRepository.GetAccounts();
            return accounts.FirstOrDefault(a => a.Username == username && a.Password == password);
        }

        public async Task<Account> GetAccount(Employee employee)
        {
            var accounts = await accountRepository.GetAccounts();
            return accounts.FirstOrDefault(a => a.EmployeeId == employee.Id);
        }

        public async Task<Account> GetAccount(int id)
        {
            var accounts = await accountRepository.GetAccounts();
            return accounts.FirstOrDefault(e=>e.Id ==id);
        }

        public async Task<Account> Save(Account account)
        {
            Account result;
            if (account.Id == 0)
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
