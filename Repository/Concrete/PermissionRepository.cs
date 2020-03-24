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
    public class PermissionRepository : IPermissionRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();

        public PermissionRepository()
        {

        }
               
        public async Task<List<Permission>> GetPermissions()
        {
            try
            {
                log.Information($"Получение списка разрешений доступа.");
                Stopwatch watch = new Stopwatch();
                using (var context = new ServiceDeskContext())
                {
                    watch.Start();
                    var list = await context.Permissions.ToListAsync();
                    watch.Stop();
                    log.Debug($"Список разрешений доступа получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                    return list;
                }
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка разрешений доступа. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
