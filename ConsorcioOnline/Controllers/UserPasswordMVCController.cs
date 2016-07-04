using System;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsorcioOnline.Models;
using LibConsorcioOnline;

namespace ConsorcioOnline.Controllers
{
    public class UserPasswordMVCController : Controller
    {        

        //// GET: UserPasswordMVC
        //public ActionResult Index()
        //{
        //    return View(db.UserPasswords.ToList());
        //}

        //// GET: UserPasswordMVC/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserPassword userPassword = db.UserPasswords.Find(id);
        //    if (userPassword == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userPassword);
        //}

        // GET: UserPasswordMVC/Create
        public ActionResult Create()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLUser"], "/", Session["UserID"].ToString()));
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

            if (users == null)
            {
                return HttpNotFound();
            }

            ViewData["UserName"] = users.Nome;

            return View();
        }

        // POST: UserPasswordMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Password,PasswordConfirm,Blocked")] UserPassword userPassword)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLUserPassword"],"/",Session["UserID"].ToString()));
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            MemoryStream ms;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

            if (ModelState.IsValid)
            {
                strJSON = formatter.ClasstoJSON(userPassword);

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

            return RedirectToAction("Details", new { id = Session["UserID"].ToString() });
        }

        // GET: UserPasswordMVC/Edit/5
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

        // POST: UserPasswordMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Password,CreatedAt,UpdatedAt,Blocked")] UserPassword userPassword)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(userPassword).State = EntityState.Modified;
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userPassword);
        }

        //// GET: UserPasswordMVC/Delete/5
        //public ActionResult Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    UserPassword userPassword = db.UserPasswords.Find(id);
        //    if (userPassword == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(userPassword);
        //}

        //// POST: UserPasswordMVC/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(string id)
        //{
        //    UserPassword userPassword = db.UserPasswords.Find(id);
        //    db.UserPasswords.Remove(userPassword);
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
