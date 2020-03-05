using Domain.Abstract;
using System.Collections.Generic;

namespace Domain.Models.Requests.Accounts
{
    public class AccountRegistrationRequest:Request
    {
        public IList<Attachment> Attachments { get; set; }
    }
}
