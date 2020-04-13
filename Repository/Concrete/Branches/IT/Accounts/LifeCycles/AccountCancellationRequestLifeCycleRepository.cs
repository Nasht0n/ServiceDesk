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
    public class AccountCancellationRequestLifeCycleRepository : IAccountCancellationRequestLifeCycleRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;
        public AccountCancellationRequestLifeCycleRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<AccountCancellationRequestLifeCycle> Add(AccountCancellationRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.AccountCancellationRequestLifeCycles.Add(lifeCycle);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(AccountCancellationRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.AccountCancellationRequestLifeCycles.SingleOrDefaultAsync(e => e.Id == lifeCycle.Id);
                context.AccountCancellationRequestLifeCycles.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<AccountCancellationRequestLifeCycle>> GetLifeCycles()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.AccountCancellationRequestLifeCycles
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

        public async Task<AccountCancellationRequestLifeCycle> Update(AccountCancellationRequestLifeCycle lifeCycle)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.AccountCancellationRequestLifeCycles.SingleOrDefaultAsync(lc => lc.Id == lifeCycle.Id);
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
