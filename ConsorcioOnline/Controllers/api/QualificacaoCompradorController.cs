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
    public class QualificacaoCompradorController : ApiController
    {
        //// GET: api/QualificacaoComprador
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/QualificacaoComprador/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/QualificacaoComprador
        public void Post([FromBody]QualificacaoComprador value)
        {
            tbQualificacaoComprador newQualificacao = new tbQualificacaoComprador();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newQualificacao.cd_cartacredito = value.IdCarta;
            newQualificacao.cd_comprador = value.IdComprador;
            newQualificacao.cd_vendedor = value.IdVendedor;
            newQualificacao.nu_pontuacao = value.Pontuacao;
            newQualificacao.de_observacaovendedor = value.ObservacaoVendedor;

            CRUD.insertQualificacaoComprador(newQualificacao);
        }

        //// PUT: api/QualificacaoComprador/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/QualificacaoComprador/5
        //public void Delete(int id)
        //{
        //}
    }
}
