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
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public EquipmentRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Equipment> Add(Equipment equipment)
        {
            try
            {
                log.Information($"Добавление оборудования: {equipment.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Equipments.Add(equipment);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Оборудование добавлено. Затрачено времени: {watch.Elapsed}.");
                return inserted;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task Delete(Equipment equipment)
        {
            try
            {
                log.Information($"Удаление оборудования: {equipment.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.Equipments.SingleOrDefaultAsync(a => a.Id == equipment.Id);
                context.Equipments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Оборудование удалено. Затрачено времени: {watch.Elapsed}.");
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления оборудования. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Equipment>> GetEquipments()
        {
            try
            {
                log.Information($"Получение списка оборудования");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.Equipments
                    .Include(e=>e.EquipmentType)
                    .ToListAsync();
                watch.Stop();
                log.Debug($"Список оборудования получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Equipment> Update(Equipment equipment)
        {
            try
            {
                log.Information($"Редактирование оборудования: {equipment.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Equipments.SingleOrDefaultAsync(b => b.Id == equipment.Id);

                if (updated != null)
                {
                    updated.Name = equipment.Name;
                    updated.InventoryNumber = equipment.InventoryNumber;
                    updated.EquipmentTypeId = equipment.EquipmentTypeId;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Оборудование отредактировано. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
