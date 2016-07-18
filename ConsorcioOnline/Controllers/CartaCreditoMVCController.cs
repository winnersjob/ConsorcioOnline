using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsorcioOnline.Models;
using System.IO;
using System.Configuration;

namespace ConsorcioOnline.Controllers
{
    public class CartaCreditoMVCController : Controller
    {

        //// GET: CartaCreditoMVC
        //public ActionResult Index()
        //{
        //    return View(db.CartaCreditoes.ToList());
        //}

        //// GET: CartaCreditoMVC/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CartaCredito cartaCredito = db.CartaCreditoes.Find(id);
        //    if (cartaCredito == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cartaCredito);
        //}

        // GET: CartaCreditoMVC/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CartaCreditoMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdmConsorcio,TipoConsorcio,Cidade,UF,ValorCredito,ValorEntrata,QtdParcelas,ValorParcela,SaldoCarta,Indexador,Honorarios,TaxaJuros")] CartaCredito cartaCredito)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLCarta"]);
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            MemoryStream ms;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

            if (ModelState.IsValid)
            {
                strJSON = formatter.ClasstoJSON(cartaCredito);

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

        //// GET: CartaCreditoMVC/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CartaCredito cartaCredito = db.CartaCreditoes.Find(id);
        //    if (cartaCredito == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cartaCredito);
        //}

        //// POST: CartaCreditoMVC/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit([Bind(Include = "Id,IdVendedor,AdmConsorcio,TipoConsorcio,StatusCarta,Cidade,UF,ValorCredito,ValorEntrata,QtdParcelas,ValorParcela,SaldoCarta,Indexador,Honorarios,TaxaJuros")] CartaCredito cartaCredito)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(cartaCredito).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(cartaCredito);
        //}

        //// GET: CartaCreditoMVC/Delete/5
        //public ActionResult Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    CartaCredito cartaCredito = db.CartaCreditoes.Find(id);
        //    if (cartaCredito == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(cartaCredito);
        //}

        //// POST: CartaCreditoMVC/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeleteConfirmed(int id)
        //{
        //    CartaCredito cartaCredito = db.CartaCreditoes.Find(id);
        //    db.CartaCreditoes.Remove(cartaCredito);
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
