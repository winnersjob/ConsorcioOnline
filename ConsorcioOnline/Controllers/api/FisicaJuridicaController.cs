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
    [RoutePrefix("api/fisicajuridica")]
    public class FisicaJuridicaController : ApiController
    {
        [HttpGet]
        [Route("")]
        public HttpResponseMessage Get()
        {
            List<tbFisicaJuridica> readstatus = new List<tbFisicaJuridica>();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            List<FisicaJuridica> liststatus = new List<FisicaJuridica>();

            try
            {
                readstatus = CRUD.readFisicaJuridica();

                if (readstatus.Count > 0 )
                {
                    for(int i=0;i< readstatus.Count;i++)
                    {
                        FisicaJuridica status = new FisicaJuridica();

                        status.Id = readstatus[i].cd_fisjur;
                        status.Nome = readstatus[i].de_fisjur;

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
