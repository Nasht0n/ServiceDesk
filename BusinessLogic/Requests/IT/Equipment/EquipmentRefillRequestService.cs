using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests.IT.Equipment
{
    public class EquipmentRefillRequestService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();
        public EquipmentRefillRequest GetRequest(int id)
        {
            return serviceDesk.EquipmentRefillRequestRepository.Get(
                filter: r => r.Id == id,
                includeProperties:
                "Service," +
                "Service.Category," +
                "Service.Category.Branch," +
                "Service.Approvers," +
                "Service.ExecutorGroups," +
                "Status," +
                "Priority," +
                "Client," +
                "Client.Subdivision," +
                "Client.Subdivision.SubdivisionExecutors," +
                "Client.ApprovalServices," +
                "Client.ExecutorGroups," +
                "Client.ExecutorSubdivisions," +
                "Campus," +
                "Executor," +
                "Executor.Subdivision," +
                "Executor.Subdivision.SubdivisionExecutors," +
                "Executor.ApprovalServices," +
                "Executor.ExecutorGroups," +
                "Executor.ExecutorSubdivisions," +
                "ExecutorGroup," +
                "ExecutorGroup.Employees," +
                "ExecutorGroup.Services," +
                "RefillEquipments")
                .FirstOrDefault();
        }

        public void AddRequest(EquipmentRefillRequest request)
        {
            serviceDesk.EquipmentRefillRequestRepository.Insert(request);
            serviceDesk.Save();
        }

        public void UpdateRequest(EquipmentRefillRequest request)
        {
            serviceDesk.EquipmentRefillRequestRepository.Update(request);
            serviceDesk.Save();
        }

        public void DeleteRequest(EquipmentRefillRequest request)
        {
            serviceDesk.EquipmentRefillRequestRepository.Delete(request);
            serviceDesk.Save();
        }
    }
}
