using Domain;
using Domain.Models.Requests.Software;
using Repository.Abstract.Branches.IT.Software.LifeCycles;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Software.LifeCycles
{
    public class SoftwareReworkRequestLifeCycleRepository : ISoftwareReworkRequestLifeCycleRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public SoftwareReworkRequestLifeCycleRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<SoftwareReworkRequestLifeCycle> Add(SoftwareReworkRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.SoftwareReworkRequestLifeCycles.Add(lifeCycle);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(SoftwareReworkRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.SoftwareReworkRequestLifeCycles.SingleOrDefaultAsync(e => e.Id == lifeCycle.Id);
                context.SoftwareReworkRequestLifeCycles.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<SoftwareReworkRequestLifeCycle>> GetLifeCycles()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.SoftwareReworkRequestLifeCycles
                    .Include(a => a.Request)
                    .Include(a => a.Employee)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<SoftwareReworkRequestLifeCycle> Update(SoftwareReworkRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.SoftwareReworkRequestLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
                if (updated != null)
                {
                    updated.Date = lifeCycle.Date;
                    updated.EmployeeId = lifeCycle.EmployeeId;
                    updated.Message = lifeCycle.Message;
                    updated.RequestId = lifeCycle.RequestId;
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
