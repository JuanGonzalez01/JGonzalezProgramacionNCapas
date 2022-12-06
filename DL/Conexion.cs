using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["JGonzalezProgramacionNCapas"].ConnectionString.ToString();
        }

    }
}
