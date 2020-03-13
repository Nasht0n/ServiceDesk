using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.ExecutorGroup
{
    public class ExecutorGroupViewModel
    {
        [Required]
        [Display(Name = "Идентификатор группы исполнителей")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Укажите наименование группы исполнителей")]
        [Display(Name = "Наименование группы исполнителей")]
        public string Name { get; set; }
    }
}