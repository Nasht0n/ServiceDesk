using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class PriorityService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public List<Priority> GetPriorities()
        {
            return serviceDesk.PriorityRepository.Get().ToList();
        }

        public Priority GetPriorityById(int id)
        {
            return serviceDesk.PriorityRepository.Get(filter: e => e.Id == id).FirstOrDefault();
        }

        public void AddPriority(Priority priority)
        {
            serviceDesk.PriorityRepository.Insert(priority);
            serviceDesk.Save();
        }

        public void UpdatePriority(Priority priority)
        {
            serviceDesk.PriorityRepository.Update(priority);
            serviceDesk.Save();
        }

        public void DeletePriority(Priority priority)
        {
            serviceDesk.PriorityRepository.Delete(priority);
            serviceDesk.Save();
        }
    }
}
