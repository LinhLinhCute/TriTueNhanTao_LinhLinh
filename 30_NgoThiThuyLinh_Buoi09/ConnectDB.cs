using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _30_NgoThiThuyLinh_Buoi09
{
    class ConnectDB
    {
        public SqlConnection connect;
        public ConnectDB()
        {
            connect = new SqlConnection("Data Source =A209PC18; Initial Catalog= TrangSuc; Integrated Security = true");
        }
        public ConnectDB(string strcn)
        {
            connect = new SqlConnection(strcn);
        }
    }
}
