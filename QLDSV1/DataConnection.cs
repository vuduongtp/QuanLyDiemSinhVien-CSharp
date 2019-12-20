using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDSV1
{
    class DataConnection
    {
        String conStr;
        public DataConnection()
        {
            conStr= "Data Source=" + Program.servername + "; Initial Catalog=QLDSV; User ID=" +
                      Program.mlogin + ";password=" + Program.password;
           
        }
        public SqlConnection getConnect()
        {
            return new SqlConnection(conStr);
        }
    }
}
