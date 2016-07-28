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
    [RoutePrefix("api/comprador")]
    public class CompradorController : ApiController
    {

        // POST: api/Comprador
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Comprador value)
        {
            tbComprador newComprador = new tbComprador();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                newComprador.id_user = value.IdUser;

                CRUD.insertComprador(newComprador);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

        // PUT: api/Comprador/5
        [Route("{id:long}")]
        [HttpPut]
        public HttpResponseMessage Put(long id, [FromBody]Comprador value)
        {
            tbComprador upComprador = new tbComprador();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                upComprador.cd_comprador = id;
                upComprador.id_user = value.IdUser;
                upComprador.nu_qual_negativa = value.NegativeFeedback;
                upComprador.nu_qual_positiva = value.PositiveFeedback;
                upComprador.bt_bloqueado = value.Blocked;

                CRUD.updateComprador(upComprador);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }            
        
        }

    }
}
