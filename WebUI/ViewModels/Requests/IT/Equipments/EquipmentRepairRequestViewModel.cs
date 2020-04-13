﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.ViewModels.CampusModel;

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

        public int? SelectedPriority { get; set; }
        public SelectList Priorities { get; set; }

        public int? SelectedCampus { get; set; }
        public SelectList Campuses { get; set; }

        public int? SelectedEquipmentType { get; set; }
        public SelectList EquipmentTypes { get; set; }
    }
}