using Domain;
using Domain.Models.ManyToMany;
using Repository.Abstract.Branches.IT.Software.Attachments;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Software.Attachments
{
    public class SoftwareReworkRequestAttachmentsRepository : ISoftwareReworkRequestAttachmentsRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public SoftwareReworkRequestAttachmentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<SoftwareReworkRequestAttachment> Add(SoftwareReworkRequestAttachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.SoftwareReworkRequestAttachments.Add(attachment);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(SoftwareReworkRequestAttachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.SoftwareReworkRequestAttachments.SingleOrDefaultAsync(a => a.AttachmentId == attachment.AttachmentId && a.RequestId == attachment.RequestId);
                context.SoftwareReworkRequestAttachments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {
            }
        }

        public async Task<List<SoftwareReworkRequestAttachment>> GetAttachments()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.SoftwareReworkRequestAttachments
                    .Include(a => a.Attachment)
                    .Include(a => a.Request)
                    .ToListAsync();
                watch.Stop();
                return list;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
