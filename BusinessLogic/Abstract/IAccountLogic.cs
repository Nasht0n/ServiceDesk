using Domain.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAccountLogic
    {
        Task<Account> Save(Account account);
        Task Delete(Account account);
        Task<Account> GetAccount(int id);
        Task<Account> GetAccount(Employee employee);
        Task<Account> GetAccount(string username, string password);
    }
}
