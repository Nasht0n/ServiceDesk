using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests.IT.Equipment
{
    public class EquipmentRepairRequestService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public EquipmentRepairRequest GetRequest(int id)
        {
            return serviceDesk.EquipmentRepairRequestRepository.Get(
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
                "RepairEquipments," +
                "RepairEquipments.Consumable")
                .FirstOrDefault();
        }

        public void AddRequest(EquipmentRepairRequest request)
        {
            serviceDesk.EquipmentRepairRequestRepository.Insert(request);
            serviceDesk.Save();
        }

        public void UpdateRequest(EquipmentRepairRequest request)
        {
            serviceDesk.EquipmentRepairRequestRepository.Update(request);
            serviceDesk.Save();
        }

        public void DeleteRequest(EquipmentRepairRequest request)
        {
            serviceDesk.EquipmentRepairRequestRepository.Delete(request);
            serviceDesk.Save();
        }
    }
}
