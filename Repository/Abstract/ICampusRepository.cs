using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface ICampusRepository
    {
        Task<Campus> Add(Campus campus);
        Task<Campus> Update(Campus campus);
        Task Delete(Campus campus);
        Task<List<Campus>> GetCampuses();
    }
}
