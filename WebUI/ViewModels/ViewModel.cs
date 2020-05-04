using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public abstract class ViewModel
    {
        public bool CanAddRequest { get; set; }
    }
}