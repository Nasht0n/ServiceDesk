using Domain;
using Domain.Models.ManyToMany;
using Repository.Abstract.Branches.IT.Accounts.Attachments;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Accounts.Attachments
{
    public class AccountLossRequestAttachmentsRepository : IAccountLossRequestAttachmentsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;
        public AccountLossRequestAttachmentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<AccountLossRequestAttachment> Add(AccountLossRequestAttachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.AccountLossRequestAttachments.Add(attachment);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(AccountLossRequestAttachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.AccountLossRequestAttachments.SingleOrDefaultAsync(a => a.AttachmentId == attachment.AttachmentId && a.RequestId == attachment.RequestId);
                context.AccountLossRequestAttachments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception ex)
            {
            }
        }

        public async Task<List<AccountLossRequestAttachment>> GetAttachments()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.AccountLossRequestAttachments
                    .Include(a => a.Attachment)
                    .Include(a => a.Request)
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
