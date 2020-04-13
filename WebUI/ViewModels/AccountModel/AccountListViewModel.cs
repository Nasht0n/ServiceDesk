using System.Collections.Generic;
using WebUI.Models;

namespace WebUI.ViewModels.AccountModel
{
    public class AccountListViewModel
    {
        public List<AccountViewModel> AccountModel { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Search { get; set; }
    }
}