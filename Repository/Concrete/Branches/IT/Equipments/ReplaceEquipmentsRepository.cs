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
    public class ReplaceEquipmentsRepository : IReplaceEquipmentsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ReplaceEquipmentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<ReplaceEquipments> Add(ReplaceEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.ReplaceEquipments.Add(equipments);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(ReplaceEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.ReplaceEquipments.SingleOrDefaultAsync(e => e.Id == equipments.Id);
                context.ReplaceEquipments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<ReplaceEquipments>> GetReplaces()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.ReplaceEquipments
                    .Include(a => a.Request)
                    .Include(a => a.EquipmentType)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ReplaceEquipments> Update(ReplaceEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.ReplaceEquipments.SingleOrDefaultAsync(e => e.Id == equipments.Id);
                if (updated != null)
                {
                    updated.InventoryNumber = equipments.InventoryNumber;
                    updated.RequestId = equipments.RequestId;
                    updated.EquipmentTypeId = equipments.EquipmentTypeId;
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
