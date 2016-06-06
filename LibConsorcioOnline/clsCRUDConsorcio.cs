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
        private enum enStatusCarta { EmAnalise=1, Publicada=2, Reprovada=3};
        private enum enStatusProposta { EmAnalise=1, Aprovada=2, Reprovada=3};

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
                    password.bt_bloqueio = password.bt_bloqueio;
                    
                    consorcio.SaveChanges();                

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void insertComprador(tbComprador newComprador)
        {
            try
            {
                using(dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbComprador comprador = new tbComprador();

                    comprador.id_user = newComprador.id_user;
                    comprador.dt_create = DateTime.Now;
                    comprador.bt_bloqueado = false;

                    consorcio.tbComprador.Add(comprador);
                    consorcio.SaveChanges();
                    
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateComprador(tbComprador upComprador)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbComprador comprador = consorcio.tbComprador.Where(c => c.id_user == upComprador.id_user).FirstOrDefault();

                    comprador.nu_qual_negativa = upComprador.nu_qual_negativa;
                    comprador.nu_qual_positiva = upComprador.nu_qual_positiva;
                    comprador.bt_bloqueado = upComprador.bt_bloqueado;

                    consorcio.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
                    
            }
        }

        public void insertVendedor(tbVendedor newVendedor)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbVendedor vendedor = new tbVendedor();

                    vendedor.id_user = newVendedor.id_user;
                    vendedor.dt_create = DateTime.Now;
                    vendedor.bt_bloqueado = false;

                    consorcio.tbVendedor.Add(vendedor);
                    consorcio.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateVendedor(tbVendedor upVendedor)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbVendedor vendedor = consorcio.tbVendedor.Where(c => c.id_user == upVendedor.id_user).FirstOrDefault();

                    vendedor.nu_qual_negativa = upVendedor.nu_qual_negativa;
                    vendedor.nu_qual_positiva = upVendedor.nu_qual_positiva;
                    vendedor.bt_bloqueado = upVendedor.bt_bloqueado;

                    consorcio.SaveChanges();

                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public void insertCartaCredito(tbCartaCredito newCartaCredito)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbCartaCredito carta = new tbCartaCredito();

                    carta.cd_vendedor = newCartaCredito.cd_vendedor;
                    carta.cd_admconsorcio = newCartaCredito.cd_admconsorcio;
                    carta.cd_tipoconsorcio = newCartaCredito.cd_tipoconsorcio;
                    carta.cd_statuscarta = newCartaCredito.cd_statuscarta;
                    carta.de_cidade = newCartaCredito.de_cidade;
                    carta.de_uf = newCartaCredito.de_uf;
                    carta.nu_valorcredito = newCartaCredito.nu_valorcredito;
                    carta.nu_valorentrada = newCartaCredito.nu_valorentrada;
                    carta.nu_qtd_parcelas = newCartaCredito.nu_qtd_parcelas;
                    carta.nu_valorparcela = newCartaCredito.nu_valorparcela;
                    carta.nu_saldocarta = newCartaCredito.nu_saldocarta;
                    carta.de_indexador = newCartaCredito.de_indexador;
                    carta.nu_honorarios = newCartaCredito.nu_honorarios;
                    carta.nu_taxajuros = newCartaCredito.nu_taxajuros;

                    consorcio.tbCartaCredito.Add(carta);
                    consorcio.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateCartaCredito(tbCartaCredito upCartaCredito)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbCartaCredito carta = consorcio.tbCartaCredito.Where(c => c.cd_cartacredito == upCartaCredito.cd_cartacredito).FirstOrDefault();

                    carta.cd_admconsorcio = upCartaCredito.cd_admconsorcio;
                    carta.cd_tipoconsorcio = upCartaCredito.cd_tipoconsorcio;
                    carta.cd_statuscarta = upCartaCredito.cd_statuscarta;
                    carta.de_cidade = upCartaCredito.de_cidade;
                    carta.de_uf = upCartaCredito.de_uf;
                    carta.nu_valorcredito = upCartaCredito.nu_valorcredito;
                    carta.nu_valorentrada = upCartaCredito.nu_valorentrada;
                    carta.nu_qtd_parcelas = upCartaCredito.nu_qtd_parcelas;
                    carta.nu_valorparcela = upCartaCredito.nu_valorparcela;
                    carta.nu_saldocarta = upCartaCredito.nu_saldocarta;
                    carta.de_indexador = upCartaCredito.de_indexador;
                    carta.nu_honorarios = upCartaCredito.nu_honorarios;
                    carta.nu_taxajuros = upCartaCredito.nu_taxajuros;

                    consorcio.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void insertAnexoCarta(tbAnexoCarta newAnexoCarta)
        {
            try
            {
                using(dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbAnexoCarta anexo = new tbAnexoCarta();

                    anexo.id_anexo = new Guid().ToString();
                    anexo.cd_cartacredito = newAnexoCarta.cd_cartacredito;
                    anexo.de_linkanexo = newAnexoCarta.de_linkanexo;

                    consorcio.tbAnexoCarta.Add(anexo);
                    consorcio.SaveChanges();

                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updateAnexoCarta(tbAnexoCarta upAnexoCarta)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbAnexoCarta anexo = consorcio.tbAnexoCarta.Where(a => a.id_anexo == upAnexoCarta.id_anexo).FirstOrDefault();

                    anexo.de_linkanexo = upAnexoCarta.de_linkanexo;

                    consorcio.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void insertPropostaCarta(tbPropostaCarta newPropostaCarta)
        {
            try
            {
                using(dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbPropostaCarta proposta = new tbPropostaCarta();

                    proposta.cd_cartacredito = newPropostaCarta.cd_cartacredito;
                    proposta.cd_vendedor = newPropostaCarta.cd_vendedor;
                    proposta.cd_comprador = newPropostaCarta.cd_comprador;
                    proposta.cd_statusproposta = (int)enStatusProposta.EmAnalise;
                    proposta.de_mensagemproposta = newPropostaCarta.de_mensagemproposta;

                    consorcio.tbPropostaCarta.Add(proposta);
                    consorcio.SaveChanges();                               
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void updatePropostaCarta(tbPropostaCarta upPropostaCarta)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbPropostaCarta proposta = consorcio.tbPropostaCarta.Where(p => p.cd_propostacarta == upPropostaCarta.cd_propostacarta).FirstOrDefault();

                    proposta.cd_statusproposta = upPropostaCarta.cd_statusproposta;

                    consorcio.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void insertQualificacaoComprador(tbQualificacaoComprador newQualificacaoComprador)
        {
            try
            {
                using(dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbQualificacaoComprador qualificacao = new tbQualificacaoComprador();

                    qualificacao.cd_comprador = newQualificacaoComprador.cd_comprador;
                    qualificacao.cd_vendedor = newQualificacaoComprador.cd_vendedor;
                    qualificacao.cd_cartacredito = newQualificacaoComprador.cd_cartacredito;
                    qualificacao.nu_pontuacao = newQualificacaoComprador.nu_pontuacao;
                    qualificacao.de_observacaovendedor = newQualificacaoComprador.de_observacaovendedor;

                    consorcio.tbQualificacaoComprador.Add(qualificacao);
                    consorcio.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void insertQualificacaoVendedor(tbQualificacaoVendedor newQualificacaoVendedor)
        {
            try
            {
                using (dbConsorcioEntities consorcio = new dbConsorcioEntities())
                {
                    tbQualificacaoVendedor qualificacao = new tbQualificacaoVendedor();

                    qualificacao.cd_vendedor = newQualificacaoVendedor.cd_vendedor;
                    qualificacao.cd_comprador = newQualificacaoVendedor.cd_comprador;
                    qualificacao.cd_cartacredito = newQualificacaoVendedor.cd_cartacredito;
                    qualificacao.nu_pontuacao = newQualificacaoVendedor.nu_pontuacao;
                    qualificacao.de_observacaocomprador = newQualificacaoVendedor.de_observacaocomprador;

                    consorcio.tbQualificacaoVendedor.Add(qualificacao);
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
