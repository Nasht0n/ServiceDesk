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
    public class SubdivisionExecutorsRepository : ISubdivisionExecutorsRepository
    {
        private readonly ServiceDeskContext context;
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly Stopwatch watch = new Stopwatch();

        public SubdivisionExecutorsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<SubdivisionExecutor> AddSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor)
        {
            try
            {
                watch.Start();
                var inserted = context.SubdivisionExecutors.Add(subdivisionExecutor);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task DeleteSubdivisionExecutor(SubdivisionExecutor subdivisionExecutor)
        {
            try
            {
                watch.Start();
                var deleted = await context.SubdivisionExecutors.SingleOrDefaultAsync(a => a.SubdivisionId == subdivisionExecutor.SubdivisionId && a.EmployeeId == subdivisionExecutor.EmployeeId);
                context.SubdivisionExecutors.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<List<SubdivisionExecutor>> GetSubdivisionExecutors()
        {
            try
            {
                watch.Start();
                var list = await context.SubdivisionExecutors
                    .Include(a => a.Subdivision)
                    .Include(a => a.Employee)
                    .Include(a => a.Employee.Subdivision)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
