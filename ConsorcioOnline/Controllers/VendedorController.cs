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
        }

        // PUT: api/Vendedor/5
        public void Put(Int32 id, [FromBody]Vendedor value)
        {
        }

        //// DELETE: api/Vendedor/5
        //public void Delete(int id)
        //{
        //}
    }
}
