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
    /// Класс доступа к хранилищу сотрудников групп исполнителей
    /// </summary>
    public class ExecutorGroupMembersRepository : IExecutorGroupMembersRepository
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
        public ExecutorGroupMembersRepository(ServiceDeskContext context)
        {
            // инициализация контекст данных
            this.context = context;
        }
        /// <summary>
        /// Метод добавления сотрудника в группу исполнителей
        /// </summary>
        /// <param name="member">Данные о сотруднике и группе исполнителей</param>
        /// <returns>Возвращает добавленную запись сотрудника в группу исполнителей</returns>
        public async Task<ExecutorGroupMember> AddExecutorGroupMember(ExecutorGroupMember member)
        {
            log.Debug($"Метод добавления сотрудника в группу исполнителей");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.ExecutorGroupMembers.Add(member);
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
        /// Метод удаления сотрудника из группы исполнителей
        /// </summary>
        /// <param name="member">Данные о сотруднике и группе исполнителей</param>
        /// <returns></returns>
        public async Task DeleteExecutorGroupMember(ExecutorGroupMember member)
        {
            log.Debug($"Метод удаления сотрудника из группы исполнителей");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.ExecutorGroupMembers.SingleOrDefaultAsync(e => e.EmployeeId == member.EmployeeId && e.ExecutorGroupId == member.ExecutorGroupId);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.ExecutorGroupMembers.Remove(deleted);
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
                log.Error($"Ошибка удаления записи типа оборудования: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка сотрудников в группах исполнителей
        /// </summary>
        /// <returns>Возвращает список сотрудников в группах исполнителей</returns>
        public async Task<List<ExecutorGroupMember>> GetGroupMembers()
        {
            log.Debug($"Метод получения списка сотрудников в группах исполнителей");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.ExecutorGroupMembers
                    .Include(a => a.Employee)
                    .Include(a => a.Employee.Subdivision)
                    .Include(a => a.ExecutorGroup)
                    .ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка сотрудников в группах исполнителей: {ex.Message}.");
                return null;
            }
        }
    }
}
