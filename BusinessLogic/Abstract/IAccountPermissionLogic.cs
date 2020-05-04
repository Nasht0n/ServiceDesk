using Domain.Models;
using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAccountPermissionLogic
    {
        Task<List<AccountPermission>> GetPermissions(Account account);
    }
}
