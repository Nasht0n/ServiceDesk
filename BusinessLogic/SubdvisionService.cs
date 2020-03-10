using DataAccess.Concrete;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic
{
    public class SubdvisionService
    {
        private readonly ServiceDesk serviceDesk = new ServiceDesk();

        public List<Subdivision> GetSubdivisions()
        {
            return serviceDesk.SubdivisionRepository.Get().ToList();
        }

        public List<Subdivision> GetSubdivisions(string search)
        {
            return serviceDesk.SubdivisionRepository.Get(s=>!string.IsNullOrEmpty(search) && (s.Fullname.Contains(search) || s.Shortname.Equals(search))).ToList();
        }

        public Subdivision GetSubdivisionById(int id)
        {
            return serviceDesk.SubdivisionRepository.GetByID(id);
        }

        public void AddSubdivision(Subdivision subdivision)
        {
            serviceDesk.SubdivisionRepository.Insert(subdivision);
            serviceDesk.Save();
        }

        public void UpdateSubdivision(Subdivision subdivision)
        {
            serviceDesk.SubdivisionRepository.Update(subdivision);
            serviceDesk.Save();
        }

        public void DeleteSubdivision(Subdivision subdivision)
        {
            serviceDesk.SubdivisionRepository.Delete(subdivision.Id);
            serviceDesk.Save();
        }
    }
}
