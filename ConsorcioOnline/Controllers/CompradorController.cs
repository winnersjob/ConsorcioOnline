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
    public class CompradorController : ApiController
    {
        //// GET: api/Comprador
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Comprador/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Comprador
        public void Post([FromBody]Comprador value)
        {
            tbComprador newComprador = new tbComprador();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newComprador.id_user = value.IdUser;            

            CRUD.insertComprador(newComprador);
        }

        // PUT: api/Comprador/5
        public void Put(long id, [FromBody]Comprador value)
        {
            tbComprador upComprador = new tbComprador();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            upComprador.cd_comprador = id;
            upComprador.id_user = value.IdUser;
            upComprador.nu_qual_negativa = value.NegativeFeedback;
            upComprador.nu_qual_positiva = value.PositiveFeedback;
            upComprador.bt_bloqueado = value.Blocked;

            CRUD.updateComprador(upComprador);
        
        }

        //// DELETE: api/Comprador/5
        //public void Delete(int id)
        //{
        //}
    }
}
