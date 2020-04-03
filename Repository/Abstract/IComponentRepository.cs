using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IComponentRepository
    {
        Task<Component> Add(Component component);
        Task<Component> Update(Component component);
        Task Delete(Component component);
        Task<List<Component>> GetComponents();
    }
}
