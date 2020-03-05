using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Software
{
    public class SoftwareDevelopmentRequest:Request
    {
        public IList<Attachment> Attachments { get; set; }
    }
}
