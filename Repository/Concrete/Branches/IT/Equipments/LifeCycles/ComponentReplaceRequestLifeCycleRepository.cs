using Domain;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments.LifeCycles;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Equipments.LifeCycles
{
    public class ComponentReplaceRequestLifeCycleRepository : IComponentReplaceRequestLifeCycleRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ComponentReplaceRequestLifeCycleRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<ComponentReplaceRequestLifeCycle> Add(ComponentReplaceRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.ComponentReplaceRequestLifeCycles.Add(lifeCycle);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(ComponentReplaceRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.ComponentReplaceRequestLifeCycles.SingleOrDefaultAsync(e => e.Id == lifeCycle.Id);
                context.ComponentReplaceRequestLifeCycles.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<ComponentReplaceRequestLifeCycle>> GetLifeCycles()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.ComponentReplaceRequestLifeCycles
                    .Include(a => a.Request)
                    .Include(a => a.Employee)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ComponentReplaceRequestLifeCycle> Update(ComponentReplaceRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.ComponentReplaceRequestLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
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
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
