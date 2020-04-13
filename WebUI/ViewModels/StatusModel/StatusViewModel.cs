using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.StatusModel
{
    public class StatusViewModel
    {
        [Required]
        [Display(Name = "Идентификатор статуса заявки")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Наименование статуса заявки")]
        public string Fullname { get; set; }
        [Required]
        [Display(Name = "Краткое наименование статуса заявки")]
        public string Shortname { get; set; }
    }
}