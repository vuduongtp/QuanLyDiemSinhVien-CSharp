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
    class SinhVienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public SinhVienDAL()
        {
            dc = new DataConnection();
        }
        public int CheckMaSV(string masv)
        {
            string sql = "SELECT * FROM LINK0.QLDSV.dbo.SINHVIEN WHERE MASV=" + "'" + masv + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows.Count;
        }
        public int CheckMaSVinDiem(string masv)
        {
            string sql= "SELECT * FROM DIEM WHERE MASV=" + "'" + masv + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows.Count;
        }
        public DataTable getSinhVien(String malop)
        {
            string sql = "SELECT MASV,HO,TEN,MALOP,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU,NGHIHOC FROM SINHVIEN WHERE MALOP='"+malop+"'";
            //B2:Tạo 1 connect đến sql
            SqlConnection con = dc.getConnect();
            //B3 :Khoi tao lop SqlDataAdapter
            da = new SqlDataAdapter(sql, con);
            //B4:
            con.Open();
            //B5 Đổ dl ra datatable
            DataTable dt = new DataTable();
            da.Fill(dt);
            //Program.demrow = dt.Rows.Count;
            con.Close();
            return dt;
        }
        public bool InsertSinhVien(BeanSinhVien sv)
        {
            string sql = "INSERT INTO SINHVIEN(MASV,HO,TEN,MALOP,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU,NGHIHOC) VALUES(REPLACE(@MASV,' ',''),@HO,@TEN,@MALOP,@PHAI,@NGAYSINH,@NOISINH,@DIACHI,@GHICHU,@NGHIHOC)";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = sv.MASV;
                cmd.Parameters.Add("@HO", SqlDbType.NVarChar).Value = sv.HO;
                cmd.Parameters.Add("@TEN", SqlDbType.NChar).Value = sv.TEN;
                cmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = sv.MALOP;
                cmd.Parameters.Add("@PHAI", SqlDbType.Bit).Value = sv.PHAI;
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = sv.NGAYSINH;
                cmd.Parameters.Add("@NOISINH", SqlDbType.NVarChar).Value = sv.NOISINH;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NChar).Value = sv.DIACHI;
                cmd.Parameters.Add("@GHICHU", SqlDbType.NText).Value = sv.GHICHU;
                cmd.Parameters.Add("@NGHIHOC", SqlDbType.Bit).Value = sv.NGHIHOC;

                //cmd.Parameters.Add("@PHAI", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@NGHIHOC", SqlDbType.Bit).Value = 1;
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
        public bool UpdateSinhVien(BeanSinhVien sv)
        {
            string sql = "UPDATE SINHVIEN SET HO=@HO,TEN=@TEN,MALOP=@MALOP,PHAI=@PHAI,NGAYSINH=@NGAYSINH,NOISINH=@NOISINH,DIACHI=@DIACHI,GHICHU=@GHICHU,NGHIHOC=@NGHIHOC WHERE MASV=@MASV";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = sv.MASV;
                cmd.Parameters.Add("@HO", SqlDbType.NVarChar).Value = sv.HO;
                cmd.Parameters.Add("@TEN", SqlDbType.NChar).Value = sv.TEN;
                cmd.Parameters.Add("@MALOP", SqlDbType.NChar).Value = sv.MALOP;
                cmd.Parameters.Add("@PHAI", SqlDbType.Bit).Value = sv.PHAI;
                cmd.Parameters.Add("@NGAYSINH", SqlDbType.DateTime).Value = sv.NGAYSINH;
                cmd.Parameters.Add("@NOISINH", SqlDbType.NVarChar).Value = sv.NOISINH;
                cmd.Parameters.Add("@DIACHI", SqlDbType.NChar).Value = sv.DIACHI;
                cmd.Parameters.Add("@GHICHU", SqlDbType.NText).Value = sv.GHICHU;
                cmd.Parameters.Add("@NGHIHOC", SqlDbType.Bit).Value = sv.NGHIHOC;

                //cmd.Parameters.Add("@PHAI", SqlDbType.Bit).Value = 1;
                //cmd.Parameters.Add("@NGHIHOC", SqlDbType.Bit).Value = 1;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
                
            }
            return true;
        }
        public bool DeleteSinhVien(BeanSinhVien sv)
        {
            string sql = "DELETE FROM SINHVIEN WHERE MASV=@MASV";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MASV", SqlDbType.NVarChar).Value = sv.MASV;
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
