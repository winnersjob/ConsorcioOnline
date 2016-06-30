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

        public string Id { get; set; }

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

            Id = id;

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
        public ActionResult Create([Bind(Include = "Id,Nome,Apelido,FisJur,CPF,CNPJ,IE,Blocked")] Users users)
        {
            if (ModelState.IsValid)
            {
                //db.Users.Add(users);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
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

        //// POST: UsersMVC/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,Nome,Apelido,FisJur,CPF,CNPJ,IE,Blocked")] Users users)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(users).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(users);
        //}

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
