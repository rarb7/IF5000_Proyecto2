using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace saSEARCH
{
    class SQLManager
    {
        public static SqlConnection GetSQLConnection()
        {
            SqlConnection connection = new SqlConnection("server=MSI\\SQLSERVERANDROW; database=ProyectoRedes2 ; integrated security = true");
            
            return connection;
        }
    }
}
