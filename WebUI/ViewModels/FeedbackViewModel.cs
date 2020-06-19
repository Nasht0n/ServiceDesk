using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels
{
    public class FeedbackViewModel:DashboardConfigurationViewModel
    {
        [Required]
        [MaxLength(150)]
        [DisplayName("Введите ваше имя:")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        [DisplayName("Введите сообщение:")]
        public string Message { get; set; }
    }
}