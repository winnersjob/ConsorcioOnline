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
    [RoutePrefix("api/statusproposta")]
    public class StatusPropostaController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            List<tbStatusProposta> readstatus = new List<tbStatusProposta>();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            List<StatusProposta> liststatus = new List<StatusProposta>();

            try
            {
                readstatus = CRUD.readStatusProposta();

                if (readstatus.Count > 0)
                {
                    for (int i = 0; i < readstatus.Count; i++)
                    {
                        StatusProposta status = new StatusProposta();

                        status.Id = readstatus[i].cd_statusproposta;
                        status.Nome = readstatus[i].de_statusproposta;

                        liststatus.Add(status);

                        status = null;
                    }
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, liststatus);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
