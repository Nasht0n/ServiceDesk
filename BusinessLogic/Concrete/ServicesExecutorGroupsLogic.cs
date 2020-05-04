using BusinessLogic.Abstract;
using Domain.Models;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<ServicesExecutorGroup>> GetServicesExecutorGroups(Service service)
        {
            var groups = await servicesExecutorGroupsRepository.GetServicesExecutorGroups();
            return groups.Where(s => s.ServiceId == service.Id).ToList();
        }
    }
}
