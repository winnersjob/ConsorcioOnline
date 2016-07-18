using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ConsorcioOnline.Models
{
    public class clsJSONFormatter
    {
        public string ClasstoJSON(Object clsObject)
        {
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer js;
            StreamReader sr;

            try
            {
                js = new DataContractJsonSerializer(clsObject.GetType());
                js.WriteObject(ms, clsObject);

                ms.Position = 0;

                sr = new StreamReader(ms);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return sr.ReadToEnd();

        }

        public Object JSONtoClass(string strJSON, Object clsObject)
        {
            Object objRetorno;
            DataContractJsonSerializer js;
            MemoryStream ms;

            try
            {
                ms = new MemoryStream(System.Text.ASCIIEncoding.UTF8.GetBytes(strJSON));

                js = new DataContractJsonSerializer(clsObject.GetType());

                objRetorno = Convert.ChangeType(js.ReadObject(ms), clsObject.GetType());

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
            return objRetorno;

        }
            
    }
}
