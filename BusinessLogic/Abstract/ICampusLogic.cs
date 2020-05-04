using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICampusLogic
    {        
        Task<List<Campus>> GetCampuses(bool descendings = false);
        Task<Campus> GetCampus(int id);
    }
}
