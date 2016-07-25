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
    public class CartaController : ApiController
    {
        // GET: api/Carta
        public IEnumerable<CartaCredito> Post([FromBody]Models.Filter value)
        {
            List<tbCartaCredito> readCarta = new List<tbCartaCredito>();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            List<CartaCredito> listCarta = new List<CartaCredito>();

            readCarta = CRUD.readCartasCredito(value.ValorCreditoDe, value.ValorCreditoAte, value.IdUser);

            if(readCarta.Count > 0 )
            {
                for (int i = 0;i < readCarta.Count;i++)
                {
                    CartaCredito carta = new CartaCredito();

                    carta.Id = readCarta[i].cd_cartacredito;
                    carta.IdVendedor = readCarta[i].cd_vendedor;
                    carta.AdmConsorcio = readCarta[i].cd_admconsorcio;
                    carta.TipoConsorcio = readCarta[i].cd_tipoconsorcio;
                    carta.Cidade = readCarta[i].de_cidade;
                    carta.Honorarios = readCarta[i].nu_honorarios;
                    carta.Indexador = readCarta[i].de_indexador;
                    carta.QtdParcelas = readCarta[i].nu_qtd_parcelas;
                    carta.SaldoCarta = readCarta[i].nu_saldocarta;
                    carta.StatusCarta = readCarta[i].cd_statuscarta;
                    carta.TaxaJuros = readCarta[i].nu_taxajuros;
                    carta.UF = readCarta[i].de_uf;
                    carta.ValorCredito = readCarta[i].nu_valorcredito;
                    carta.ValorEntrada = readCarta[i].nu_valorentrada;
                    carta.ValorParcela = readCarta[i].nu_valorparcela;

                    listCarta.Add(carta);

                    carta = null;

                }
            }

            return listCarta;
        }

        // GET: api/Carta/5
        public CartaCredito Get(Int64 id)
        {
            tbCartaCredito readCarta = new tbCartaCredito();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            CartaCredito carta = new CartaCredito();

            readCarta = CRUD.readCartaCredito(id);

            carta.Id = readCarta.cd_cartacredito;
            carta.AdmConsorcio = readCarta.cd_admconsorcio;
            carta.TipoConsorcio = readCarta.cd_tipoconsorcio;
            carta.IdVendedor = readCarta.cd_vendedor;
            carta.StatusCarta = readCarta.cd_statuscarta;
            carta.Cidade = readCarta.de_cidade;
            carta.UF= readCarta.de_uf;
            carta.Indexador = readCarta.de_indexador;
            carta.Honorarios=readCarta.nu_honorarios;
            carta.QtdParcelas=readCarta.nu_qtd_parcelas;
            carta.SaldoCarta=readCarta.nu_saldocarta;
            carta.TaxaJuros=readCarta.nu_taxajuros;
            carta.ValorCredito=readCarta.nu_valorcredito;
            carta.ValorEntrada=readCarta.nu_valorentrada;
            carta.ValorParcela=readCarta.nu_valorparcela;
            
            return carta;
        }

        // POST: api/Carta
        public void Post([FromBody]CartaCredito value)
        {
            tbCartaCredito newCarta = new tbCartaCredito();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newCarta.cd_admconsorcio = value.AdmConsorcio;
            newCarta.cd_tipoconsorcio = value.TipoConsorcio;
            newCarta.cd_vendedor = value.IdVendedor;
            newCarta.de_cidade = value.Cidade;
            newCarta.de_uf = value.UF;
            newCarta.de_indexador = value.Indexador;
            newCarta.nu_honorarios = value.Honorarios;
            newCarta.nu_qtd_parcelas = value.QtdParcelas;
            newCarta.nu_saldocarta = value.SaldoCarta;
            newCarta.nu_taxajuros = value.TaxaJuros;
            newCarta.nu_valorcredito = value.ValorCredito;
            newCarta.nu_valorentrada = value.ValorEntrada;
            newCarta.nu_valorparcela = value.ValorParcela;

            CRUD.insertCartaCredito(newCarta);
        }

        // PUT: api/Carta/5
        public void Put(long id, [FromBody]CartaCredito value)
        {
            tbCartaCredito upCarta = new tbCartaCredito();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            upCarta.cd_cartacredito = id;
            upCarta.cd_admconsorcio = value.AdmConsorcio;
            upCarta.cd_tipoconsorcio = value.TipoConsorcio;
            upCarta.cd_vendedor = value.IdVendedor;
            upCarta.cd_statuscarta = value.StatusCarta;
            upCarta.de_cidade = value.Cidade;
            upCarta.de_uf = value.UF;
            upCarta.de_indexador = value.Indexador;
            upCarta.nu_honorarios = value.Honorarios;
            upCarta.nu_qtd_parcelas = value.QtdParcelas;
            upCarta.nu_saldocarta = value.SaldoCarta;
            upCarta.nu_taxajuros = value.TaxaJuros;
            upCarta.nu_valorcredito = value.ValorCredito;
            upCarta.nu_valorentrada = value.ValorEntrada;
            upCarta.nu_valorparcela = value.ValorParcela;

            CRUD.updateCartaCredito(upCarta);
        }

        //// DELETE: api/Carta/5
        //public void Delete(int id)
        //{
        //}
    }
}
