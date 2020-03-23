using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class PermissionService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public Permission GetPermissionById(int id)
        {
            return serviceDesk.PermissionRepository.GetByID(id);
        }

        public List<Permission> GetPermissions()
        {
            return serviceDesk.PermissionRepository.Get().ToList();
        }
    }
}
