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
    public class TechnicalSupportEventEquipmentRepository : ITechnicalSupportEventEquipmentRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public TechnicalSupportEventEquipmentRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<TechnicalSupportEventEquipments> Add(TechnicalSupportEventEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.TechnicalSupportEventEquipments.Add(equipments);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(TechnicalSupportEventEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.TechnicalSupportEventEquipments.SingleOrDefaultAsync(r => r.Id == equipments.Id);
                context.TechnicalSupportEventEquipments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<TechnicalSupportEventEquipments>> GetEquipments()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.TechnicalSupportEventEquipments
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

        public async Task<TechnicalSupportEventEquipments> Update(TechnicalSupportEventEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.TechnicalSupportEventEquipments.SingleOrDefaultAsync(r => r.Id == equipments.Id);
                if (updated != null)
                {
                    updated.RequestId = equipments.RequestId;
                    updated.EquipmentName = equipments.EquipmentName;
                    updated.Count = equipments.Count;
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
