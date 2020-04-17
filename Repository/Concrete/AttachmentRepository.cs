using Domain;
using Domain.Models;
using Repository.Abstract;
using Serilog;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Repository.Concrete
{
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly ILogger log = new LoggerConfiguration().WriteTo.File("log.txt", rollingInterval: RollingInterval.Day).CreateLogger();
        private readonly ServiceDeskContext context;

        public AttachmentRepository(ServiceDeskContext context)
        {
            this.context = context;
        }
        public async Task<Attachment> Add(Attachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                var inserted = context.Attachments.Add(attachment);
                await context.SaveChangesAsync();
                watch.Stop();
                return inserted;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task Delete(Attachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var deleted = await context.Attachments.SingleOrDefaultAsync(a => a.Id == attachment.Id);
                context.Attachments.Remove(deleted);
                await context.SaveChangesAsync();
                watch.Stop();

            }
            catch (Exception ex)
            {
            }
        }

        public async Task<List<Attachment>> GetAttachments()
        {
            try
            {
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var list = await context.Attachments.ToListAsync();

                watch.Stop();
                return list;

            }
            catch (Exception ex)
            {
                log.Error($"Ошибка получения списка отраслей заявок. Сообщение: {ex.Message}.");
                return null;
            }
        }


        public async Task<Attachment> Update(Attachment attachment)
        {
            try
            {
                Stopwatch watch = new Stopwatch();

                watch.Start();
                var updated = await context.Attachments.SingleOrDefaultAsync(b => b.Id == attachment.Id);

                if (updated != null)
                {
                    updated.Filename = attachment.Filename;
                    updated.DateUploaded = attachment.DateUploaded;
                    updated.Path = attachment.Path;
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