using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibConsorcioOnline;
using ConsorcioOnline.Models;

namespace ConsorcioOnline.Controllers
{
    [RoutePrefix("api/statuscarta")]
    public class StatusCartaController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            List<tbStatusCarta> readstatus = new List<tbStatusCarta>();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            List<StatusCarta> liststatus = new List<StatusCarta>();

            try
            {
                readstatus = CRUD.readStatusCarta();

                if (readstatus.Count > 0 )
                {
                    for(int i=0;i< readstatus.Count;i++)
                    {
                        StatusCarta status = new StatusCarta();

                        status.Id = readstatus[i].cd_statuscarta;
                        status.Nome = readstatus[i].de_statuscarta;

                        liststatus.Add(status);

                        status = null;
                    }
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, liststatus);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
