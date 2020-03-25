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
    public class ExecutorGroupMembersRepository : IExecutorGroupMembersRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public ExecutorGroupMembersRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<ExecutorGroupMember> AddExecutorGroupMember(ExecutorGroupMember member)
        {
            try
            {
                log.Information($"Добавление пользователя в группу исполнителей: {member.Employee.ToString()} {member.ExecutorGroup.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.ExecutorGroupMembers.Add(member);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Пользователь добавлен в группу исполнителей. Затрачено времени: {watch.Elapsed}.");
                return inserted;
            }
            catch (Exception ex)
            {
                log.Error($"Ошибка добавления пользователя в группу исполнителей. Сообщение: {ex.Message}.");
                return null;
            }
        }

        public async Task DeleteExecutorGroupMember(ExecutorGroupMember member)
        {
            try
            {
                log.Information($"Удаление пользователя из группы исполнителей: {member.Employee.ToString()} {member.ExecutorGroup.ToString()}");
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.ExecutorGroupMembers.SingleOrDefaultAsync(e => e.EmployeeId == member.EmployeeId && e.ExecutorGroupId == member.ExecutorGroupId);
                context.ExecutorGroupMembers.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
                log.Debug($"Пользователь удален из группы исполнителей. Затрачено времени: {watch.Elapsed}.");

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка удаления пользователя из группы исполнителей. Сообщение: {ex.Message}.");
            }
        }

        public async Task<List<ExecutorGroupMember>> GetGroupMembers()
        {
            try
            {
                log.Information($"Получение списка пользователей в группах исполнителей.");
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.ExecutorGroupMembers
                    .Include(a => a.Employee)
                    .Include(a => a.ExecutorGroup)
                    .ToListAsync();
                watch.Stop();
                log.Debug($"Список прав пользователей в группах исполнителей получен. Количество записей: {list.Count}. Затрачено времени: {watch.Elapsed}.");
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка пользователей в группах исполнителей. Сообщение: {ex.Message}.");
                return null;
            }
        }
    }
}
