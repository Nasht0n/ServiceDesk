﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    public class ControlPanelController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}