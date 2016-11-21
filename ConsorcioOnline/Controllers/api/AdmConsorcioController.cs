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
    [RoutePrefix("api/admconsorcio")]
    public class AdmConsorcioController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            List<tbAdmConsorcio> readadmconsorcio = new List<tbAdmConsorcio>();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            List<AdmConsorcio> listadmconsorcio = new List<AdmConsorcio>();
            
            try
            {
                readadmconsorcio = CRUD.readAdmConsorcio();

                if (readadmconsorcio.Count > 0)
                {
                    for (int i = 0; i < readadmconsorcio.Count; i++)
                    {
                        AdmConsorcio admcons = new AdmConsorcio();

                        admcons.Id = readadmconsorcio[i].cd_admconsorcio;
                        admcons.Nome = readadmconsorcio[i].nm_admconsorcio;

                        listadmconsorcio.Add(admcons);

                        admcons = null;
                    }                  

                }

                return this.Request.CreateResponse(HttpStatusCode.OK, listadmconsorcio);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
