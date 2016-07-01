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

        //// GET: UsersMVC
        //public ActionResult Index()
        //{
        //    return View(db.Users.ToList());
        //}

        // GET: UsersMVC/Details/5

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
        public ActionResult Create([Bind(Include = "Nome,Apelido,FisJur,CPF,CNPJ,IE")] Users users)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLUser"]);
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            MemoryStream ms;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

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

                return RedirectToAction("Details", new { id = Session["UserID"].ToString() });
            }

            return RedirectToAction("Home", "Index");
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

        //// GET: UsersMVC/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Users users = db.Users.Find(id);
        //    if (users == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(users);
        //}

        //// POST: UsersMVC/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    Users users = db.Users.Find(id);
        //    db.Users.Remove(users);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}

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
