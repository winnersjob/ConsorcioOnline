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
        [HttpGet]
        [AcceptVerbs(HttpVerbs.Get)]
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLLogin"]);
            HttpWebResponse response;
            StreamWriter sw;
            StreamReader sr;
            string strJSON = "";
            clsJSONFormatter formatter = new clsJSONFormatter();


            try
            {
                            
                if(ModelState.IsValid)
                {
                    strJSON = formatter.ClasstoJSON(login);

                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.Method = "POST";
                    request.KeepAlive = false;

                    sw = new StreamWriter(request.GetRequestStream());
                    sw.Write(strJSON);
                    sw.Flush();

                    response = (HttpWebResponse)request.GetResponse();
                    sr = new StreamReader(response.GetResponseStream());

                    if (Session["LoginUser"] != null)
                    {
                        Session.Remove("LoginUser");
                    }

                    login = (LoginUser)formatter.JSONtoClass(sr.ReadToEnd(), new LoginUser());
                    login.Password = "";

                    Session.Add("LoginUser", login.Id);
                
                }

                return RedirectToAction("Index", "Home", new { area = "" });
            }
            catch
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }

        }

        public ActionResult LogOut()
        {
            if(Session["LoginUser"] != null)
            {
                Session.Remove("LoginUser");                
            }

            return RedirectToAction("Index", "Home", new { area = "" });
        }

    }
}
