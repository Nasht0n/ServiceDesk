using Domain;
using Domain.Models.Requests.Equipment;
using Repository.Abstract.Branches.IT.Equipments;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Equipments
{
    public class ReplaceComponentsRepository : IReplaceComponentsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ReplaceComponentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<ReplaceComponents> Add(ReplaceComponents components)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.ReplaceComponents.Add(components);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(ReplaceComponents components)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.ReplaceComponents.SingleOrDefaultAsync(c => c.Id == components.Id);
                context.ReplaceComponents.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<ReplaceComponents>> GetComponents()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.ReplaceComponents
                    .Include(a => a.Request)
                    .Include(a => a.Component)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ReplaceComponents> Update(ReplaceComponents components)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.ReplaceComponents.SingleOrDefaultAsync(c => c.Id == components.Id);
                if (updated != null)
                {
                    updated.Count = components.Count;
                    updated.RequestId = components.RequestId;
                    updated.ComponentId = components.ComponentId;
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
