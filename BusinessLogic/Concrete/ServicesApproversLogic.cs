using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ServicesApproversLogic : IServicesApproversLogic
    {
        private readonly IServicesApproversRepository servicesApproversRepository;

        public ServicesApproversLogic(IServicesApproversRepository servicesApproversRepository)
        {
            this.servicesApproversRepository = servicesApproversRepository;
        }

        public async Task<List<ServicesApprover>> GetServicesApprovers(Service service)
        {
            var services = await servicesApproversRepository.GetServicesApprovers();
            return services.Where(s => s.ServiceId == service.Id).ToList();
        }
    }
}
