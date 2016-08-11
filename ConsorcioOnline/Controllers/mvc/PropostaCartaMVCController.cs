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
        public ActionResult Create(long id)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            CartaCredito carta = new CartaCredito();
            PropostaCarta proposta = new PropostaCarta();

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

                proposta.IdCarta = carta.Id;
                proposta.IdVendedor = carta.IdVendedor;

                ViewData["carta-entrada"] = carta.ValorEntrada;
                ViewData["carta-qtdparcela"] = carta.QtdParcelas;
                ViewData["carta-vlrparcela"] = carta.ValorParcela;
                ViewData["carta-taxajuros"] = carta.TaxaJuros;
                ViewData["carta-indexador"] = carta.Indexador;

                return View(proposta);
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
        public ActionResult Create([Bind(Include = "IdCarta,IdVendedor")] PropostaCarta proposta)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";
            

            if (ModelState.IsValid)
            {
                request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLPropostaCarta"]);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                proposta.IdComprador = (long)Session["CompradorID"];
                proposta.StatusProposta = (int)PropostaCarta.enStatusProposta.EmAnalise;
                proposta.MensagemProposta = "";

                strJSON = formatter.ClasstoJSON(proposta);

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();
                
                return RedirectToAction("Index","Home",new { area = ""});
            }

            return View(proposta);
        }

        // POST: PropostaCartaMVC/Index (Get all propostas from carta)
        public ActionResult Index(long? id)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            List<PropostaCarta> proposta = new List<PropostaCarta>();

            try
            {
                if(id == null)
                {
                    return View();
                }

                request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLProposta"], "/emanalise/", id));

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                proposta = (List<PropostaCarta>)formatter.JSONtoClass(sr.ReadToEnd(), new List<PropostaCarta>());

                return View(proposta);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult StatusTransit(long idProposta, int status)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            string strJSON = "";
            clsJSONFormatter formatter = new clsJSONFormatter();
            PropostaCarta proposta = new PropostaCarta();

            try
            {
                if (ModelState.IsValid)
                {
                    request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLProposta"], "/", idProposta));

                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.Method = "GET";
                    request.KeepAlive = false;

                    response = (HttpWebResponse)request.GetResponse();

                    sr = new StreamReader(response.GetResponseStream());

                    proposta = (PropostaCarta)formatter.JSONtoClass(sr.ReadToEnd(), new PropostaCarta());

                    switch (status)
                    {
                        case (int)PropostaCarta.enStatusProposta.Aprovada:
                            if (proposta.StatusProposta != (int)PropostaCarta.enStatusProposta.EmAnalise)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Proposta não pode ser Aprovada!");
                            }
                            break;
                        case (int)PropostaCarta.enStatusProposta.EmTransferencia:
                            if (proposta.StatusProposta != (int)PropostaCarta.enStatusProposta.Aprovada)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Proposta não pode ser Transferida!");
                            }
                            break;
                        case (int)PropostaCarta.enStatusProposta.Concluida:
                            if (proposta.StatusProposta != (int)PropostaCarta.enStatusProposta.EmTransferencia)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Proposta não pode ser Concluida!");
                            }
                            break;
                        case (int)PropostaCarta.enStatusProposta.Cancelada:
                            if (proposta.StatusProposta != (int)PropostaCarta.enStatusProposta.EmAnalise)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Proposta não pode ser Cancelada!");
                            }
                            break;
                    }                    

                    proposta.StatusProposta = status;

                    request.Abort();
                    response.Close();
                    response.Dispose();
                    sr.Close();
                    sr.Dispose();

                    request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLProposta"], "/", idProposta));

                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.Method = "PUT";
                    request.KeepAlive = false;

                    strJSON = formatter.ClasstoJSON(proposta);

                    sw = new StreamWriter(request.GetRequestStream());
                    sw.Write(strJSON);
                    sw.Flush();

                    response = (HttpWebResponse)request.GetResponse();

                    request.Abort();
                    response.Close();
                    response.Dispose();
                    sw.Close();
                    sw.Dispose();

                }

                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }            
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
