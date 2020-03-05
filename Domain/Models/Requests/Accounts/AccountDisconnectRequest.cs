using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Accounts
{
    public class AccountDisconnectRequest:Request
    {
        public IList<Attachment> Attachments { get; set; }
    }
}
