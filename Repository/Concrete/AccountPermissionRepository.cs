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
    public class AccountPermissionRepository : IAccountPermissionRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public AccountPermissionRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<AccountPermission> AddAccountPermission(AccountPermission accountPermission)
        {
            try
            {
                //log.Information($"Добавление прав доступа учетной записи: {accountPermission.Permission.ToString()} {accountPermission.Account.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var inserted = context.AccountPermissions.Add(accountPermission);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Право доступа учетной записи добавлено. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления учетной записи. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteAccountPermission(AccountPermission accountPermission)
        {
            try
            {
                log.Information($"Удаление права доступа учетной записи: {accountPermission.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.AccountPermissions.SingleOrDefaultAsync(a => a.PermissionId == accountPermission.PermissionId && a.AccountId == accountPermission.AccountId);
                context.AccountPermissions.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Право доступа учетной записи удалено. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления учетной записи. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<AccountPermission>> GetAccountPermissions()
        {
            try
            {
                log.Information($"Получение списка прав учетных записей.");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.AccountPermissions
                    .Include(a => a.Account)
                    .Include(a => a.Permission)
                    .ToListAsync();
                watch.Stop();
                log.Debug($"Список прав учетных записей получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка прав учетных записей. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
