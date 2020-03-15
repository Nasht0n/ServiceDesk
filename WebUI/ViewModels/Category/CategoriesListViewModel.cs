using System.Collections.Generic;
using System.Web.Mvc;
using WebUI.Models;
using WebUI.ViewModels.Branch;

namespace WebUI.ViewModels.Category
{
    public class CategoriesListViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }

        public int BranchId { get; set; }
        public IEnumerable<SelectListItem> Branches { get; set; }
    }
}