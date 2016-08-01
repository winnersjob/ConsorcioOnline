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

        // GET: CartaCreditoMVC
        public ActionResult Index(string id = "")
        {
            Models.Filter filter = new Models.Filter();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLCarta"],"/List"));
            HttpWebResponse response;
            StreamWriter sw;
            StreamReader sr;
            string strJSON = "";
            clsJSONFormatter formatter = new clsJSONFormatter();
            List<CartaCredito> carta = new List<CartaCredito>();

            if (Session["Filters"] != null || id != "")
            {
                if(Session["Filters"]==null)
                {
                    filter.IdUser = id;
                    Session.Add("Filters",filter);
                }

                filter = (Models.Filter)Session["Filters"];

                strJSON = formatter.ClasstoJSON(filter);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();
                sr = new StreamReader(response.GetResponseStream());

                carta = (List<CartaCredito>)formatter.JSONtoClass(sr.ReadToEnd(), new List<CartaCredito>());

            }

            return View(carta);
        }

        // GET: CartaCreditoMVC/Details/5
        public ActionResult Details(long id)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            CartaCredito carta = new CartaCredito();

            try
            {                
                request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLCarta"], "/", id));

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                carta = (CartaCredito)formatter.JSONtoClass(sr.ReadToEnd(), new CartaCredito());

                return View(carta);
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest,ex.Message);
            }

        }

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
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;            
            clsJSONFormatter formatter = new clsJSONFormatter();
            Vendedor vendedor = new Vendedor();
            string strJSON = "";

            if (ModelState.IsValid)
            {

                request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLVendedor"], "/", Session["LoginUser"]));

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                vendedor = (Vendedor)formatter.JSONtoClass(sr.ReadToEnd(), new Vendedor());

                cartaCredito.IdVendedor = vendedor.Id;
                cartaCredito.StatusCarta = (int)CartaCredito.enStatusCarta.Em_Analise;

                request.Abort();
                response.Close();
                response.Dispose();
                sr.Close();
                sr.Dispose();

                request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLCarta"]);

                strJSON = formatter.ClasstoJSON(cartaCredito);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                return RedirectToAction("Details", new { id = Session["LoginUser"].ToString() });
            }

            return RedirectToAction("Home", "Index");
        }

        // GET: CartaCreditoMVC/Edit/5
        public ActionResult Edit(long id)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            CartaCredito carta;

            try
            {
                request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLCarta"], "/", id));

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                carta = (CartaCredito)formatter.JSONtoClass(sr.ReadToEnd(), new CartaCredito());

                return View(carta);
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }           
            
        }

        // POST: CartaCreditoMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdVendedor,AdmConsorcio,TipoConsorcio,StatusCarta,Cidade,UF,ValorCredito,ValorEntrata,QtdParcelas,ValorParcela,SaldoCarta,Indexador,Honorarios,TaxaJuros")] CartaCredito cartaCredito)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            Vendedor vendedor = new Vendedor();
            string strJSON = "";

            if (ModelState.IsValid)
            {
                request = (HttpWebRequest)WebRequest.Create(String.Concat( ConfigurationSettings.AppSettings["URLCarta"],"/",cartaCredito.Id));

                strJSON = formatter.ClasstoJSON(cartaCredito);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "PUT";
                request.KeepAlive = false;

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                return RedirectToAction("Index");
            }
            return View(cartaCredito);
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
