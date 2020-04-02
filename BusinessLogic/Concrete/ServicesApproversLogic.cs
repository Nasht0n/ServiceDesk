using BusinessLogic.Abstract;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        public async Task<List<ServicesApprover>> GetServicesApprovers(int serviceId)
        {
            var services = await servicesApproversRepository.GetServicesApprovers();
            return services.Where(s => s.ServiceId == serviceId).ToList();
        }
    }
}
