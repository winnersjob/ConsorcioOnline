using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibConsorcioOnline;

namespace ConsConsorcio
{
    class Program
    {
        static void Main(string[] args)
        {
            clsCRUDConsorcio CRUD = new clsCRUDConsorcio();
            tbStatusCarta newStatusCarta = new tbStatusCarta();
            
            try
            {
                newStatusCarta.de_statuscarta = "Em Análise";
                CRUD.insertStatusCarta(newStatusCarta);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
