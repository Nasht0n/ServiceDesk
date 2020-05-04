using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class CampusLogic : ICampusLogic
    {
        private readonly ICampusRepository campusRepository;

        public CampusLogic(ICampusRepository campusRepository)
        {
            this.campusRepository = campusRepository;
        }

        public async Task<Campus> GetCampus(int id)
        {
            var campuses = await campusRepository.GetCampuses();
            return campuses.FirstOrDefault(c => c.Id == id);
        }

        public async Task<List<Campus>> GetCampuses(bool descendings = false)
        {
            var campuses = await campusRepository.GetCampuses();
            if(descendings) return campuses.OrderByDescending(c => c.Name).ToList();
            else return campuses.OrderBy(c=>c.Name).ToList();
        }
    }
}
