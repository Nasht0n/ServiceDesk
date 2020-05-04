using Domain.Models;
using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IServicesApproversLogic
    {
        Task<List<ServicesApprover>> GetServicesApprovers(Service service);
    }
}
