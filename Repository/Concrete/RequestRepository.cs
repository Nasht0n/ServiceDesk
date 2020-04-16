using Domain;
using Domain.Views;
using Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Repository.Concrete
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ServiceDeskContext context;

        public RequestRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<List<Requests>> GetRequests()
        {
            try
            {
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Requests
                    .Include(r => r.Service)
                    .Include(r => r.Service.Category)
                    .Include(r => r.Service.Category.Branch)
                    .Include(r => r.Status)
                    .Include(r => r.Priority)
                    .Include(r => r.Client)
                    .Include(r => r.Client.Subdivision)
                    .Include(r => r.Executor)
                    .Include(r => r.Executor.Subdivision)
                    .Include(r => r.ExecutorGroup)
                    .Include(r => r.Subdivision)
                    .ToListAsync();

                watch.Stop();
                return list;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
