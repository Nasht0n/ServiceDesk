using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels.Requests.IT.Softwares
{
    public class InformationStatusRequestViewModel: RequestViewModel
    {
        [Required]
        [Display(Name = "Адрес сайта")]
        public string URL { get; set; }

        public List<InformationStatusRequestTitleViewModel> TitlesModel { get; set; }
    }
}