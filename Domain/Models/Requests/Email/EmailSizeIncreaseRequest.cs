using Domain.Abstract;

namespace Domain.Models.Requests.Email
{
    public class EmailSizeIncreaseRequest:Request
    {
        public string Email { get; set; }
    }
}
