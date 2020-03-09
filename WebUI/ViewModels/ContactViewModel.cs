using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels
{
    public class ContactViewModel
    {
        [Display(Name = "ФИО пользователя")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Введите ваше ФИО")]
        public string Fullname { get; set; }

        [Display(Name = "Электронная почта")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Введите адрес электронной почты", AllowEmptyStrings = false)]
        public string Email { get; set; }

        [Display(Name = "Текст сообщения")]
        [Required(ErrorMessage = "Введите текст сообщения")]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }
    }
}