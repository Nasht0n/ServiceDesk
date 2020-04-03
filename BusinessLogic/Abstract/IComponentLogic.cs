using Domain.Models;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IComponentLogic
    {
        Task<Component> GetComponentById(int id);
    }
}
