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
    public class VendedorController : ApiController
    {
        //// GET: api/Vendedor
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Vendedor/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Vendedor
        public void Post([FromBody]Vendedor value)
        {
            tbVendedor newVendedor = new tbVendedor();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newVendedor.id_user = value.IdUser;

            CRUD.insertVendedor(newVendedor);
        }

        // PUT: api/Vendedor/5
        public void Put(long id, [FromBody]Vendedor value)
        {
            tbVendedor upVendedor = new tbVendedor();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            upVendedor.cd_vendedor = id;
            upVendedor.id_user = value.IdUser;
            upVendedor.nu_qual_negativa = value.NegativeFeedback;
            upVendedor.nu_qual_positiva = value.PositiveFeedback;
            upVendedor.bt_bloqueado = value.Blocked;

            CRUD.updateVendedor(upVendedor);
        }

        //// DELETE: api/Vendedor/5
        //public void Delete(int id)
        //{
        //}
    }
}
