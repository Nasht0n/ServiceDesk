using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class AccountPermissionLogic : IAccountPermissionLogic
    {
        private readonly IAccountPermissionRepository accountPermissionRepository;

        public AccountPermissionLogic(IAccountPermissionRepository accountPermissionRepository)
        {
            this.accountPermissionRepository = accountPermissionRepository;
        }        

        public async Task<List<AccountPermission>> GetPermissions(Account account)
        {
            var permissions = await accountPermissionRepository.GetAccountPermissions();
            return permissions.Where(ap => ap.AccountId == account.Id).ToList();
        }
    }
}
