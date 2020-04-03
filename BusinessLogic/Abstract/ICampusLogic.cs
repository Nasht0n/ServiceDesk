using Domain.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ICampusLogic
    {
        Task<Campus> GetCampusById(int id);
    }
}
