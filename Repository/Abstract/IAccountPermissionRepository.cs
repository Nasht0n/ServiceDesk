using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IAccountPermissionRepository
    {
        Task<AccountPermission> AddAccountPermission(AccountPermission accountPermission);
        Task DeleteAccountPermission(AccountPermission accountPermission);
        Task<List<AccountPermission>> GetAccountPermissions();
    }
}
