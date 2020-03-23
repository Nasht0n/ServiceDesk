using System.Collections.Generic;
using WebUI.Models;
using WebUI.ViewModels.Permission;

namespace WebUI.ViewModels.Account
{
    public class AccountListViewModel
    {
        public List<AccountViewModel> AccountModel { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
        public int SubdivisionId { get; set; }
    }
}