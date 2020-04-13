using Domain;
using Domain.Models.Requests.Accounts;
using Repository.Abstract.Branches.IT.Accounts.LifeCycles;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Accounts.LifeCycles
{
    public class AccountDisconnectRequestLifeCycleRepository : IAccountDisconnectRequestLifeCycleRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;
        public AccountDisconnectRequestLifeCycleRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<AccountDisconnectRequestLifeCycle> Add(AccountDisconnectRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.AccountDisconnectRequestLifeCycles.Add(lifeCycle);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(AccountDisconnectRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.AccountDisconnectRequestLifeCycles.SingleOrDefaultAsync(e => e.Id == lifeCycle.Id);
                context.AccountDisconnectRequestLifeCycles.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<AccountDisconnectRequestLifeCycle>> GetLifeCycles()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.AccountDisconnectRequestLifeCycles
                    .Include(a => a.Request)
                    .Include(a => a.Employee)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<AccountDisconnectRequestLifeCycle> Update(AccountDisconnectRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.AccountDisconnectRequestLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
                if (updated != null)
                {
                    updated.Date = lifeCycle.Date;
                    updated.EmployeeId = lifeCycle.EmployeeId;
                    updated.Message = lifeCycle.Message;
                    updated.RequestId = lifeCycle.RequestId;
                }
                await context.SaveChangesAsync();
                watch.Stop();
                return updated;

            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
