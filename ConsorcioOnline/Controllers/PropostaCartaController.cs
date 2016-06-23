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
    public class PropostaCartaController : ApiController
    {
        //// GET: api/PropostaCarta
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/PropostaCarta/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/PropostaCarta
        public void Post([FromBody]PropostaCarta value)
        {
            tbPropostaCarta newPropostaCarta = new tbPropostaCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newPropostaCarta.cd_cartacredito = value.IdCarta;
            newPropostaCarta.cd_comprador = value.IdComprador;
            newPropostaCarta.cd_vendedor = value.IdVendedor;
            newPropostaCarta.de_mensagemproposta = value.MensagemProposta;

            CRUD.insertPropostaCarta(newPropostaCarta);
        }

        // PUT: api/PropostaCarta/5
        public void Put(long id, [FromBody]PropostaCarta value)
        {
            tbPropostaCarta upPropostaCarta = new tbPropostaCarta();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            upPropostaCarta.cd_propostacarta = id;
            upPropostaCarta.cd_cartacredito = value.IdCarta;
            upPropostaCarta.cd_comprador = value.IdComprador;
            upPropostaCarta.cd_vendedor = value.IdVendedor;
            upPropostaCarta.de_mensagemproposta = value.MensagemProposta;

            CRUD.updatePropostaCarta(upPropostaCarta);
        }

        //// DELETE: api/PropostaCarta/5
        //public void Delete(int id)
        //{
        //}
    }
}
