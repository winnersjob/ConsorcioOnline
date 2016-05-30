using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    }
}
