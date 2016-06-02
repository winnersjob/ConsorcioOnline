using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace LibConsorcioOnline
{
    public class clsCRUDConsorcio
    {
        public void insertStatusCarta(tbStatusCarta newStatusCarta)
        { 
            try
            { 
                using(dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbStatusCarta statuscarta = new tbStatusCarta();

                    statuscarta.de_statuscarta = newStatusCarta.de_statuscarta;

                    consorcio.tbStatusCarta.Add(statuscarta);
                    consorcio.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void insertUser(tbUsers newUser)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbUsers user = new tbUsers();

                    user.id_user = new Guid().ToString();
                    user.nm_user = newUser.nm_user;
                    user.nm_apelido = newUser.nm_apelido;                    
                    user.cd_fisjur = newUser.cd_fisjur;
                    user.cd_cnpj = newUser.cd_cnpj;
                    user.cd_cpf = newUser.cd_cpf;
                    user.cd_ie = newUser.cd_ie;
                    user.bit_bloqueio = false;

                    consorcio.tbUsers.Add(user);
                    consorcio.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateUser(tbUsers upUser)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbUsers user = consorcio.tbUsers.Where(u => u.id_user == upUser.id_user).FirstOrDefault();

                    if(user == null)
                    {
                        throw new Exception("Usuário não Encontrado!");
                    }

                    user.nm_user = upUser.nm_user;
                    user.nm_apelido = upUser.nm_apelido;
                    user.cd_fisjur = upUser.cd_fisjur;
                    user.cd_cnpj = upUser.cd_cnpj;
                    user.cd_cpf = upUser.cd_cpf;
                    user.cd_ie = upUser.cd_ie;
                    user.bit_bloqueio = upUser.bit_bloqueio;

                    consorcio.SaveChanges();
                    
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void deleteUser(tbUsers dUser)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbUsers user = consorcio.tbUsers.Where(u => u.id_user == dUser.id_user).FirstOrDefault();

                    consorcio.tbUsers.Remove(user);
                    consorcio.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void insertUserPassword(tbUserPassword newPassword)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbUserPassword password = new tbUserPassword();

                    password.id_user = newPassword.id_user;
                    password.de_password = returnSHA512String(newPassword.de_password);
                    password.dt_create = DateTime.Now;
                    password.bt_bloqueio = false;
                    
                    consorcio.tbUserPassword.Add(password);
                    consorcio.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateUserPassword(tbUserPassword upPassword)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbUserPassword password = consorcio.tbUserPassword.Where(p => p.id_user == upPassword.id_user).FirstOrDefault();

                    if (password == null)
                    {
                        throw new Exception("Usuário sem Password definido");
                    }

                    password.de_password = returnSHA512String(upPassword.de_password);
                    password.dt_create = upPassword.dt_create;
                    password.dt_update = DateTime.Now; 
                    password.bt_bloqueio = false;

                    consorcio.tbUserPassword.Add(password);
                    consorcio.SaveChanges();                

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        private string returnSHA512String(string strTexto)
        {
            SHA512 sha = new SHA512Managed();
            byte[] bEncoding;
            byte[] bHash;
            string strHashCode = "";

            try
            {
                bEncoding = Encoding.UTF8.GetBytes(String.Concat("K0n$0rc10", strTexto, "onl1n3"));
                bHash = sha.ComputeHash(bEncoding);

                foreach(byte b in bHash)
                {
                    strHashCode += String.Format("{0:x2}", b);
                }

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

            sha.Dispose();

            return strHashCode;

        }

    }
}
