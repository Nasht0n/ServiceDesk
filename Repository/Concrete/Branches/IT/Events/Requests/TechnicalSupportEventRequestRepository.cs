using Domain;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events.Requests;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Events.Requests
{
    public class TechnicalSupportEventRequestRepository : ITechnicalSupportEventRequestRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public TechnicalSupportEventRequestRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<TechnicalSupportEventRequest> Add(TechnicalSupportEventRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.TechnicalSupportEventRequests.Add(request);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(TechnicalSupportEventRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.TechnicalSupportEventRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                context.TechnicalSupportEventRequests.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<TechnicalSupportEventRequest>> GetRequests()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.TechnicalSupportEventRequests
                    .Include(a => a.Service)
                    .Include(a => a.Service.Category)
                    .Include(a => a.Service.Category.Branch)
                    .Include(a => a.Status)
                    .Include(a => a.Priority)
                    .Include(a => a.Client)
                    .Include(a => a.Client.Subdivision)
                    .Include(a => a.Executor)
                    .Include(a => a.Executor.Subdivision)
                    .Include(a => a.ExecutorGroup)
                    .Include(a => a.Subdivision)
                    .Include(a=>a.EventInfos.Select(e=>e.Campus))
                    .Include(a => a.EventEquipments)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TechnicalSupportEventRequest> Update(TechnicalSupportEventRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.TechnicalSupportEventRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                if (updated != null)
                {
                    updated.Title = request.Title;
                    updated.Justification = request.Justification;
                    updated.Description = request.Description;
                    updated.ServiceId = request.ServiceId;
                    updated.StatusId = request.StatusId;
                    updated.PriorityId = request.PriorityId;
                    updated.ClientId = request.ClientId;
                    updated.ExecutorId = request.ExecutorId;
                    updated.ExecutorGroupId = request.ExecutorGroupId;
                    updated.SubdivisionId = request.SubdivisionId;
                }
                await context.SaveChangesAsync();
                watch.Stop();
                return updated;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
