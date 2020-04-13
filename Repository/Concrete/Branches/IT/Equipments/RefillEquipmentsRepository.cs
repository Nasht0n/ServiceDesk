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
    public class RefillEquipmentsRepository : IRefillEquipmentsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public RefillEquipmentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<RefillEquipments> Add(RefillEquipments refill)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.RefillEquipments.Add(refill);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(RefillEquipments refill)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.RefillEquipments.SingleOrDefaultAsync(e => e.Id == refill.Id);
                context.RefillEquipments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<RefillEquipments>> GetRefills()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.RefillEquipments
                    .Include(a => a.Request)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<RefillEquipments> Update(RefillEquipments refill)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.RefillEquipments.SingleOrDefaultAsync(e => e.Id == refill.Id);
                if (updated != null)
                {
                    updated.InventoryNumber = refill.InventoryNumber;
                    updated.RequestId = refill.RequestId;
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
