using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ServiceLogic : IServiceLogic
    {
        private readonly IServiceRepository serviceRepository;

        public ServiceLogic(IServiceRepository serviceRepository)
        {
            this.serviceRepository = serviceRepository;
        }
        public async Task<Service> GetServiceById(int id)
        {
            var services = await serviceRepository.GetServices();
            return services.FirstOrDefault(s => s.Id == id);
        }
    }
}
