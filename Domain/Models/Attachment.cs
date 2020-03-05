using Domain.Models.Requests.Accounts;
using Domain.Models.Requests.Software;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Attachment
    {
        public int Id { get; set; }
        public string Filename { get; set; }
        public DateTime DateUploaded { get; set; }
        public string Path { get; set; }

        public IList<SoftwareDevelopmentRequest> SoftwareDevelopmentRequests { get; set; }
        public IList<SoftwareReworkRequest> SoftwareReworkRequests { get; set; }

        public IList<AccountCancellationRequest> AccountCancellationRequests { get; set; }
        public IList<AccountDisconnectRequest> AccountDisconnectRequests { get; set; }
        public IList<AccountLossRequest> AccountLossRequests { get; set; }
        public IList<AccountRegistrationRequest> AccountRegistrationRequests { get; set; }
    }
}
