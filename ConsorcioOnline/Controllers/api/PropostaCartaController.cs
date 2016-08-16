using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConsorcioOnline.Models;
using LibConsorcioOnline;

namespace ConsorcioOnline.Controllers
{
    [RoutePrefix("api/propostacarta")]
    public class PropostaCartaController : ApiController
    {

        //// GET: api/PropostaCarta/EmAnalise
        //[Route("~/api/propostacarta/emanalise/{id:long}")]
        //[HttpGet]
        //public HttpResponseMessage GetEmAnalise(long id)
        //{
        //    List<tbPropostaCarta> tpropostas = new List<tbPropostaCarta>();            
        //    List<PropostaCarta> propostas = new List<PropostaCarta>();
        //    clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

        //    try
        //    {
        //        tpropostas = CRUD.readPropostasCarta(id,(int)PropostaCarta.enStatusProposta.EmAnalise);

        //        foreach(tbPropostaCarta item in tpropostas)
        //        {
        //            PropostaCarta pCarta = new PropostaCarta();

        //            pCarta.Id = item.cd_propostacarta;
        //            pCarta.IdCarta = item.cd_cartacredito;
        //            pCarta.IdComprador = item.cd_comprador;
        //            pCarta.IdVendedor = item.cd_vendedor;
        //            pCarta.StatusProposta = item.cd_statusproposta;
        //            pCarta.MensagemProposta = item.de_mensagemproposta;

        //            propostas.Add(pCarta);

        //            pCarta = null;
        //        }

        //        return this.Request.CreateResponse(HttpStatusCode.OK, propostas);
        //    }
        //    catch(Exception ex)
        //    {
        //        return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}

        //// GET: api/PropostaCarta/Aprovada
        //[Route("~/api/propostacarta/aprovada/{id:long}")]
        //[HttpGet]
        //public HttpResponseMessage GetAprovada(long id)
        //{
        //    List<tbPropostaCarta> tpropostas = new List<tbPropostaCarta>();
        //    List<PropostaCarta> propostas = new List<PropostaCarta>();
        //    clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

        //    try
        //    {
        //        tpropostas = CRUD.readPropostasCarta(id, (int)PropostaCarta.enStatusProposta.Aprovada);

        //        foreach (tbPropostaCarta item in tpropostas)
        //        {
        //            PropostaCarta pCarta = new PropostaCarta();

        //            pCarta.Id = item.cd_propostacarta;
        //            pCarta.IdCarta = item.cd_cartacredito;
        //            pCarta.IdComprador = item.cd_comprador;
        //            pCarta.IdVendedor = item.cd_vendedor;
        //            pCarta.StatusProposta = item.cd_statusproposta;
        //            pCarta.MensagemProposta = item.de_mensagemproposta;

        //            propostas.Add(pCarta);

        //            pCarta = null;
        //        }

        //        return this.Request.CreateResponse(HttpStatusCode.OK, propostas);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}

        //// GET: api/PropostaCarta/Aprovada
        //[Route("~/api/propostacarta/emtransferencia/{id:long}")]
        //[HttpGet]
        //public HttpResponseMessage GetEmTransferencia(long id)
        //{
        //    List<tbPropostaCarta> tpropostas = new List<tbPropostaCarta>();
        //    List<PropostaCarta> propostas = new List<PropostaCarta>();
        //    clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

        //    try
        //    {
        //        tpropostas = CRUD.readPropostasCarta(id, (int)PropostaCarta.enStatusProposta.EmTransferencia);

        //        foreach (tbPropostaCarta item in tpropostas)
        //        {
        //            PropostaCarta pCarta = new PropostaCarta();

        //            pCarta.Id = item.cd_propostacarta;
        //            pCarta.IdCarta = item.cd_cartacredito;
        //            pCarta.IdComprador = item.cd_comprador;
        //            pCarta.IdVendedor = item.cd_vendedor;
        //            pCarta.StatusProposta = item.cd_statusproposta;
        //            pCarta.MensagemProposta = item.de_mensagemproposta;

        //            propostas.Add(pCarta);

        //            pCarta = null;
        //        }

        //        return this.Request.CreateResponse(HttpStatusCode.OK, propostas);
        //    }
        //    catch (Exception ex)
        //    {
        //        return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}

        // GET: api/PropostaCarta/list
        [Route("~/api/propostacarta/list/{id:long}")]
        [HttpGet]
        public HttpResponseMessage GetList(long id)
        {
            List<tbPropostaCarta> tpropostas = new List<tbPropostaCarta>();
            List<PropostaCarta> propostas = new List<PropostaCarta>();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                tpropostas = CRUD.readPropostasCarta(id);

                foreach (tbPropostaCarta item in tpropostas)
                {
                    PropostaCarta pCarta = new PropostaCarta();

                    pCarta.Id = item.cd_propostacarta;
                    pCarta.IdCarta = item.cd_cartacredito;
                    pCarta.IdComprador = item.cd_comprador;
                    pCarta.IdVendedor = item.cd_vendedor;
                    pCarta.StatusProposta = item.cd_statusproposta;
                    pCarta.MensagemProposta = item.de_mensagemproposta;

                    propostas.Add(pCarta);

                    pCarta = null;
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, propostas);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        //GET: api/PropostaCarta
        [Route("{id:long}")]
        [HttpGet]
        public HttpResponseMessage Get(long id)
        {
            tbPropostaCarta readProposta = new tbPropostaCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            PropostaCarta proposta = new PropostaCarta();

            try
            {
                readProposta = CRUD.readPropostaCarta(id);

                proposta.Id = readProposta.cd_propostacarta;
                proposta.IdCarta = readProposta.cd_cartacredito;
                proposta.IdComprador = readProposta.cd_comprador;
                proposta.IdVendedor = readProposta.cd_vendedor;
                proposta.MensagemProposta = readProposta.de_mensagemproposta;
                proposta.StatusProposta = readProposta.cd_statusproposta;

                return this.Request.CreateResponse(HttpStatusCode.OK,proposta);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // POST: api/PropostaCarta
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]PropostaCarta value)
        {
            tbPropostaCarta newPropostaCarta = new tbPropostaCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                newPropostaCarta.cd_cartacredito = value.IdCarta;
                newPropostaCarta.cd_comprador = value.IdComprador;
                newPropostaCarta.cd_vendedor = value.IdVendedor;
                newPropostaCarta.de_mensagemproposta = value.MensagemProposta;

                CRUD.insertPropostaCarta(newPropostaCarta);

                return this.Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
            
        }

        // PUT: api/PropostaCarta/5
        [Route("{id:long}")]
        [HttpPut]
        public HttpResponseMessage Put(long id, [FromBody]PropostaCarta value)
        {
            tbPropostaCarta upPropostaCarta = new tbPropostaCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                upPropostaCarta.cd_propostacarta = id;
                upPropostaCarta.cd_cartacredito = value.IdCarta;
                upPropostaCarta.cd_comprador = value.IdComprador;
                upPropostaCarta.cd_vendedor = value.IdVendedor;
                upPropostaCarta.cd_statusproposta = value.StatusProposta;
                upPropostaCarta.de_mensagemproposta = value.MensagemProposta;

                CRUD.updatePropostaCarta(upPropostaCarta);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
            
        }

    }
}