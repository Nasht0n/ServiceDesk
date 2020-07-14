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
    public class ConsumableTypeRepository : IConsumableTypeRepository
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
        public ConsumableTypeRepository(ServiceDeskContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// Метод добавления типа расходного материала
        /// </summary>
        /// <param name="type">Тип расходного материала</param>
        /// <returns>Возвращает объект расходного материала</returns>
        public async Task<ConsumableType> Add(ConsumableType type)
        {
            log.Debug($"Метод добавления типа расходного материала");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // добавление записи
                var inserted = context.ConsumableTypes.Add(type);
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
        /// Метод удаления типа расходного материала
        /// </summary>
        /// <param name="type">Тип расходного материала</param>
        /// <returns></returns>
        public async Task Delete(ConsumableType type)
        {
            log.Debug($"Метод удаления типа расходного материала");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск удаляемой записи
                var deleted = await context.ConsumableTypes.SingleOrDefaultAsync(a => a.Id == type.Id);
                log.Debug($"Удаляемая запись найдена. Продолжение операции...");
                // если запись найдена
                if (deleted != null)
                {
                    // удаление записи
                    context.ConsumableTypes.Remove(deleted);
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
                log.Error($"Ошибка удаления записи области заявки: {ex.Message}.");
            }
        }
        /// <summary>
        /// Метод получения списка типов расходного материала
        /// </summary>
        /// <returns>Возвращает список типов расходного материала</returns>
        public async Task<List<ConsumableType>> GetConsumableTypes()
        {
            log.Debug($"Метод получения списка типов расходных материалов");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                log.Debug($"Получение списка...");
                // получение списка прикрепленных файлов
                var list = await context.ConsumableTypes.ToListAsync();
                // остановка таймера
                watch.Stop();
                log.Debug($"Операция завершена успешно. Количество элементов списка: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                // возвращаем полученный список
                return list;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка типов расходных материалов: {ex.Message}.");
                return null;
            }
        }
        /// <summary>
        /// Метод редактирования типа расходного материала
        /// </summary>
        /// <param name="type">Тип расходного материала</param>
        /// <returns>Возвращает объект расходного материала</returns>
        public async Task<ConsumableType> Update(ConsumableType type)
        {
            log.Debug($"Метод обновления записи типа расходного материала");
            try
            {
                log.Debug($"Начало выполнения метода.");
                // старт таймера
                watch.Start();
                // поиск обновляемой записи
                var updated = await context.ConsumableTypes.SingleOrDefaultAsync(b => b.Id == type.Id);
                log.Debug($"Запись для редактирования найдена. Продолжение операции...");
                // если запись найдена
                if (updated != null)
                {
                    // обновляем поля объекта
                    updated.Name = type.Name;
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
                // ошибка выполнения метода возвращаем null   
                return null;
            }
        }
    }
}
