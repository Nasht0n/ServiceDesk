using Domain;
using Domain.Models.Requests.Email;
using Repository.Abstract.Branches.IT.Email.Requests;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Email.Requests
{
    public class EmailSizeIncreaseRequestRepository : IEmailSizeIncreaseRequestRepository
    {
        private readonly ServiceDeskContext context;

        public EmailSizeIncreaseRequestRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<EmailSizeIncreaseRequest> Add(EmailSizeIncreaseRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.EmailSizeIncreaseRequests.Add(request);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(EmailSizeIncreaseRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.EmailSizeIncreaseRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                context.EmailSizeIncreaseRequests.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {

            }
        }

        public async Task<List<EmailSizeIncreaseRequest>> GetRequests()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.EmailSizeIncreaseRequests
                    .Include(a => a.Service)
                    .Include(a => a.Service.Category)
                    .Include(a => a.Service.Category.Branch)
                    .Include(a => a.Status)
                    .Include(a => a.Priority)
                    .Include(a => a.Client)
                    .Include(a => a.Client.Subdivision)
                    .Include(a => a.Executor)
                    .Include(a => a.Executor.Subdivision)
                    .Include(a => a.ExecutorGroup)
                    .Include(a => a.Subdivision)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<EmailSizeIncreaseRequest> Update(EmailSizeIncreaseRequest request)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var updated = await context.EmailSizeIncreaseRequests.SingleOrDefaultAsync(r => r.Id == request.Id);
                if (updated != null)
                {
                    updated.Email = request.Email;
                    updated.Title = request.Title;
                    updated.Justification = request.Justification;
                    updated.Description = request.Description;
                    updated.ServiceId = request.ServiceId;
                    updated.StatusId = request.StatusId;
                    updated.PriorityId = request.PriorityId;
                    updated.ClientId = request.ClientId;
                    updated.ExecutorId = request.ExecutorId;
                    updated.ExecutorGroupId = request.ExecutorGroupId;
                    updated.SubdivisionId = request.SubdivisionId;
                }
                await context.SaveChangesAsync();
                watch.Stop();
                return updated;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
