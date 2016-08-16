using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using ConsorcioOnline.Models;
using System.Configuration;

namespace ConsorcioOnline.Controllers.mvc
{
    public class AdminController : Controller
    {       
        public ActionResult CartasCredito()
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            Models.Filter filter = new Models.Filter();
            List<StatusCarta> status = new List<StatusCarta>();
            List<CartaCredito> carta = new List<CartaCredito>();
            string strJSON = "";

            try
            {

                request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLStatusCarta"]);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                status = (List<StatusCarta>)formatter.JSONtoClass(sr.ReadToEnd(), new List<StatusCarta>());
                
                ViewData["ListStatus"] = status;

                request.Abort();
                response.Close();
                response.Dispose();
                sr.Close();
                sr.Dispose();

                request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLCarta"],"/list"));

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                filter.IdUser = "";
                filter.StatusCarta = (int)CartaCredito.enStatusCarta.Em_Analise;
                filter.ValorCreditoAte = 0;
                filter.ValorCreditoDe = 0;

                strJSON = formatter.ClasstoJSON(filter);

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                carta = (List<CartaCredito>)formatter.JSONtoClass(sr.ReadToEnd(), new List<CartaCredito>());

                return View(carta);
            }
            catch(Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        [HttpPost]
        public ActionResult CartasCredito(int idStatus)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            Models.Filter filter = new Models.Filter();
            List<StatusCarta> status = new List<StatusCarta>();
            List<CartaCredito> carta = new List<CartaCredito>();
            string strJSON = "";

            try
            {

                request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLStatusCarta"]);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                status = (List<StatusCarta>)formatter.JSONtoClass(sr.ReadToEnd(), new List<StatusCarta>());

                ViewData["ListStatus"] = status;

                request.Abort();
                response.Close();
                response.Dispose();
                sr.Close();
                sr.Dispose();

                request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLCarta"], "/list"));

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                filter.IdUser = "";
                filter.StatusCarta = idStatus;
                filter.ValorCreditoAte = 0;
                filter.ValorCreditoDe = 0;

                strJSON = formatter.ClasstoJSON(filter);

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                carta = (List<CartaCredito>)formatter.JSONtoClass(sr.ReadToEnd(), new List<CartaCredito>());

                return View(carta);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        public ActionResult PropostasCarta(long id)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            List<PropostaCarta> proposta = new List<PropostaCarta>();
            List<StatusProposta> status = new List<StatusProposta>();

            try
            {

                request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLPropostaCarta"], "/list/", id));

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

        public ActionResult CartaStatusTransit(long idCarta, int status)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            string strJSON = "";
            clsJSONFormatter formatter = new clsJSONFormatter();
            CartaCredito carta = new CartaCredito();

            try
            {
                if (ModelState.IsValid)
                {
                    request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLCarta"], "/", idCarta));

                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.Method = "GET";
                    request.KeepAlive = false;

                    response = (HttpWebResponse)request.GetResponse();

                    sr = new StreamReader(response.GetResponseStream());

                    carta = (CartaCredito)formatter.JSONtoClass(sr.ReadToEnd(), new CartaCredito());

                    switch (status)
                    {
                        case (int)CartaCredito.enStatusCarta.Publicada:
                            if (carta.StatusCarta != (int)CartaCredito.enStatusCarta.Em_Analise)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Carta não pode ser Publicada!");
                            }
                            break;
                        case (int)CartaCredito.enStatusCarta.Reprovada:
                            if (carta.StatusCarta != (int)CartaCredito.enStatusCarta.Em_Analise)
                            {
                                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Carta não pode ser Reprovada!");
                            }
                            break;
                    }

                    carta.StatusCarta = status;

                    request.Abort();
                    response.Close();
                    response.Dispose();
                    sr.Close();
                    sr.Dispose();

                    request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLCarta"], "/", idCarta));

                    request.ContentType = "application/json";
                    request.Accept = "application/json";
                    request.Method = "PUT";
                    request.KeepAlive = false;

                    strJSON = formatter.ClasstoJSON(carta);

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

                return RedirectToAction("CartasCredito","Admin",new { area = "" });

            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        public ActionResult PropostaStatusTransit(long idProposta, int status)
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
                    request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLPropostaCarta"], "/", idProposta));

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

                    request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLPropostaCarta"], "/", idProposta));

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

                return RedirectToAction("PropostasCarta",new { id = idProposta});
                
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}