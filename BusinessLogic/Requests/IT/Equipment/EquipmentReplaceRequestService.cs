using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests.IT.Equipment
{
    public class EquipmentReplaceRequestService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();
        public EquipmentReplaceRequest GetRequest(int id)
        {
            return serviceDesk.EquipmentReplaceRequestRepository.Get(
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
                "ReplaceEquipments," +
                "ReplaceEquipments.EquipmentType")
                .FirstOrDefault();
        }

        public void AddRequest(EquipmentReplaceRequest request)
        {
            serviceDesk.EquipmentReplaceRequestRepository.Insert(request);
            serviceDesk.Save();
        }

        public void UpdateRequest(EquipmentReplaceRequest request)
        {
            serviceDesk.EquipmentReplaceRequestRepository.Update(request);
            serviceDesk.Save();
        }

        public void DeleteRequest(EquipmentReplaceRequest request)
        {
            serviceDesk.EquipmentReplaceRequestRepository.Delete(request);
            serviceDesk.Save();
        }
    }
}
