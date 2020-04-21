using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebUI.ViewModels.Requests.IT.Emails;

namespace WebUI.ViewModels.LifeCycles.IT.Emails
{
    public class EmailSizeIncreaseRequestLifeCycleViewModel:LifeCycleViewModel
    {
        [Required]
        [Display(Name = "Идентификатор заявки")]
        public int RequestId { get; set; }
        [Required]
        public EmailSizeIncreaseRequestViewModel RequestModel { get; set; }
    }
}