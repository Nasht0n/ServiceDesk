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
    public class InstallationEquipmentsRepository : IInstallationEquipmentsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public InstallationEquipmentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<InstallationEquipments> Add(InstallationEquipments installation)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.InstallationEquipments.Add(installation);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(InstallationEquipments installation)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.InstallationEquipments.SingleOrDefaultAsync(e => e.Id == installation.Id);
                context.InstallationEquipments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<InstallationEquipments>> GetEquipments()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.InstallationEquipments
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

        public async Task<InstallationEquipments> Update(InstallationEquipments installation)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.InstallationEquipments.SingleOrDefaultAsync(e => e.Id == installation.Id);
                if (updated != null)
                {
                    updated.Count = installation.Count;
                    updated.RequestId = installation.RequestId;
                    updated.EquipmentTypeId = installation.EquipmentTypeId;
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
