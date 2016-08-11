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
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        //POST(Login):
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Login([FromBody]LoginUser value)
        {
            tbUsers user = new tbUsers();
            tbUserPassword password = new tbUserPassword();
            bool validate = false;
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {

                user.de_username = value.UserName;
                user.id_user = CRUD.readIdUser(value.UserName);

                if (user.id_user == "")
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Usuário ou Senha Incorretos!");
                }

                password.id_user = user.id_user;
                password.de_password = value.Password;

                validate = CRUD.validateUserPassword(password);

                if (validate == false)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "Usuário ou Senha Incorretos!");
                }

                value.Id = user.id_user;
                value.Nome = user.nm_user;

                return this.Request.CreateResponse(HttpStatusCode.OK, value);

            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            
        }

    }
}
