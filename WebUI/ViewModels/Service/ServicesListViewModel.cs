using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.ViewModels.Service
{
    public class ServicesListViewModel
    {
        public List<ServiceViewModel> Services { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }

        [Display(Name = "Отрасль заявки")]
        public int SelectedBranch { get; set; }
        [Display(Name = "Категория заявки")]
        public int SelectedCategory { get; set; }
        public SelectList BranchList { get; set; }
        public SelectList CategoryList { get; set; }
    }
}