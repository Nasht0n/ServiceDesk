using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Abstract
{
    public interface IAttachmentRepository
    {
        Task<Attachment> Add(Attachment attachment);
        Task<Attachment> Update(Attachment attachment);
        Task Delete(Attachment attachment);
        Task<List<Attachment>> GetAttachments();
    }
}
