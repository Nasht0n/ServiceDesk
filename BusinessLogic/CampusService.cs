using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class CampusService
    {
        private readonly ServiceDesk serviceDesk = new ServiceDesk();

        public List<Campus> GetCampuses()
        {
            return serviceDesk.CampusRepository.Get().ToList();
        }

        public Campus GetCampusById(int id)
        {
            return serviceDesk.CampusRepository.Get(filter: e => e.Id == id).FirstOrDefault();
        }

        public void AddCampus(Campus campus)
        {
            serviceDesk.CampusRepository.Insert(campus);
            serviceDesk.Save();
        }

        public void UpdateCampus(Campus campus)
        {
            serviceDesk.CampusRepository.Update(campus);
            serviceDesk.Save();
        }

        public void DeleteCampus(Campus campus)
        {
            serviceDesk.CampusRepository.Delete(campus);
            serviceDesk.Save();
        }
    }
}
