using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class ServiceService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public List<Service> GetServices()
        {
            return serviceDesk.ServiceRepository.Get(includeProperties: "Category, Category.Branch, ExecutorGroups, Approvers").ToList();
        }

        public Service GetServiceById(int id)
        {
            return serviceDesk.ServiceRepository.Get(filter: e => e.Id == id, includeProperties: "Category, Category.Branch, ExecutorGroups, Approvers").FirstOrDefault();
        }

        public void AddService(Service service)
        {
            serviceDesk.ServiceRepository.Insert(service);
            serviceDesk.Save();
        }

        public void UpdateService(Service service)
        {
            serviceDesk.ServiceRepository.Update(service);
            serviceDesk.Save();
        }

        public void DeleteService(Service service)
        {
            serviceDesk.ServiceRepository.Delete(service);
            serviceDesk.Save();
        }
    }
}
