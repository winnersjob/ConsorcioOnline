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
    [RoutePrefix("api/vendedor")]
    public class VendedorController : ApiController
    {

        // POST: api/Vendedor
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Vendedor value)
        {
            tbVendedor newVendedor = new tbVendedor();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                newVendedor.id_user = value.IdUser;

                CRUD.insertVendedor(newVendedor);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
                        
        }

        // PUT: api/Vendedor/5
        [Route("{id:long}")]
        [HttpPut]
        public HttpResponseMessage Put(long id, [FromBody]Vendedor value)
        {
            tbVendedor upVendedor = new tbVendedor();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                upVendedor.cd_vendedor = id;
                upVendedor.id_user = value.IdUser;
                upVendedor.nu_qual_negativa = value.NegativeFeedback;
                upVendedor.nu_qual_positiva = value.PositiveFeedback;
                upVendedor.bt_bloqueado = value.Blocked;

                CRUD.updateVendedor(upVendedor);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
                        
        }

    }
}