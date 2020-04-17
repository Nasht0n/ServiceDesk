using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Abstract
{
    public interface IAttachmentLogic
    {
        Task<Attachment> Save(Attachment attachment);        
        Task Delete(Attachment attachment);
        Task<Attachment> GetAttachment(int id);
        Task<Attachment> GetAttachment(string path);
        Task<List<Attachment>> GetAttachments();
    }
}
