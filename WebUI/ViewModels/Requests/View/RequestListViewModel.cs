using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WebUI.Models;

namespace WebUI.ViewModels.Requests.View
{
    public class RequestListViewModel: DashboardConfigurationViewModel
    {
        public List<RequestViewModel> RequestsModel { get; set; }

        public int? CurrentService { get; set; }
        public int? CurrentStatus { get; set; }
        [Display(Name = "Начало периода")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Display(Name = "Окончание периода")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}