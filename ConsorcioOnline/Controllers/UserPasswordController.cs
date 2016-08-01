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
    [RoutePrefix("api/userpassword")]
    public class UserPasswordController : ApiController
    {

        // POST: api/UserPassword
        [Route("")]
        [HttpPost]
        public HttpResponseMessage Post([FromBody]UserPassword value)
        {
            tbUserPassword newPassword = new tbUserPassword();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                newPassword.id_user = value.Id;
                newPassword.de_password = value.Password;

                CRUD.insertUserPassword(newPassword);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }            

        }

        // PUT: api/UserPassword/5
        [Route("{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string id, [FromBody]UserPassword value)
        {
            tbUserPassword upPassword = new tbUserPassword();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            try
            {
                upPassword.id_user = id;
                upPassword.de_password = value.Password;

                CRUD.updateUserPassword(upPassword);

                return this.Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

        }

    }
}
