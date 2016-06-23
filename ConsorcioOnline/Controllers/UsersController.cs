﻿using System;
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
        //public Users Get(int id)
        //{
          
        //}

        // POST: api/Users
        public void Post([FromBody]Users value)
        {
            tbUsers newUser = new tbUsers();
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();

            newUser.nm_user = value.Nome;
            newUser.nm_apelido = value.Apelido;
            newUser.cd_fisjur = value.FisJur;
            newUser.cd_cpf = value.CPF;
            newUser.cd_cnpj = value.CNPJ;
            newUser.cd_ie = value.IE;

            CRUD.insertUser(newUser);            

        }

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