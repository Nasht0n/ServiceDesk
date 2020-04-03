using BusinessLogic.Abstract;
using Domain.Models;
using Repository.Abstract;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete
{
    public class ComponentLogic : IComponentLogic
    {
        private readonly IComponentRepository componentRepository;

        public ComponentLogic(IComponentRepository componentRepository)
        {
            this.componentRepository = componentRepository;
        }

        public async Task<Component> GetComponentById(int id)
        {
            var components = await componentRepository.GetComponents();
            return components.FirstOrDefault(c => c.Id == id);
        }
    }
}
