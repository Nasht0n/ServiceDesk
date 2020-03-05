using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Accounts
{
    public class AccountLossRequest:Request
    {
        public IList<Attachment> Attachments { get; set; }
    }
}
