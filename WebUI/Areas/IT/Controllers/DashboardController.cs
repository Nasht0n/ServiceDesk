using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.IT.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Requests()
        {
            return View();
        }
    }
}