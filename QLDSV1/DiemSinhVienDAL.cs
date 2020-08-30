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
    class DiemSinhVienDAL
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
        public DiemSinhVienDAL()
        {
            dc = new DataConnection();
        }
        public DataTable getDanhSachSV(string malop,string mamh,int lanthi)
        {
            //string sql = "SELECT MASV,HOTEN=HO+''+TEN,DIEM FROM DANHSACH WHERE MALOP=" + "'" + malop + "'";
            string sql = "EXEC SP_BDMH '" + malop + "','" + mamh + "'," + lanthi;
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program.demrow = dt.Rows.Count;
            con.Close();
            return dt;
        }
        
        
        public int checkDiemSV(string masv, string mamh, int lanthi)
        {
            string sql = "SELECT * FROM DIEM WHERE MASV=" + "'" + masv + "'" + " " + "AND MAMH=" + "'" + mamh + "'" + " " + "AND LAN=" + lanthi;
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt.Rows.Count;
        }
        public void InsertDiem(BeanDiemSV dsv, SqlConnection con,SqlTransaction t)
        {
            string sql = "INSERT INTO DIEM(MASV,MAMH,LAN,DIEM) VALUES(@MASV,@MAMH,@LAN,@DIEM)";
            //SqlConnection con = dc.getConnect();
            
                cmd = new SqlCommand(sql, con,t);
                //con.Open();
                cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = dsv.MASV;
                cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = dsv.MAMH;
                cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = dsv.LANTHI;
                cmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = dsv.DIEM;
                cmd.ExecuteNonQuery();
                //con.Close();
            

        }
        public DataTable getdIEM(String masv,string mamh)
        {
            string sql = "SELECT MASV,MAMH,LAN,DIEM FROM DIEM WHERE MASV="+"'"+masv+"'"+" AND MAMH="+"'"+mamh+"'";
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
        public int checkdiem(String masv, string mamh)
        {
            string sql = "SELECT MASV,MAMH,LAN,DIEM FROM DIEM WHERE MASV=" + "'" + masv + "'" + " AND MAMH=" + "'" + mamh + "'";
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
            return dt.Rows.Count;
        }
        public void updateDiem(BeanDiemSV dsv)
        {
            string sql = "UPDATE DIEM SET DIEM=@DIEM WHERE MASV=@MASV AND MAMH=@MAMH AND LAN=@LAN";
            SqlConnection con = dc.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@MASV", SqlDbType.NChar).Value = dsv.MASV;
                cmd.Parameters.Add("@MAMH", SqlDbType.NChar).Value = dsv.MAMH;
                cmd.Parameters.Add("@LAN", SqlDbType.SmallInt).Value = dsv.LANTHI;
                cmd.Parameters.Add("@DIEM", SqlDbType.Float).Value = dsv.DIEM;
                cmd.ExecuteNonQuery();
                //con.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Lỗi");

            }


        }
        //cái này của report
        public DataTable getBangDiemTK(string malop)
        {
            //string sql = "SELECT MASV,HOTEN=HO+''+TEN,DIEM FROM DANHSACH WHERE MALOP=" + "'" + malop + "'";
            string sql = "EXEC SP_BANGDIEMTONGKET " + "'" + malop + "'";
            SqlConnection con = dc.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            Program.demrow = dt.Rows.Count;
            con.Close();
            return dt;
        }
    }
}
