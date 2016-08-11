using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsorcioOnline.Controllers.mvc
{
    public class AdminController : Controller
    {       
        public ActionResult CartasCredito()
        {
            return View();
        }

        public ActionResult PropostasCarta()
        {
            return View();
        }
    }
}