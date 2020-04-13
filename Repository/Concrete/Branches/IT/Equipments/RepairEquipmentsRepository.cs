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
    public class RepairEquipmentsRepository : IRepairEquipmentsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public RepairEquipmentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<RepairEquipments> Add(RepairEquipments repair)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.RepairEquipments.Add(repair);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(RepairEquipments repair)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.RepairEquipments.SingleOrDefaultAsync(e => e.Id == repair.Id);
                context.RepairEquipments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<RepairEquipments>> GetRepairs()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.RepairEquipments
                    .Include(a => a.Request)
                    .Include(a => a.Consumable)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<RepairEquipments> Update(RepairEquipments repair)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.RepairEquipments.SingleOrDefaultAsync(e => e.Id == repair.Id);
                if (updated != null)
                {
                    updated.Count = repair.Count;
                    updated.RequestId = repair.RequestId;
                    updated.ConsumableId = repair.ConsumableId;
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
