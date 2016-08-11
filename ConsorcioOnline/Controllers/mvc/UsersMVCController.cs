using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Runtime.Serialization;
using System.IO;
using LibConsorcioOnline;
using ConsorcioOnline.Models;

namespace ConsorcioOnline.Controllers
{
    public class UsersMVCController : Controller
    {

        // GET: UsersMVC/Details/xxxxxx
        public ActionResult Details(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLUser"],"/",id));
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            Users users;

            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Method = "GET";
            request.KeepAlive = false;

            response = (HttpWebResponse)request.GetResponse();
            sr = new StreamReader(response.GetResponseStream());

            users = (Users)formatter.JSONtoClass(sr.ReadToEnd(), new Users());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }

        // GET: UsersMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserName,Nome,Apelido,FisJur,CPF,CNPJ,IE")] Users users)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLUser"]);
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";
            Vendedor vendedor;
            Comprador comprador;

            if (ModelState.IsValid)
            {
                strJSON = formatter.ClasstoJSON(users);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();
                sr = new StreamReader(response.GetResponseStream());
                users = (Users)formatter.JSONtoClass(sr.ReadToEnd(), new Users());

                request.Abort();
                response.Close();
                response.Dispose();
                sw.Close();
                sw.Dispose();
                sr.Close();
                sr.Dispose();

                request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLVendedor"]);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                vendedor = new Vendedor();
                vendedor.IdUser = users.Id;

                strJSON = formatter.ClasstoJSON(vendedor);

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                request.Abort();
                response.Close();
                response.Dispose();
                sw.Close();
                sw.Dispose();

                request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLComprador"]);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                comprador = new Comprador();
                comprador.IdUser = users.Id;

                strJSON = formatter.ClasstoJSON(comprador);

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                return RedirectToAction("Create", "UserPasswordMVC",new { id = users.Id});
            }

            return RedirectToAction("Create", "UserPasswordMVC");
        }

        // GET: UsersMVC/Edit/5
        public ActionResult Edit(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLUser"], "/", id));
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            Users users;

            request.ContentType = "application/json";
            request.Accept = "application/json";
            request.Method = "GET";
            request.KeepAlive = false;

            response = (HttpWebResponse)request.GetResponse();
            sr = new StreamReader(response.GetResponseStream());

            users = (Users)formatter.JSONtoClass(sr.ReadToEnd(), new Users());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: UsersMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Nome,Apelido,FisJur,CPF,CNPJ,IE")] Users users)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLUser"], "/", Session["UserID"].ToString()));
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            MemoryStream ms;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

            if (ModelState.IsValid)
            {
                users.Id = Session["UserID"].ToString();

                strJSON = formatter.ClasstoJSON(users);
                
                request.ContentType = "application/json"    ;
                request.Accept = "application/json";
                request.Method = "PUT";
                request.KeepAlive = false;

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                return RedirectToAction("Details", new { id = Session["UserID"].ToString() });
            }
            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
