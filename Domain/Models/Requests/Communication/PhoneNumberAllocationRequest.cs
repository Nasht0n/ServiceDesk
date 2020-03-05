using Domain.Abstract;

namespace Domain.Models.Requests.Communication
{
    public class PhoneNumberAllocationRequest:Request
    {
        public string Location { get; set; }
        public int CampusId { get; set; }
        public Campus Campus { get; set; }
    }
}
