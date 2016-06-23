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
    public class AnexoCartaController : ApiController
    {
        //// GET: api/AnexoCarta
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/AnexoCarta/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/AnexoCarta
        public void Post([FromBody]AnexoCarta value)
        {
            tbAnexoCarta newAnexo = new tbAnexoCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newAnexo.cd_cartacredito = value.IdCarta;
            newAnexo.de_linkanexo = value.LinkAnexo;

            CRUD.insertAnexoCarta(newAnexo);
        }

        // PUT: api/AnexoCarta/5
        public void Put(string id, [FromBody]AnexoCarta value)
        {
            tbAnexoCarta upAnexo = new tbAnexoCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            upAnexo.id_anexo = id;
            upAnexo.cd_cartacredito = value.IdCarta;
            upAnexo.de_linkanexo = value.LinkAnexo;

            CRUD.updateAnexoCarta(upAnexo);
        }

        //// DELETE: api/AnexoCarta/5
        //public void Delete(int id)
        //{
        //}
    }
}
