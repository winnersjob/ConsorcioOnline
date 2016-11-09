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
    [RoutePrefix("api/tipoconsorcio")]
    public class TipoConsorcioController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            List<tbTipoConsorcio> readtipoconsorcio = new List<tbTipoConsorcio>();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            List<TipoConsorcio> listtipoconsorcio = new List<TipoConsorcio>();

            try
            {
                readtipoconsorcio = CRUD.readTipoConsorcio();

                if (readtipoconsorcio.Count > 0)
                {
                    for (int i = 0; i < readtipoconsorcio.Count; i++)
                    {
                        TipoConsorcio status = new TipoConsorcio();

                        status.Id = readtipoconsorcio[i].cd_tipoconsorcio;
                        status.Nome = readtipoconsorcio[i].de_tipoconsorcio;

                        listtipoconsorcio.Add(status);

                        status = null;
                    }
                }

                return this.Request.CreateResponse(HttpStatusCode.OK, listtipoconsorcio);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
