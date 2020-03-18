using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Permission
{
    public class PermissionViewModel
    {
        [Required]
        [Display(Name = "Идентификатор права доступа")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Заголовок права доступа")]
        public string Title { get; set; }
    }
}