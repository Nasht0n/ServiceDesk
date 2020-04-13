using Domain;
using Domain.Models.Requests.Communication;
using Repository.Abstract.Branches.IT.Communication.LifeCycles;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Communication.LifeCycles
{
    public class HoldingPhoneLineRequestLifeCycleRepository : IHoldingPhoneLineRequestLifeCycleRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public HoldingPhoneLineRequestLifeCycleRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<HoldingPhoneLineRequestLifeCycle> Add(HoldingPhoneLineRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.HoldingPhoneLineRequestLifeCycles.Add(lifeCycle);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(HoldingPhoneLineRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.HoldingPhoneLineRequestLifeCycles.SingleOrDefaultAsync(e => e.Id == lifeCycle.Id);
                context.HoldingPhoneLineRequestLifeCycles.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<HoldingPhoneLineRequestLifeCycle>> GetLifeCycles()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.HoldingPhoneLineRequestLifeCycles
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

        public async Task<HoldingPhoneLineRequestLifeCycle> Update(HoldingPhoneLineRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.HoldingPhoneLineRequestLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
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
