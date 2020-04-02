using Domain.Models.ManyToMany;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IServicesApproversLogic
    {
        Task<List<ServicesApprover>> GetServicesApprovers(int serviceId);
    }
}
