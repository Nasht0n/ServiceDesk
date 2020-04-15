using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class RefuelingLimitRepository : IRefuelingLimitRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public RefuelingLimitRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<RefuelingLimits> Add(RefuelingLimits limit)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.RefuelingLimits.Add(limit);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(RefuelingLimits limit)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.RefuelingLimits.SingleOrDefaultAsync(l => l.Id == limit.Id);
                context.RefuelingLimits.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<RefuelingLimits>> GetLimits()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.RefuelingLimits
                    .Include(l => l.Subdivision)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<RefuelingLimits> Update(RefuelingLimits limit)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.RefuelingLimits.SingleOrDefaultAsync(p => p.Id == limit.Id);
                if (updated != null)
                {
                    updated.Count = limit.Count;
                    updated.Year = limit.Year;
                    updated.SubdivisionId = limit.SubdivisionId;
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
