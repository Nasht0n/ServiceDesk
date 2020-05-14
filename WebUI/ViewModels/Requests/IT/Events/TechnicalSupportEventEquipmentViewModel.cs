using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels.Requests.IT.Events
{
    public class TechnicalSupportEventEquipmentViewModel
    {
        [Display(Name = "Идентификатор оборудования для мероприятия")]
        public int Id { get; set; }
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Display(Name = "Заявка на техническое обеспечение мероприятия")]
        public TechnicalSupportEventRequestViewModel RequestModel { get; set; }
        [Display(Name = "Наименование требуемого оборудования")]
        public string Equipment { get; set; }
        [Display(Name = "Количество")]
        public int Count { get; set; }
    }
}