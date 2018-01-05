using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Newtonsoft.Json;
using System.Configuration;

namespace OPAS_ETL_PULL
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateJson();
        }

        private static DataTable fetchOpasData()
        {
            DAL objDal = new DAL();
            DataTable dt = objDal.ExecuteDataSet("usp_select_IncidentManagement_Data").Tables[0];
            return dt;
        }

        private static void GenerateJson()
        {
            string folderPath = ConfigurationManager.AppSettings["folderPath"].ToString();
            DataTable dt = fetchOpasData();
            string jsonString = String.Empty;
            jsonString = JsonConvert.SerializeObject(dt);
            System.IO.File.WriteAllText(folderPath + "OPAS_Data.json", jsonString);
        }

    }
}
