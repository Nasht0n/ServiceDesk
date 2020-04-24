using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class StatusRepository : IStatusRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public StatusRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Status> Add(Status status)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Statuses.Add(status);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(Status status)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.Statuses.SingleOrDefaultAsync(s => s.Id == status.Id);
                context.Statuses.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<Status>> GetStatuses()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.Statuses
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Status> Update(Status status)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.Statuses.SingleOrDefaultAsync(s => s.Id == status.Id);
                if (updated != null)
                {
                    updated.Fullname = status.Fullname;
                    updated.Shortname = status.Shortname;
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
