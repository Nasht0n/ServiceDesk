using Domain;
using Domain.Models.ManyToMany;
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
    public class SubdivisionExecutorsRepository : ISubdivisionExecutorsRepository
    {
        private readonly ServiceDeskContext context;
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

        public SubdivisionExecutorsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<SubdivisionExecutor> AddSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor)
        {
            try
            {
                log.Information($"Закрепление исполнителя за подразделением: {subdivisionExecutor.Employee.ToString()} {subdivisionExecutor.Subdivision.ToString()}");
                Stopwatch watch = new Stopwatch();
                using (var context = new ServiceDeskContext())
                {
                    watch.Start();
                    var inserted = context.SubdivisionExecutors.Add(subdivisionExecutor);
                    await context.SaveChangesAsync();
                    watch.Stop();
                    log.Debug($"Исполнитель закреплен за подразделением. Затрачено времени: {watch.Elapsed}.");
                    return inserted;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка закрепления исполнителя за подразделением. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor)
        {
            try
            {
                log.Information($"Открепление исполнителя от подразделения: {subdivisionExecutor.Employee.ToString()} {subdivisionExecutor.Subdivision.ToString()}");
                Stopwatch watch = new Stopwatch();
                using (var context = new ServiceDeskContext())
                {
                    watch.Start();
                    var deleted = await context.SubdivisionExecutors.SingleOrDefaultAsync(a => a.SubdivisionId == subdivisionExecutor.SubdivisionId && a.EmployeeId == subdivisionExecutor.EmployeeId);
                    context.SubdivisionExecutors.Remove(deleted);
                    await context.SaveChangesAsync();
                    watch.Stop();
                    log.Debug($"Исполнитель откреплен от подразделения. Затрачено времени: {watch.Elapsed}.");
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка открепления исполнителя от подразделения. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<SubdivisionExecutor>> GetSubdivisionExecutors()
        {
            try
            {
                log.Information($"Получение списка исполнителей закрепленных за подразделениями");
                Stopwatch watch = new Stopwatch();
                using (var context = new ServiceDeskContext())
                {
                    watch.Start();
                    var list = await context.SubdivisionExecutors
                        .Include(a => a.Subdivision)
                        .Include(a => a.Employee)
                        .ToListAsync();
                    watch.Stop();
                    log.Debug($"Список исполниетлей закрепленных за подразделениями получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                    return list;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка исполнителей закрепленных за подразделениями. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
