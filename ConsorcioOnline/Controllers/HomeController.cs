using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Configuration;
using ConsorcioOnline.Models;

namespace ConsorcioOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include ="ValorCreditoDe,ValorCreditoAte")] ConsorcioOnline.Models.Filter filter)
        {
            if(Session["Filters"] == null)
            {
                Session.Add("Filters", filter);
            }
            else
            {
                Session["Filters"] = filter;
            }

            return RedirectToAction("Index","CartaCreditoMVC",new { area = "" });
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include ="Username, Password")] LoginUser login)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLUser"]);
            HttpWebResponse response;
            StreamWriter sw;
            StreamReader sr;
            string strJSON = "";
            clsJSONFormatter formatter = new clsJSONFormatter();

            if(ModelState.IsValid)
            {
                strJSON = formatter.ClasstoJSON(login);

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();
                sr = new StreamReader(response.GetResponseStream());

                if (Session["LoginUser"] != null)
                {
                    Session.Remove("LoginUser");
                }
                
                Session.Add("LoginUser", (LoginUser)formatter.JSONtoClass(sr.ReadToEnd(),new LoginUser()));
                
            }

            return RedirectToAction("Index", "Home");

        }

    }
}
