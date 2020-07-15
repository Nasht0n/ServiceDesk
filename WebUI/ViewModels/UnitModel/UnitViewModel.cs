using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.UnitModel
{
    public class UnitViewModel
    {
        [Display(Name = "Идентификатор еденицы измерения")]
        public int Id { get; set; }
        [Display(Name = "Полное наименование еденицы измерения")]
        public string Fullname { get; set; }
        [Display(Name = "Сокращенное наименование еденицы измерения")]
        public string Shortname { get; set; }
    }
}