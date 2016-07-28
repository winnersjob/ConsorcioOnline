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

                return this.Request.CreateResponse(HttpStatusCode.OK);
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