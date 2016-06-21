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
    public class UserPasswordController : ApiController
    {
        //// GET: api/UserPassword
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/UserPassword/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/UserPassword
        public void Post([FromBody]UserPassword value)
        {
            tbUserPassword newPassword = new tbUserPassword();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newPassword.id_user = value.Id;
            newPassword.de_password = value.Password;

            CRUD.insertUserPassword(newPassword);

        }

        // PUT: api/UserPassword/5
        public void Put(string id, [FromBody]UserPassword value)
        {
            tbUserPassword upPassword = new tbUserPassword();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            upPassword.id_user = id;
            upPassword.de_password = value.Password;

            CRUD.updateUserPassword(upPassword);
        }

        //DELETE: api/UserPassword/5
        //public void Delete(int id)
        //{
        //}
    }
}
