using Domain.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface ISubdivisionLogic
    {
        Task<Subdivision> GetSubdivision(int id);
    }
}
