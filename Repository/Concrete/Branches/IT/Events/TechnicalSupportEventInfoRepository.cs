using Domain;
using Domain.Models.Requests.Events;
using Repository.Abstract.Branches.IT.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Events
{
    public class TechnicalSupportEventInfoRepository : ITechnicalSupportEventInfoRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public TechnicalSupportEventInfoRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<TechnicalSupportEventInfos> Add(TechnicalSupportEventInfos equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.TechnicalSupportEventInfos.Add(equipments);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(TechnicalSupportEventInfos equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.TechnicalSupportEventInfos.SingleOrDefaultAsync(r => r.Id == equipments.Id);
                context.TechnicalSupportEventInfos.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<TechnicalSupportEventInfos>> GetEquipments()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.TechnicalSupportEventInfos
                    .Include(a => a.Request)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<TechnicalSupportEventInfos> Update(TechnicalSupportEventInfos equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.TechnicalSupportEventInfos.SingleOrDefaultAsync(r => r.Id == equipments.Id);
                if (updated != null)
                {
                    updated.RequestId = equipments.RequestId;
                    updated.CampusId = equipments.CampusId;
                    updated.Location = equipments.Location;
                    updated.EventDate = equipments.EventDate;
                    updated.StartTime = equipments.StartTime;
                    updated.EndTime = equipments.EndTime;
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
