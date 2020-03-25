using Domain.Models.ManyToMany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IServicesApproversRepository
    {
        Task<ServicesApprover> AddServicesApprover(ServicesApprover approver);
        Task DeleteServicesApprover(ServicesApprover approver);
        Task<List<ServicesApprover>> GetServicesApprovers();
    }
}
