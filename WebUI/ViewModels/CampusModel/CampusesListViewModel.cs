using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.CampusModel
{
    public class CampusesListViewModel
    {
        public List<CampusViewModel> Campuses { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}