using Domain.Abstract;
using System;

namespace Domain.Models.Requests.Communication
{
    public class VideoCommunicationRequest:Request
    {
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
    }
}
