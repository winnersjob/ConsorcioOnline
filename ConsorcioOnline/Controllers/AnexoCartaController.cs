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
    [RoutePrefix("api/anexocarta")]
    public class AnexoCartaController : ApiController
    {

        // POST: api/AnexoCarta
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]AnexoCarta value)
        {
            tbAnexoCarta newAnexo = new tbAnexoCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                newAnexo.cd_cartacredito = value.IdCarta;
                newAnexo.de_linkanexo = value.LinkAnexo;

                CRUD.insertAnexoCarta(newAnexo);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
            
        }

        // PUT: api/AnexoCarta/5
        [Route("api/anexocarta/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]AnexoCarta value)
        {
            tbAnexoCarta upAnexo = new tbAnexoCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                upAnexo.id_anexo = id;
                upAnexo.cd_cartacredito = value.IdCarta;
                upAnexo.de_linkanexo = value.LinkAnexo;

                CRUD.updateAnexoCarta(upAnexo);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

    }
}
