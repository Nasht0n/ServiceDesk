using Domain;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.Requests;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Communication.Requests
{
    public class PhoneLineRepairRequestRepository : IPhoneLineRepairRequestRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public PhoneLineRepairRequestRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<PhoneLineRepairRequest> Add(PhoneLineRepairRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.PhoneLineRepairRequests.Add(request);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(PhoneLineRepairRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.PhoneLineRepairRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                context.PhoneLineRepairRequests.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<PhoneLineRepairRequest>> GetRequests()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.PhoneLineRepairRequests
                    .Include(a => a.Campus)
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
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<PhoneLineRepairRequest> Update(PhoneLineRepairRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.PhoneLineRepairRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                if (updated != null)
                {
                    updated.Location = request.Location;
                    updated.CampusId = request.CampusId;
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
