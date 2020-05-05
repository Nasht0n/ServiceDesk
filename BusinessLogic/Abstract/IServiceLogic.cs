using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IServiceLogic
    {
        Task<Service> GetService(int id);
        Task<List<Service>> GetActiveServices(bool descendings = false);
        Task<List<Service>> GetActiveServices(Category category, bool descendings = false);
    }
}
