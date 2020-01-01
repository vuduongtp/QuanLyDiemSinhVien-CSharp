using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV1
{
    class LoginDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public LoginDAL()
        {
            dc = new DataConnection();
        }
        //exec SP_DANGNHAP 'httru'
        //SELECT name FROM sys.sysusers WHERE name = 'GV18'
        public int CheckLogin(string loginName)
        {
            string sql = "exec SP_DANGNHAP " + "'" + loginName + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows.Count;
        }
        public int CheckUserName(string userName)
        {
            string sql = "select tendangnhap=SUSER_SNAME(sid) from sys.sysusers where name=" + "'" + userName + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows.Count;
        }
        public Boolean themTaiKhoan(string login,string pass,string username,string nhom)
        {
            //string sql = "EXEC SP_TAOLOGIN " + "'" + login + "'," + "'" + pass + "'," + "'" + username + "'," + "'" + nhom + "'";
            try
            {
                //SqlConnection con = dc.getConnect();
                //da = new SqlDataAdapter(sql, con);
                //con.Open();
                //MessageBox.Show("Thêm thành công");
                string sql = "EXEC SP_TAOLOGIN " + "'" + login + "'," + "'" + pass + "'," + "'" + username + "'," + "'" + nhom + "'";

                Program.ExecSqlDataReader(sql);
                return true;

            }
            catch (Exception)
            {

                //throw;
                //MessageBox.Show("Thêm thất bại");
                return false;
            }
            //return true;
        }

    }
}
