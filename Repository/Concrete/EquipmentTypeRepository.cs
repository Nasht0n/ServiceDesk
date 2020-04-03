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
    public class EquipmentTypeRepository : IEquipmentTypeRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public EquipmentTypeRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<EquipmentType> Add(EquipmentType equipmentType)
        {
            try
            {
                log.Information($"Добавление типа оборудования: {equipmentType.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.EquipmentTypes.Add(equipmentType);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Тип оборудования добавлен. Затрачено времени: {watch.Elapsed}.");
                return inserted;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления типа оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task Delete(EquipmentType equipmentType)
        {
            try
            {
                log.Information($"Удаление типа оборудования: {equipmentType.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.EquipmentTypes.SingleOrDefaultAsync(a => a.Id == equipmentType.Id);
                context.EquipmentTypes.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Тип оборудования удален. Затрачено времени: {watch.Elapsed}.");
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления типа оборудования. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<EquipmentType>> GetEquipmentTypes()
        {
            try
            {
                log.Information($"Получение списка типов оборудования");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.EquipmentTypes.ToListAsync();
                watch.Stop();
                log.Debug($"Список типов оборудования получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка типов оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<EquipmentType> Update(EquipmentType equipmentType)
        {
            try
            {
                log.Information($"Редактирование типа оборудования: {equipmentType.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.EquipmentTypes.SingleOrDefaultAsync(b => b.Id == equipmentType.Id);

                if (updated != null)
                {
                    updated.Name = equipmentType.Name;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Тип оборудования отредактирован. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования типа оборудования. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
