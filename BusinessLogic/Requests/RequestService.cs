using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Views;

namespace BusinessLogic.Requests
{
    public class RequestService
    {
        private ServiceDesk serviceDesk = new ServiceDesk();

        public List<Domain.Views.Requests> GetRequests()
        {
            return serviceDesk.RequestsRepository
                .Get(includeProperties:
                "Service, Service.Category, Service.Category.Branch, " +
                "Status, " +
                "Priority, " +
                "Client, Client.Subdivision," +
                "Executor, Executor.Subdivision," +
                "ExecutorGroup, " +
                "Subdivision")
                .ToList();
        }
    }
}
