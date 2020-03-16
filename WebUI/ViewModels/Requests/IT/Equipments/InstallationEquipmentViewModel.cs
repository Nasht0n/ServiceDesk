using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.EquipmentType;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class InstallationEquipmentViewModel
    {
        [Required]
        [Display(Name = "Идентификатор устанавливаемого оборудования")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Количество оборудования (шт.)")]
        public int Count { get; set; }
        [Required]
        [Display(Name = "Идентификатор заявки на установку оборудования")]
        public int RequestId { get; set; }
        [Display(Name = "Заявка на установку оборудования")]
        public EquipmentInstallationRequestViewModel RequestModel { get; set; }
        [Required]
        [Display(Name = "Идентификатор типа оборудования")]
        public int EquipmentTypeId { get; set; }
        [Display(Name = "Тип оборудования")]
        public EquipmentTypeViewModel EquipmentTypeModel { get; set; }
    }
}