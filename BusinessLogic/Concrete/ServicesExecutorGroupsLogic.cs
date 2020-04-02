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
    public class ServicesExecutorGroupsLogic : IServicesExecutorGroupsLogic
    {
        private readonly IServicesExecutorGroupsRepository servicesExecutorGroupsRepository;

        public ServicesExecutorGroupsLogic(IServicesExecutorGroupsRepository servicesExecutorGroupsRepository)
        {
            this.servicesExecutorGroupsRepository = servicesExecutorGroupsRepository;
        }

        public async Task<List<ServicesExecutorGroup>> GetServicesExecutorGroups(int serviceId)
        {
            var groups = await servicesExecutorGroupsRepository.GetServicesExecutorGroups();
            return groups.Where(s => s.ServiceId == serviceId).ToList();
        }
    }
}
