using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public AccountRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<Account> AddAccount(Account account)
        {
            try
            {
                log.Information($"Добавление учетной записи: {account.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Accounts.Add(account);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Учетная запись добавлена. Затрачено времени: {watch.Elapsed}.");
                return inserted;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления учетной записи. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteAccount(Account account)
        {
            try
            {
                log.Information($"Удаление учетной записи: {account.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Accounts.SingleOrDefaultAsync(a => a.Id == account.Id);
                context.Accounts.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Учетная запись удалена. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления учетной записи. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<Account>> GetAccounts()
        {
            try
            {
                log.Information($"Получение списка учетных записей.");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Accounts
                    .Include(a=>a.Employee)
                    .Include(a=>a.Employee.Subdivision)
                    .Include(a=>a.Employee.ApprovalServices.Select(s=>s.Service))
                    .Include(a => a.Employee.ExecutorGroups.Select(e=>e.ExecutorGroup))
                    .Include(a=>a.Permissions.Select(p=>p.Permission))
                    .ToListAsync();

                watch.Stop();
                log.Debug($"Список учетных записей получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка учетных записей. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task<Account> UpdateAccount(Account account)
        {
            try
            {
                log.Information($"Редактирование учетной записи: {account.ToString()}");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Accounts.SingleOrDefaultAsync(a => a.Id == account.Id);

                if (updated != null)
                {
                    updated.Username = account.Username;
                    updated.Password = account.Password;
                    updated.DateRegistration = account.DateRegistration;
                    updated.DateChangePassword = account.DateChangePassword;
                    updated.LastEnterDateTime = account.LastEnterDateTime;
                    updated.IsEnabled = account.IsEnabled;
                    updated.ChangePasswordOnNextEnter = account.ChangePasswordOnNextEnter;
                    updated.EmployeeId = account.EmployeeId;
                }

                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Учетная запись отредактирована. Затрачено времени: {watch.Elapsed}.");
                return updated;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка редактирования учетной записи. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
