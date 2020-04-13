using Domain;
using Domain.Models.Requests.Network;
using Repository.Abstract.Branches.IT.Network;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Network
{
    public class ConnectionEquipmentsRepository : IConnectionEquipmentsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ConnectionEquipmentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<ConnectionEquipments> Add(ConnectionEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.ConnectionEquipments.Add(equipments);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(ConnectionEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.ConnectionEquipments.SingleOrDefaultAsync(e => e.Id == equipments.Id);
                context.ConnectionEquipments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<ConnectionEquipments>> GetEquipments()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.ConnectionEquipments
                    .Include(a => a.EquipmentType)
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

        public async Task<ConnectionEquipments> Update(ConnectionEquipments equipments)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.ConnectionEquipments.SingleOrDefaultAsync(e => e.Id == equipments.Id);
                if (updated != null)
                {
                    updated.Count = equipments.Count;
                    updated.RequestId = equipments.RequestId;
                    updated.EquipmentTypeId = equipments.EquipmentTypeId;
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
