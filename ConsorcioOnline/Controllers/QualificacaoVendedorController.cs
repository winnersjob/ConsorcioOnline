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
    public class QualificacaoVendedorController : ApiController
    {
        //// GET: api/QualificacaoVendedor
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/QualificacaoVendedor/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/QualificacaoVendedor
        public void Post([FromBody]QualificacaoVendedor value)
        {
            tbQualificacaoVendedor newQualificacao = new tbQualificacaoVendedor();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newQualificacao.cd_cartacredito = value.IdCarta;
            newQualificacao.cd_comprador = value.IdComprador;
            newQualificacao.cd_vendedor = value.IdVendedor;
            newQualificacao.nu_pontuacao = value.Pontuacao;
            newQualificacao.de_observacaocomprador = value.ObservacaoComprador;

            CRUD.insertQualificacaoVendedor(newQualificacao);
        }

        //// PUT: api/QualificacaoVendedor/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/QualificacaoVendedor/5
        //public void Delete(int id)
        //{
        //}
    }
}
