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
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {

        // GET: api/Users/5
        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Users retUser = new Users();
            tbUsers user = new tbUsers();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            
            try
            {

                user = CRUD.readUser(id);

                retUser.Id = id;
                retUser.UserName = user.de_username;
                retUser.Nome = user.nm_user;
                retUser.Apelido = user.nm_apelido;
                retUser.FisJur = user.cd_fisjur;
                retUser.CPF = user.cd_cpf;
                retUser.CNPJ = user.cd_cnpj;
                retUser.IE = user.cd_ie;
                retUser.Blocked = user.bit_bloqueio;
                retUser.Telefone = user.de_telefone;

                return this.Request.CreateResponse(HttpStatusCode.OK, retUser);

            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }           
                        
        }

        // POST: api/Users
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]Users value)
        {
            tbUsers newUser = new tbUsers();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            { 
                newUser.de_username = value.UserName;
                newUser.nm_user = value.Nome;
                newUser.nm_apelido = value.Apelido;
                newUser.cd_fisjur = value.FisJur;
                newUser.cd_cpf = value.CPF;
                newUser.cd_cnpj = value.CNPJ;
                newUser.cd_ie = value.IE;
                newUser.de_telefone = value.Telefone;

                newUser = CRUD.insertUser(newUser);
                value.Id = newUser.id_user;

                return this.Request.CreateResponse(HttpStatusCode.OK, value);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
        }

        // PUT: api/Users/5
        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]Users value)
        {
            tbUsers upUser = new tbUsers();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                upUser.id_user = id;
                upUser.de_username = value.UserName;
                upUser.nm_user = value.Nome;
                upUser.nm_apelido = value.Apelido;
                upUser.cd_fisjur = value.FisJur;
                upUser.cd_cpf = value.CPF;
                upUser.cd_cnpj = value.CNPJ;
                upUser.cd_ie = value.IE;
                upUser.de_telefone = value.Telefone;

                CRUD.updateUser(upUser);

                return this.Request.CreateResponse(HttpStatusCode.OK, value);

            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }           
                                                 
        }

        // DELETE: api/Users/5
        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            tbUsers delUser = new tbUsers();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                delUser.id_user = id;

                CRUD.deleteUser(delUser);

                return this.Request.CreateResponse(HttpStatusCode.OK);

            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }
    }
}
