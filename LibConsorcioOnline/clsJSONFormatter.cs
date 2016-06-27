using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace LibConsorcioOnline
{
    public class clsJSONFormatter
    {
        public string classtoJSON(Object clsObject)
        {
            MemoryStream ms = new MemoryStream();
            DataContractSerializer js;
            StreamReader sr;

            try
            {
                js = new DataContractSerializer(clsObject.GetType());
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
            DataContractSerializer js;
            MemoryStream ms;

            try
            { 
                ms = new MemoryStream(System.Text.ASCIIEncoding.UTF8.GetBytes(strJSON));

                js = new DataContractSerializer(clsObject.GetType());

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
