using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibConsorcioOnline;
using System.Security.Cryptography;

namespace ConsConsorcio
{
    class Program
    {
        static void Main(string[] args)
        {
            SHA512 sha = new SHA512Managed();
            string strNome = "roger.alves";
            byte[] encoding;
            byte[] hash;
            string strHashCode = "";

            try
            {
                encoding = Encoding.UTF8.GetBytes(strNome);
                hash = sha.ComputeHash(encoding);

                foreach (byte x in hash)
                {
                    strHashCode += String.Format("{0:x2}", x);
                }

                Console.WriteLine(strHashCode);
                Console.Read();
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
