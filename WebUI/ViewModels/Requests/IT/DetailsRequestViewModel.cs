using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Requests.IT
{
    public abstract class DetailsRequestViewModel: DashboardConfigurationViewModel
    {
        [Display(Name = "Сообщение жизненного цикла")]
        public string Message { get; set; }

        // Пользователь имеет права на согласование заявок
        public bool IsApprovers { get; set; }
        // Пользователь имеет права на исполнитель
        public bool IsExecutor { get; set; }
        // Пользователь создатель заявки
        public bool IsClient { get; set; }
        // Заявка прошла полное согласование
        public bool AllApproval { get; set; }
    }
}