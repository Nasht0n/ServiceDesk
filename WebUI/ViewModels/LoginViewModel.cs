using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels
{
    public class LoginViewModel
    {        
        [Required(ErrorMessage = "Введите логин пользователя")]
        [Display(Name = "Логин пользователя")]
        public string Username { get; set; }
        [Display(Name = "Пароль пользователя")]
        [Required(ErrorMessage = "Введите пароль пользователя")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}