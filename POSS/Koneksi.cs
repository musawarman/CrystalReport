using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace POSS
{
    
    class Koneksi
    {
        public static string sqlConnect = "Data Source = DESKTOP-506M5SU\\TRPL; Database = dbPOS; Integrated Security = true";
        public static SqlConnection Connect = new SqlConnection(sqlConnect);
        public static SqlConnection ConnectDB = new SqlConnection(sqlConnect);
    }
}
