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
    class LopDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public LopDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getAllLop()
        {
            string sql = "SELECT MALOP,TENLOP,MAKH FROM LOP";
            //B2:Tạo 1 connect đến sql
            SqlConnection con = dc.getConnect();
            //B3 :Khoi tao lop SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //B4:
            con.Open();
            //B5 Đổ dl ra datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int CheckMaLop(string malop)
        {
            string sql = "SELECT * FROM LINK0.QLDSV.dbo.LOP WHERE MALOP=" + "'" + malop + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows.Count;
        }
        public int checkDeleteLop(string malop)
        {
            string sql = "SELECT MASV,HO,TEN,MALOP,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU,NGHIHOC FROM SINHVIEN WHERE MALOP='" + malop + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows.Count;
        }
        public bool InsertLop(Lop l)
        {
            string sql = "INSERT INTO LOP(MALOP,TENLOP,MAKH) VALUES(REPLACE(@MALOP,' ',''),@TENLOP,@MAKH)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = l.MALOP;
                cmd.Parameters.Add("@TENLOP", SqlDbType.NVarChar).Value = l.TENLOP;
                cmd.Parameters.Add("@MAKH", SqlDbType.NChar).Value = l.MAKH;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi trùng khóa chính hoặc khóa duy nhất");
                return false;
            }
            return true;
        }
        public bool Delete(Lop l)
        {
            string sql = "DELETE FROM LOP WHERE MALOP=@MALOP";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = l.MALOP;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        public bool UpdateLop(Lop l)
        {
            string sql = "UPDATE LOP SET MALOP=@MALOP,TENLOP=@TENLOP,MAKH=@MAKH WHERE MALOP=@MALOP";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MALOP", SqlDbType.NVarChar).Value = l.MALOP;
                cmd.Parameters.Add("@TENLOP", SqlDbType.NVarChar).Value = l.TENLOP;
                cmd.Parameters.Add("@MAKH", SqlDbType.NVarChar).Value = l.MAKH;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
    }
}
