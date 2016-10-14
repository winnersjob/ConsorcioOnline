using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.Runtime.Serialization;
using System.IO;
using LibConsorcioOnline;
using ConsorcioOnline.Models;

namespace ConsorcioOnline.Controllers
{
    public class UsersMVCController : Controller
    {

        private List<FisicaJuridica> ReadFisicaJuridica()
        {
            List<FisicaJuridica> fisjur = new List<FisicaJuridica>();
            HttpWebRequest request;
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();

            try
            {
                request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLFisicaJuridica"]);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();

                sr = new StreamReader(response.GetResponseStream());

                fisjur = (List<FisicaJuridica>)formatter.JSONtoClass(sr.ReadToEnd(), new List<FisicaJuridica>());

                request.Abort();
                response.Close();
                response.Dispose();
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                RedirectToAction("Index","Home",null);
            }            

            return fisjur;
        }

        private Users ReadUser(string id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLUser"], "/", id));
            HttpWebResponse response;
            StreamReader sr;
            clsJSONFormatter formatter = new clsJSONFormatter();
            Users users=  new Users();

            try
            {

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "GET";
                request.KeepAlive = false;

                response = (HttpWebResponse)request.GetResponse();
                sr = new StreamReader(response.GetResponseStream());

                users = (Users)formatter.JSONtoClass(sr.ReadToEnd(), new Users());

                request.Abort();
                response.Close();
                response.Dispose();
                sr.Close();
                sr.Dispose();

            }
            catch (Exception ex)
            {
                RedirectToAction("Index","Home",new { area = "" });
            }

            return users;

        }

        private Users InsertUser(Users users)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLUser"]);
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

            try
            {
                strJSON = formatter.ClasstoJSON(users);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();
                sr = new StreamReader(response.GetResponseStream());
                users = (Users)formatter.JSONtoClass(sr.ReadToEnd(), new Users());

                request.Abort();
                response.Close();
                response.Dispose();
                sw.Close();
                sw.Dispose();
                sr.Close();
                sr.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return users;

        }

        private Users UpdateUser(Users users)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Concat(ConfigurationSettings.AppSettings["URLUser"], "/", Session["LoginUser"].ToString()));
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;            
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

            try
            {
                strJSON = formatter.ClasstoJSON(users);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "PUT";
                request.KeepAlive = false;

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                request.Abort();
                response.Close();
                response.Dispose();
                sw.Close();
                sw.Dispose();                               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return users;
        }

        private void InsertComprador(Comprador comprador)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLComprador"]);
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

            try
            {
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;
                
                strJSON = formatter.ClasstoJSON(comprador);

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                request.Abort();
                response.Close();
                response.Dispose();
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
        }

        private void InsertVendedor(Vendedor vendedor)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLVendedor"]);
            HttpWebResponse response;
            StreamReader sr;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

            try
            {
                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                strJSON = formatter.ClasstoJSON(vendedor);

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                request.Abort();
                response.Close();
                response.Dispose();
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private void InsertPassword(UserPassword userPassword)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationSettings.AppSettings["URLUserPassword"]);
            HttpWebResponse response;
            StreamWriter sw;
            clsJSONFormatter formatter = new clsJSONFormatter();
            string strJSON = "";

            try
            {
                strJSON = formatter.ClasstoJSON(userPassword);

                request.ContentType = "application/json";
                request.Accept = "application/json";
                request.Method = "POST";
                request.KeepAlive = false;

                sw = new StreamWriter(request.GetRequestStream());
                sw.Write(strJSON);
                sw.Flush();

                response = (HttpWebResponse)request.GetResponse();

                request.Abort();
                response.Close();
                response.Dispose();
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // GET: UsersMVC/Details/xxxxxx
        public ActionResult Details(string id)
        {
            
            Users users = new Users();

            users = ReadUser(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (users == null)
            {
                return HttpNotFound();
            }

            return View(users);
        }
        
        // GET: UsersMVC/Create
        public ActionResult Create()
        {
            
            ViewData["FisicaJuridica"] = ReadFisicaJuridica();
            
            return View();
        }

        // POST: UsersMVC/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Nome,UserName,FisJur,Telefone,Senha,ConfirmSenha")] Users users)
        {            
            Vendedor vendedor = new Vendedor();
            Comprador comprador = new Comprador();
            UserPassword password = new UserPassword();

            if (ModelState.IsValid)
            {
                users = InsertUser(users);
                
                vendedor.IdUser = users.Id;

                InsertVendedor(vendedor);                

                comprador.IdUser = users.Id;

                InsertComprador(comprador);

                password.Id = users.Id;
                password.Password = users.Senha;
                password.PasswordConfirm = users.ConfirmSenha;

                InsertPassword(password);

                return RedirectToAction("Login","Home",new { area = ""});
            }

            ViewData["FisicaJuridica"] = ReadFisicaJuridica();

            return View();

        }

        // GET: UsersMVC/Edit/5
        public ActionResult Edit(string id)
        {
         
            Users users = new Users();

            users = ReadUser(id);
            ViewData["FisicaJuridica"] = ReadFisicaJuridica();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: UsersMVC/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserName,Nome,Apelido,FisJur,Telefone,CPF,CNPJ,IE")] Users users)
        {

            if (Session["LoginUser"] == null)
            {
                return RedirectToAction("Index", "Home", new { area = "" });
            }            

            if (ModelState.IsValid)
            {               

                users.Id = Session["LoginUser"].ToString();

                UpdateUser(users);
                
                return RedirectToAction("Details", new { id = Session["LoginUser"].ToString() });
            }            

            ViewData["FisicaJuridica"] = ReadFisicaJuridica();

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
