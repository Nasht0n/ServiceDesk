﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebUI.ViewModels.Campus;

namespace WebUI.ViewModels.Requests.IT.Equipments
{
    public class EquipmentRepairRequestViewModel : RequestViewModel
    {
        [Required]
        [Display(Name = "Идентификатор учебного корпуса")]
        public int CampusId { get; set; }
        [Display(Name = "Учебный корпус")]
        public CampusViewModel CampusModel { get; set; }
        [Required]
        [Display(Name = "Инвентарный номер")]
        public string InventoryNumber { get; set; }
        [Required]
        [Display(Name = "Аудитория/Кабинет")]
        public string Location { get; set; }
    }
}