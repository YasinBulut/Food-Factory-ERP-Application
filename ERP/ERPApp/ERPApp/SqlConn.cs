using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ERPApp
{
    class SqlConn
    {
        public SqlConnection conn()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HUU8N9D;Initial Catalog=DboERP;Integrated Security=True");
            conn.Open();
            return conn;
        }   
    }
}
