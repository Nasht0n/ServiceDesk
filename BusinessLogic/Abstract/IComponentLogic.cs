using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IComponentLogic
    {
        Task<Component> GetComponentById(int id);
        Task<List<Component>> GetComponents();
    }
}
