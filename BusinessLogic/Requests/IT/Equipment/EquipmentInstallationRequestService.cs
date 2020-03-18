using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests
{
    public class EquipmentInstallationRequestService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public EquipmentInstallationRequest GetRequest(int id)
        {
            return serviceDesk.EquipmentInstallationRequestRepository.Get(
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
                "InstallationEquipments," +
                "InstallationEquipments.EquipmentType")                
                .FirstOrDefault();
        }

        public void AddRequest(EquipmentInstallationRequest request)
        {
            serviceDesk.EquipmentInstallationRequestRepository.Insert(request);
            serviceDesk.Save();
        }

        public void UpdateRequest(EquipmentInstallationRequest request)
        {
            serviceDesk.EquipmentInstallationRequestRepository.Update(request);
            serviceDesk.Save();
        }

        public void DeleteRequest(EquipmentInstallationRequest request)
        {
            serviceDesk.EquipmentInstallationRequestRepository.Update(request);
            serviceDesk.Save();
        }
    }
}
