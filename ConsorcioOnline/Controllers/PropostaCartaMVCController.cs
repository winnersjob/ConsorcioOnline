using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;
using ConsorcioOnline.Models;
using System.Configuration;

namespace ConsorcioOnline.Controllers
{
    public class PropostaCartaMVCController : Controller
    {
        
        // GET: PropostaCartaMVC/Create
        public ActionResult Create(long idProposta)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            CartaCredito carta = new CartaCredito();

            try
            {
                request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLCarta"], "/", idProposta));

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                carta = (CartaCredito)formatter.JSONtoClass(sr.ReadToEnd(), new CartaCredito());

                return View(carta);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // POST: PropostaCartaMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdCarta,IdVendedor,IdComprador,StatusProposta,MensagemProposta")] PropostaCarta propostaCarta)
        {
            if (ModelState.IsValid)
            {
                //db.PropostaCartas.Add(propostaCarta);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propostaCarta);
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
