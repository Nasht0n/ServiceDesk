using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Accounts
{
    public class AccountCancellationRequest:Request
    {
        public IList<Attachment> Attachments { get; set; }
    }
}
