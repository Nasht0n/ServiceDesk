using Domain;
using Domain.Models.ManyToMany;
using Repository.Abstract.Branches.IT.Software.Attachments;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete.Branches.IT.Software.Attachments
{
    public class SoftwareDevelopmentRequestAttachmentsRepository : ISoftwareDevelopmentRequestAttachmentsRepository
    {
        private readonly ServiceDeskContext context;

        public SoftwareDevelopmentRequestAttachmentsRepository(ServiceDeskContext context)
        {
            this.context = context;
        }

        public async Task<SoftwareDevelopmentRequestAttachment> Add(SoftwareDevelopmentRequestAttachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.SoftwareDevelopmentRequestAttachments.Add(attachment);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Delete(SoftwareDevelopmentRequestAttachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var deleted = await context.SoftwareDevelopmentRequestAttachments.SingleOrDefaultAsync(a => a.AttachmentId == attachment.AttachmentId && a.RequestId == attachment.RequestId);
                context.SoftwareDevelopmentRequestAttachments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();
            }
            catch (Exception)
            {
            }
        }

        public async Task<List<SoftwareDevelopmentRequestAttachment>> GetAttachments()
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var list = await context.SoftwareDevelopmentRequestAttachments
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
