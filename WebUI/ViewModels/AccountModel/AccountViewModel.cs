using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.EmployeeModel;
using WebUI.ViewModels.PermissionModel;

namespace WebUI.ViewModels.AccountModel
{
    public class AccountViewModel
    {
        [Required]
        [Display(Name = "Идентификатор учетной записи")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Логин учетной записи")]
        public string Username { get; set; }
        [Required]
        [Display(Name = "Пароль учетной записи")]
        public string Password { get; set; }
        [Required]
        [Display(Name = "Дата регистрации учетной записи")]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [Display(Name = "Дата изменения пароля учетной записи")]
        public DateTime ChangePasswordDate { get; set; }
        [Required]
        [Display(Name = "Дата последнего входа в систему")]
        public DateTime LastEnterDateTime { get; set; }
        [Required]
        [Display(Name = "Учетная запись активна?")]
        public bool IsEnabled { get; set; }
        [Required]
        [Display(Name = "Сменить пароль при следующем входе в систему")]
        public bool ChangePasswordOnNextEnter { get; set; }  
        [Display(Name = "Сотрудник")]
        public EmployeeViewModel EmployeeModel { get; set; }
        [Display(Name = "Список прав доступа")]
        public List<PermissionViewModel> Permissions { get; set; }
    }
}