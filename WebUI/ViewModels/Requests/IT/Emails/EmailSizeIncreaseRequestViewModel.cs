using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebUI.ViewModels.Requests.IT.Emails
{
    public class EmailSizeIncreaseRequestViewModel:RequestViewModel
    {
        [Required]
        [Display(Name = "Наименование почтового ящика")]
        public string Email { get; set; }

        public SelectList Priorities { get; set; }
    }
}