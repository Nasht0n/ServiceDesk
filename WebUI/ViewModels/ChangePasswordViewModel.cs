using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [Display(Name = "Идентификатор аккаунта пользователя")]
        
        public int AccountId { get; set; }
        [Required(ErrorMessage = "Введите старый пароль пользователя")]
        [Display(Name = "Старый пароль пользователя")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Введите новый пароль пользователя")]
        [Display(Name = "Новый пароль пользователя")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Повторите новый пароль пользователя")]
        [Display(Name = "Новый пароль пользователя, еще раз")]
        [DataType(DataType.Password)]
        public string RepeatNewPassword { get; set; }
    }
}