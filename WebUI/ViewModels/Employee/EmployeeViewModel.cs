using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.Subdivision;

namespace WebUI.ViewModels.Employee
{
    public class EmployeeViewModel
    {
        [Required]
        [Display(Name = "Идентификатор сотрудника")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите фамилию сотрудника")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Введите имя сотрудника")]
        [Display(Name = "Имя")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Введите отчество сотрудника")]
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        public string Fullname
        {
            get
            {
                return $"{Surname} {Firstname} {Patronymic}";
            }
        }
        [Required(ErrorMessage = "Введите должность сотрудника")]
        [Display(Name = "Должность")]
        public string Post { get; set; }
        [Display(Name = "Электронная почта")]
        public string Email { get; set; }
        [Display(Name = "Телефон")]
        public string Phone { get; set; }
        [Display(Name = "Сотрудник начальник подразделения?")]
        public bool HeadOfUnit { get; set; }

        [Display(Name = "Идентификатор подразделения")]
        public int? SelectedSubdivision { get; set; }
        [Display(Name = "Подразделение")]
        public SubdivisionViewModel SubdivisionModel { get; set; }
        public SelectList Subdivisions { get; set; }
    }
}