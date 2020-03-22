using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests.IT.Equipment
{
    public class ReplaceComponentService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public void AddRequest(ReplaceComponents component)
        {
            serviceDesk.ReplaceComponentRepository.Insert(component);
            serviceDesk.Save();
        }

        public void DeleteEntry(ComponentReplaceRequest request)
        {
            var list = serviceDesk.ReplaceComponentRepository.Get(filter: e => e.RequestId == request.Id).ToList();
            foreach (var item in list)
            {
                serviceDesk.ReplaceComponentRepository.Delete(item);
            }
            serviceDesk.Save();
        }
    }
}
