using BusinessLogic.Abstract.Branches.IT.Equipments;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Equipments
{
    public class ReplaceComponentsLogic : IReplaceComponentsLogic
    {
        private readonly IReplaceComponentsRepository componentsRepository;

        public ReplaceComponentsLogic(IReplaceComponentsRepository componentsRepository)
        {
            this.componentsRepository = componentsRepository;
        }

        public async Task<ReplaceComponents> Add(ReplaceComponents component)
        {
            return await componentsRepository.Add(component);
        }

        public async Task DeleteEntry(ComponentReplaceRequest request)
        {
            var components = await componentsRepository.GetComponents();
            foreach(var component in components.Where(c=>c.RequestId == request.Id))
            {
                await componentsRepository.Delete(component);
            }            
        }
    }
}
