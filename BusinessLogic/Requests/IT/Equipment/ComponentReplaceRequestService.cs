using DataAccess.Concrete;
using Domain.Models.Requests.Equipment;
using System.Linq;

namespace BusinessLogic.Requests.IT.Equipment
{
    public class ComponentReplaceRequestService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public ComponentReplaceRequest GetRequest(int id)
        {
            return serviceDesk.ComponentReplaceRequestRepository.Get(
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
                "ReplaceComponents," +
                "ReplaceComponents.Component")
                .FirstOrDefault();
        }

        public void AddRequest(ComponentReplaceRequest request)
        {
            serviceDesk.ComponentReplaceRequestRepository.Insert(request);
            serviceDesk.Save();
        }

        public void UpdateRequest(ComponentReplaceRequest request)
        {
            serviceDesk.ComponentReplaceRequestRepository.Update(request);
            serviceDesk.Save();
        }

        public void DeleteRequest(ComponentReplaceRequest request)
        {
            serviceDesk.ComponentReplaceRequestRepository.Delete(request);
            serviceDesk.Save();
        }
    }
}
