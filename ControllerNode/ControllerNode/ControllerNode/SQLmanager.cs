using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControllerNode
{
    /// <summary>Clase para instanciar el SQL</summary>
    class SQLmanager
    {
        /// <summary>Se obtiene la conexion a  la instancia de SQL</summary>
        /// <returns>SqlConnection.</returns>
        public static SqlConnection GetSQLConnection()
        {
            SqlConnection connection = new SqlConnection("server=MSI\\SQLSERVERANDROW; database=ProyectoRedes2 ; integrated security = true");

            return connection;
        }
    }
}
