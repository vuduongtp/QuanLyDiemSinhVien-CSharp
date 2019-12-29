using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV1
{
    public partial class frmChuyenLop : Form
    {
        //string tenkhoa_bandau = "";
        string makhoa_bandau = "";
        string malop_chuyen = "";
        //string tenlop_bandau = "";
        string malop_bandau = "";
        string makhoa_chuyen = "";
        string masv = "";
        int loai_chuyen = 0;

        public class DiemMonHoc
        {
            String maMH;
            int lan;
            float diem;

            public string MaMH { get => maMH; set => maMH = value; }
            public int Lan { get => lan; set => lan = value; }
            public float Diem { get => diem; set => diem = value; }
        }

        public class HocphiSV
        {
            String nienkhoa;
            int hocky;
            int hocphi;
            int sotiendadong;

            public string Nienkhoa { get => nienkhoa; set => nienkhoa = value; }
            public int Hocky { get => hocky; set => hocky = value; }
            public int Hocphi { get => hocphi; set => hocphi = value; }
            public int Sotiendadong { get => sotiendadong; set => sotiendadong = value; }
        }

        List<DiemMonHoc> diemmh = new List<DiemMonHoc>();
        List<HocphiSV> hocphisv = new List<HocphiSV>();

        public frmChuyenLop()
        {
            InitializeComponent();
        }

        private void frmChuyenLop_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            cmbKhoa.Enabled = cmbLop.Enabled = txtMaSVMoi.Enabled = btnChuyenLop.Enabled = false;
            cmbKhoa.SelectedIndex = -1;

        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Program.mGroup.Equals("PGV"))
            {
                try
                {
                    Program.servername = cmbKhoa.SelectedValue.ToString();
                    if (Program.servername.Equals(Program.tenServerDN))
                    {
                        Program.mlogin = Program.mloginDN;
                        Program.password = Program.passwordDN;
                        DataConnection dc = new DataConnection();

                    }
                    else
                    {
                        Program.mlogin = Program.remotelogin;
                        Program.password = Program.remotepassword;
                        DataConnection dc = new DataConnection();

                    }
                }
                catch (Exception)
                {


                }
            }

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Loi ket noi.", "Thông báo", MessageBoxButtons.OK);

            }
            else
            {
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.dS.LOP);

            }
            cmbLop.SelectedIndex = -1;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            masv = txtMaSV.Text.Trim();
            if (masv=="")
            {
                MessageBox.Show("Mã sinh viên không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "exec SP_TIMSVDANGHIHOC @X='" + masv +"'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read())
            {
                MessageBox.Show("Sinh viên có mã " + masv + " đã nghỉ học . Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (Program.myReader != null) Program.myReader.Close();
            String strLenh1 = "exec SP_TIMSV @x='" + masv+"'";
            Program.myReader = Program.ExecSqlDataReader(strLenh1);
            if (Program.myReader.Read())
            {
                labelHoTen.Text = "Họ tên : " + Program.myReader.GetString(1) + " " + Program.myReader.GetString(2);
                labelLop.Text = "Lớp : " + Program.myReader.GetString(4);
                labelMasv.Text = "Mã sinh viên : " + Program.myReader.GetString(0);
                labelNgaySinh.Text = "Ngày sinh : " + Program.myReader.GetDateTime(3).ToString().Split(' ')[0];
                labelKhoa.Text = "Khoa : " + Program.myReader.GetString(5);
                malop_bandau = Program.myReader.GetString(7);
                makhoa_bandau = Program.myReader.GetString(6);
                //tenkhoa_bandau = Program.myReader.GetString(5);
                //tenlop_bandau = Program.myReader.GetString(4);

                cmbKhoa.Enabled = cmbLop.Enabled = true;
                cmbLop.SelectedIndex = 0;
                cmbLop.SelectedIndex = -1;

                //if (Program.myReader != null) Program.myReader.Close();
                //strLenh = "select TOP 1 MALOP FROM LINK0.QLDSV.dbo.SINHVIEN WHERE MASV=N'" + masv + "'";
                //Program.myReader = Program.ExecSqlDataReader(strLenh);
                //if (Program.myReader.Read())
                //{
                //    malop_bandau = Program.myReader.GetString(0);
                //    //MessageBox.Show("Lop." + malop_bandau, "Thông báo", MessageBoxButtons.OK);
                //}

                //if (Program.myReader != null) Program.myReader.Close();
                //strLenh = "select MAKH from LINK0.QLDSV.dbo.LOP,(SELECT MALOP FROM LINK0.QLDSV.dbo.SINHVIEN where SINHVIEN.MASV='" + masv+"') as SV where LOP.MALOP=SV.MALOP";
                //Program.myReader = Program.ExecSqlDataReader(strLenh);
                //if (Program.myReader.Read())
                //{
                //    makhoa_bandau = Program.myReader.GetString(0);
                //    //MessageBox.Show("Lop." + makhoa_bandau, "Thông báo", MessageBoxButtons.OK);
                //}
                
            }
            else
            {

                labelHoTen.Text = "Họ tên : ";
                labelLop.Text = "Lớp :";
                labelMasv.Text = "Mã sinh viên : ";
                labelNgaySinh.Text = "Ngày sinh : ";
                labelKhoa.Text = "Khoa : ";
                //tenkhoa_bandau = "";
                masv = "";
                cmbKhoa.Enabled = cmbLop.Enabled = btnChuyenLop.Enabled =false;
                //bdsHocPhi.DataSource = null; ;
                MessageBox.Show("Không tìm thấy sinh viên có mã " + txtMaSV.Text.Trim() + ". Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            btnChuyenLop.Enabled = false;
            Program.myReader.Close();
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLop.SelectedValue != null)
            {
                malop_chuyen = cmbLop.SelectedValue.ToString();
            }

            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "select MAKH FROM LINK0.QLDSV.dbo.LOP WHERE MALOP='" + malop_chuyen + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read())
            {
                makhoa_chuyen = Program.myReader.GetString(0);
            }
            Program.myReader.Close();
            if (String.Equals(makhoa_bandau, makhoa_chuyen))
            {
                loai_chuyen = 1;
                txtMaSVMoi.Enabled = false;
                txtMaSVMoi.Text = masv;
                btnChuyenLop.Enabled = true;
            }
            else
            {
                loai_chuyen = 2;
                txtMaSVMoi.Enabled = true;
                btnChuyenLop.Enabled = true;
            }
        }

        private void btnChuyenLop_Click(object sender, EventArgs e)
        {
            string masv_moi = txtMaSVMoi.Text.ToString().Trim();
            //MessageBox.Show(masv_moi, "Thông báo", MessageBoxButtons.OK);
            
            if (masv_moi=="")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên mới để chuyển lớp!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (loai_chuyen==1)//chuyen cung khoa
            {
                string lenh = "exec ChuyenLop @x="+masv+" , "+"@ML=N'"+malop_chuyen+"'";
                SqlCommand sqlcom = new SqlCommand(lenh, Program.conn);
                try
                {
                    sqlcom.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                MessageBox.Show("Chuyển thành công sinh viên có mã " + masv + " từ lớp " + malop_bandau + " sang lớp " + malop_chuyen + ".", "Thông báo", MessageBoxButtons.OK);
            }

            if (loai_chuyen == 2)//chuyen khac khoa
            {
                if (Program.myReader != null) Program.myReader.Close();
                String strLenh2 = "exec sp_timdiemtumasinhvien @MASV='" + masv + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh2);
                if (Program.myReader.Read())
                {
                    MessageBox.Show("Sinh viên này đã có điểm, không thể chuyển lớp khác khoa. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                if (Program.myReader != null) Program.myReader.Close();
                String strLenh3 = "exec sp_timhocphitumasinhvien @MASV='" + masv + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh3);
                if (Program.myReader.Read())
                {
                    MessageBox.Show("Sinh viên này đã đóng học phí, không thể chuyển lớp khác khoa. Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                

                if (Program.myReader != null) Program.myReader.Close();
                String strLenh1 = "exec sp_timsv @X='" + masv_moi + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh1);
                if (Program.myReader.Read())
                {
                    MessageBox.Show("Trùng mã sinh viên " + masv_moi + " . Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                Program.myReader.Close();

                String strLenh = "select MASV, HO, TEN, MALOP, PHAI, NGAYSINH, NOISINH, DIACHI, NGHIHOC, GHICHU FROM LINK0.QLDSV.dbo.SINHVIEN WHERE MASV='" + masv + "'";               
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                
                if (Program.myReader.Read())
                {
                    string lenh = "INSERT INTO LINK0.QLDSV.dbo.SINHVIEN(MASV, HO, TEN, MALOP, PHAI, NGAYSINH, NOISINH, DIACHI, NGHIHOC, GHICHU) VALUES(N'" + masv_moi + "',N'" + Program.myReader.GetString(1) + "',N'" + Program.myReader.GetString(2) + "',N'" + malop_chuyen + "','" + Program.myReader.GetBoolean(4) + "'," + Program.myReader.GetDateTime(5).ToString().Split(' ')[0] + ",N'" + Program.myReader.GetString(6) + "',N'" + Program.myReader.GetString(7) + "','" + Program.myReader.GetBoolean(8) + "',N'Mã SV cũ " + masv +" chuyển từ lớp " + malop_bandau+"')";
                    Program.myReader.Close();
                    //MessageBox.Show(lenh);
                    SqlCommand sqlcom = new SqlCommand(lenh, Program.conn);
                    try
                    {
                        sqlcom.ExecuteNonQuery();
                       // MessageBox.Show(strLenh);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                Program.myReader.Close();

                //strLenh = "select MAMH, LAN, DIEM FROM LINK0.QLDSV.dbo.DIEM WHERE MASV='" + masv + "'";
                //Program.myReader = Program.ExecSqlDataReader(strLenh);

                //while(Program.myReader.Read())
                //{
                //    DiemMonHoc diem1 = new DiemMonHoc();
                //    diem1.MaMH = Program.myReader.GetString(0);
                //    diem1.Lan = Int32.Parse(Program.myReader.GetValue(1).ToString());
                //    diem1.Diem = float.Parse(Program.myReader.GetValue(2).ToString());
                //    diemmh.Add(diem1);
                //}
                //Program.myReader.Close();
              
                //strLenh = "select NIENKHOA, HOCKY, HOCPHI, SOTIENDADONG FROM LINK0.QLDSV.dbo.HOCPHI WHERE MASV='" + masv + "'";
                //Program.myReader = Program.ExecSqlDataReader(strLenh);

                //while (Program.myReader.Read())
                //{
                //    HocphiSV hp = new HocphiSV();
                //    hp.Nienkhoa = Program.myReader.GetString(0);
                //    hp.Hocky = Program.myReader.GetInt32(1);
                //    hp.Hocphi = Program.myReader.GetInt32(2);
                //    hp.Sotiendadong = Program.myReader.GetInt32(3);
                //    hocphisv.Add(hp);

                //}
                //Program.myReader.Close();

                //for (int i=0; i<diemmh.Count; i++)
                //{
                //    string lenh = "INSERT INTO LINK0.QLDSV.dbo.DIEM(MASV, MAMH, LAN, DIEM) VALUES(N'" + masv_moi + "',N'" + diemmh[i].MaMH + "'," + diemmh[i].Lan + ","+ diemmh[i].Diem + ")";
                //   // MessageBox.Show(lenh);
                //    SqlCommand sqlcom = new SqlCommand(lenh, Program.conn);
                //    try
                //    {
                //        sqlcom.ExecuteNonQuery();
                //        //MessageBox.Show(strLenh);
                //    }
                //    catch (SqlException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //        return;
                //    }
                //}

                //for (int i = 0; i < hocphisv.Count; i++)
                //{
                //    string lenh = "INSERT INTO LINK0.QLDSV.dbo.HOCPHI(MASV, NIENKHOA, HOCKY, HOCPHI, SOTIENDADONG) VALUES(N'" + masv_moi + "',N'" + hocphisv[i].Nienkhoa + "'," + hocphisv[i].Hocky + "," + hocphisv[i].Hocphi + "," + hocphisv[i].Sotiendadong + ")";
                //    //MessageBox.Show(lenh);
                //    SqlCommand sqlcom = new SqlCommand(lenh, Program.conn);
                //    try
                //    {
                //        sqlcom.ExecuteNonQuery();
                //        //MessageBox.Show(strLenh);
                //    }
                //    catch (SqlException ex)
                //    {
                //        MessageBox.Show(ex.Message);
                //        return;
                //    }
                //}

                string lenh1 = "exec SETNGHIHOC @x='"+masv+"',@GHICHU=N'Chuyển sang lớp " + malop_chuyen+" với mã "+ masv_moi + "'";
                //MessageBox.Show(lenh1);
                SqlCommand sqlcom1 = new SqlCommand(lenh1, Program.conn);
                try
                {
                    sqlcom1.ExecuteNonQuery();
                    //MessageBox.Show(strLenh);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }

                btnChuyenLop.Enabled = false;

                MessageBox.Show("Chuyển thành công sinh viên có mã " + masv + " từ lớp " + malop_bandau + " sang lớp " + malop_chuyen + ". Với mã sinh viên mới là "+ masv_moi + ".", "Thông báo", MessageBoxButtons.OK);
            }

            
        }

    }
}
