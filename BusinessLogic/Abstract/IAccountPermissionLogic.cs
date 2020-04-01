using Domain.Models.ManyToMany;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAccountPermissionLogic
    {
        Task<List<AccountPermission>> GetPermissions(int accountId);
    }
}
