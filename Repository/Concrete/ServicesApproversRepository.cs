using Domain;
using Domain.Models.ManyToMany;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    /// <summary>
    /// Класс доступа к хранилищу данных пользователей, имеющих право согласования заявок, закрепленных за определенным видом заявок
    /// </summary>
    public class ServicesApproversRepository : IServicesApproversRepository
    {
        // Логгер
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        // Контекст данных доступа к данным
        private readonly ServiceDeskContext context;
        // Объявление секундомера для получения времени выполнения метода
        private readonly Stopwatch watch = new Stopwatch();
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="context">Контекст данных доступа к данным</param>
        public ServicesApproversRepository(ServiceDeskContext context)
        {
            // инициализация контекста данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления записи закрепления пользователя, имеющего право согласования заявок, за видом заявки
        /// </summary>
        /// <param name="approver">Добавляемая запись закрепления</param>
        /// <returns>Объект пользователя закрепленного за видом заявки, для согласования</returns>
        public async Task<ServicesApprover> AddServicesApprover(ServicesApprover approver)
        {
            log.Debug($"Метод добавления записи закрепления сотрудника, имеющего право согласования заявок, за видом заявки");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.ServicesApprovers.Add(approver);
                log.Debug($"Сохранение изменений.");
                // сохранение изменений
                await context.SaveChangesAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Запись успешно добавлена. Затрачено времени: {watch.Elapsed}.");
                // возвращаем объект прикрепленного файла
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
        /// Метод удаления записи закрепления пользователя за видом заявки, для согласования
        /// </summary>
        /// <param name="approver">Удаляемая запись закрепления</param>
        /// <returns></returns>
        public async Task DeleteServicesApprover(ServicesApprover approver)
        {
            log.Debug($"Метод удаления записи закрепления пользователя за видом заявки, для согласования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.ServicesApprovers.SingleOrDefaultAsync(sa => sa.ServiceId == approver.ServiceId && sa.EmployeeId == approver.EmployeeId);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.ServicesApprovers.Remove(deleted);
                    log.Debug($"Сохранение изменений");
                    // сохранение изменений
                    await context.SaveChangesAsync();
                    // остановка таймера
                    watch.Stop();
                    log.Debug($"Запись успешно удалена. Затрачено времени: {watch.Elapsed}.");
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления записи закрепления пользователя за видом заявки, для согласования: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка пользователей закрепленных за видами заявок для согласования
        /// </summary>
        /// <returns>Возвращает список пользователей закрепленных за видами заявок для согласования</returns>
        public async Task<List<ServicesApprover>> GetServicesApprovers()
        {
            log.Debug($"Метод получения списка пользователей закрепленных за видами заявок для согласования");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.ServicesApprovers
                    .Include(a => a.Employee)
                    .Include(a => a.Employee.Subdivision)
                    .Include(a => a.Service)
                    .Include(a => a.Service.Category)
                    .Include(a => a.Service.Category.Branch)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка приоритетов заявки: {ex.Message}.");
                return null;
            }
        }
    }
}
