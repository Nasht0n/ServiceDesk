using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICampusLogic
    {        
        Task<List<Campus>> GetCampuses();
        Task<List<Campus>> GetCampusesDescending();
        Task<Campus> GetCampusById(int id);
    }
}
