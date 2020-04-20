using BusinessLogic.Abstract.Branches.IT.Networks;
using Domain.Models.Requests.Network;
using Repository.Abstract.Branches.IT.Network;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLogic.Concrete.Branches.IT.Networks
{
    public class ConnectionEquipmentsLogic : IConnectionEquipmentsLogic
    {
        private readonly IConnectionEquipmentsRepository repository;

        public ConnectionEquipmentsLogic(IConnectionEquipmentsRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ConnectionEquipments> Add(ConnectionEquipments equipments)
        {
            return await repository.Add(equipments);
        }

        public async Task DeleteEntry(NetworkConnectionRequest request)
        {
            var equipments = await repository.GetEquipments();
            foreach (var equipment in equipments.Where(e => e.RequestId == request.Id))
            {
                await repository.Delete(equipment);
            }
        }
    }
}
