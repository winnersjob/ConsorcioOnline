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
    public class UsersController : ApiController
    {

        // GET: api/Users/5
        public Users Get(string id)
        {
            Users retUser = new Users();
            tbUsers user = new tbUsers();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            
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

            return retUser;
                        
        }

        // POST: api/Users
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

                newUser = CRUD.insertUser(newUser);
                value.Id = newUser.id_user;

                return this.Request.CreateResponse(HttpStatusCode.OK, value);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest,ex.Message);
            }
        }

        //POST(Login):
        //public IHttpActionResult Post([FromBody]LoginUser value)
        //{
        //    tbUsers user = new tbUsers();
        //    tbUserPassword password = new tbUserPassword();
        //    bool validate = false;
        //    clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

        //    user.de_username = value.UserName;
        //    user.id_user = CRUD.readIdUser(value.UserName);

        //    if(user.id_user == "")
        //    {
        //        return BadRequest("Usuário ou Senha Incorretos!");
        //    }

        //    password.id_user = user.id_user;
        //    password.de_password = value.Password;

        //    validate = CRUD.validateUserPassword(password);
            
        //    if(validate == false)
        //    {
        //        return BadRequest("Usuário ou Senha Incorretos!");
        //    }

        //    value.Id = user.id_user;
        //    value.Nome = user.nm_user;

        //    return Ok(value);
        //} 

        // PUT: api/Users/5
        public void Put(string id, [FromBody]Users value)
        {
            tbUsers upUser = new tbUsers();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            upUser.id_user = id;
            upUser.nm_user = value.Nome;
            upUser.nm_apelido = value.Apelido;
            upUser.cd_fisjur = value.FisJur;
            upUser.cd_cpf = value.CPF;
            upUser.cd_cnpj = value.CNPJ;
            upUser.cd_ie = value.IE;

            CRUD.updateUser(upUser);
                                                 
        }

        // DELETE: api/Users/5
        public void Delete(string id)
        {
            tbUsers delUser = new tbUsers();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            delUser.id_user = id;
            
            CRUD.deleteUser(delUser);
        }
    }
}
