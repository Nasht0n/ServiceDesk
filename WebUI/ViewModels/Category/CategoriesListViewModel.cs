using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.Category
{
    public class CategoriesListViewModel
    {
        public List<CategoryViewModel> Categories { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
        public int BranchId { get; set; }
    }
}