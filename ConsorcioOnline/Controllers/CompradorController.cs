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

        //GET: api/Comprador/{string}
        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            tbComprador readComprador = new tbComprador();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            Comprador comprador = new Comprador();

            try
            {
                readComprador = CRUD.readComprador(id);

                comprador.Id = readComprador.cd_comprador;
                comprador.IdUser = readComprador.id_user;
                comprador.CreatedAt = readComprador.dt_create.ToString();
                comprador.NegativeFeedback = readComprador.nu_qual_negativa;
                comprador.PositiveFeedback = readComprador.nu_qual_positiva;
                comprador.Blocked = readComprador.bt_bloqueado;

                return this.Request.CreateResponse(HttpStatusCode.OK, comprador);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

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
