using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.ManyToMany
{
    public class AccountPermission
    {
        public int AccountId { get; set; }
        
        public int PermissionId { get; set; }

        public Account Account { get; set; }
        public Permission Permission { get; set; }
    }
}
