using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<List<Service>> GetActiveServices(bool descendings = false)
        {
            var services = await serviceRepository.GetServices();
            if(descendings) return services.Where(s => s.Visible).OrderByDescending(s => s.Name).ToList();
            else return services.Where(s => s.Visible).OrderBy(s=>s.Name).ToList();
        }

        public async Task<List<Service>> GetActiveServices(Category category, bool descendings = false)
        {
            var services = await serviceRepository.GetServices();
            services = services.Where(s => s.CategoryId == category.Id).ToList();
            if (descendings) return services.Where(s => s.Visible).OrderByDescending(s => s.Name).ToList();
            else return services.Where(s => s.Visible).OrderBy(s => s.Name).ToList();
        }

        public async Task<Service> GetService(int id)
        {
            var services = await serviceRepository.GetServices();
            return services.FirstOrDefault(s => s.Id == id);
        }
    }
}
