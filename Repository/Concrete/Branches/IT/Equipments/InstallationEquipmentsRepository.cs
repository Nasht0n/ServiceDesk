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
    /// <summary>
    /// Класс доступа к хранилищу устанавливаемого оборудования
    /// </summary>
    public class InstallationEquipmentsRepository : IInstallationEquipmentsRepository
    {
        // Логгер системы
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        // Контекст данных доступа к данным
        private readonly ServiceDeskContext context;
        // Объявление секундомера для получения времени выполнения метода
        private readonly Stopwatch watch = new Stopwatch();
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст данных доступа к данным</param>
        public InstallationEquipmentsRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи устанавливаемого оборудования
        /// </summary>
        /// <param name="request">Запись устанавливаемого оборудования</param>
        /// <returns>Возвращает объект устанавливаемого оборудования</returns>
        public async Task<InstallationEquipments> Add(InstallationEquipments installation)
        {
            log.Debug($"Метод добавления записи устанавливаемого оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление учетной записи
                var inserted = context.InstallationEquipments.Add(installation);
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно добавлена. Затрачено времени: {watch.Elapsed}.");
                // возврат объекта учетной записи
                return inserted;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления записи: {ex.Message}.");
                // ошибка выполнения метода возвращаем null      
                return null;
            }
        }
        /// <summary>
        /// Метод удаления записи устанавливаемого оборудования
        /// </summary>
        /// <param name="request">Запись устанавливаемого оборудования</param>
        /// <returns></returns>
        public async Task Delete(InstallationEquipments installation)
        {
            log.Debug($"Метод удаления записи устанавливаемого оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.InstallationEquipments.SingleOrDefaultAsync(e => e.Id == installation.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.InstallationEquipments.Remove(deleted);
                    log.Debug($"Сохранение изменений.");
                    // сохранение изменений
                    await context.SaveChangesAsync();
                    // остановка таймера
                    watch.Stop();
                    log.Debug($"Запись успешно удалена. Затрачено времени: {watch.Elapsed}.");
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления записи заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка записей устанавливаемого оборудования
        /// </summary>
        /// <returns>Возвращает список записей устанавливаемого оборудования</returns>
        public async Task<List<InstallationEquipments>> GetEquipments()
        {
            log.Debug($"Метод получения списка записей устанавливаемого оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка записей
                var list = await context.InstallationEquipments
                    .Include(a => a.EquipmentType)
                    .Include(a => a.Request)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка записей устанавливаемого оборудования: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактировния записи устанавливаемого оборудования
        /// </summary>
        /// <param name="request">Запись устанавливаемого оборудования</param>
        /// <returns>Возвращает объект устанавливаемого оборудования</returns>
        public async Task<InstallationEquipments> Update(InstallationEquipments installation)
        {
            log.Debug($"Метод редактировния записи устанавливаемого оборудования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.InstallationEquipments.SingleOrDefaultAsync(e => e.Id == installation.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Count = installation.Count;
                    updated.RequestId = installation.RequestId;
                    updated.EquipmentTypeId = installation.EquipmentTypeId;
                }
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно отредактирована. Затрачено времени: {watch.Elapsed}.");
                // возврат объекта учетной записи
                return updated;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования записи: {ex.Message}.");
                // ошибка выполнения метода возвращаем nul
                return null;
            }
        }
    }
}
