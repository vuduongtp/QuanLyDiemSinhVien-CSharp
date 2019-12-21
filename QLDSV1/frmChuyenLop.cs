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
        string tenkhoa_bandau = "";
        string makhoa_bandau = "";
        string malop_chuyen = "";
        string tenlop_bandau = "";
        string malop_bandau = "";
        string makhoa_chuyen = "";
        string masv = "";
        int loai_chuyen = 0;
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
            String strLenh = "select MASV,HO,TEN,NGAYSINH,TENLOP,TENKH from(select MASV, MALOP, HO, TEN, NGAYSINH from LINK0.QLDSV.dbo.SINHVIEN where SINHVIEN.MASV = '"+masv+"') as SV,LINK0.QLDSV.dbo.LOP,LINK0.QLDSV.dbo.KHOA where LOP.MALOP = SV.MALOP and KHOA.MAKH = LOP.MAKH";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read())
            {
                labelHoTen.Text = "Họ tên : " + Program.myReader.GetString(1) + " " + Program.myReader.GetString(2);
                labelLop.Text = "Lớp : " + Program.myReader.GetString(4);
                labelMasv.Text = "Mã sinh viên : " + Program.myReader.GetString(0);
                labelNgaySinh.Text = "Ngày sinh : " + Program.myReader.GetDateTime(3).ToString().Split(' ')[0];
                labelKhoa.Text = "Khoa : " + Program.myReader.GetString(5);
                //tenkhoa_bandau = Program.myReader.GetString(5);
                //tenlop_bandau = Program.myReader.GetString(4);

                cmbKhoa.Enabled = cmbLop.Enabled = true;
                cmbLop.SelectedIndex = 0;
                cmbLop.SelectedIndex = -1;

                if (Program.myReader != null) Program.myReader.Close();
                strLenh = "select TOP 1 MALOP FROM SINHVIEN WHERE MASV=N'" + masv + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader.Read())
                {
                    malop_bandau = Program.myReader.GetString(0);
                    //MessageBox.Show("Lop." + malop_bandau, "Thông báo", MessageBoxButtons.OK);
                }

                if (Program.myReader != null) Program.myReader.Close();
                strLenh = "select MAKH from LOP,(SELECT MALOP FROM SINHVIEN where SINHVIEN.MASV='"+masv+"') as SV where LOP.MALOP=SV.MALOP";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader.Read())
                {
                    makhoa_bandau = Program.myReader.GetString(0);
                    //MessageBox.Show("Lop." + makhoa_bandau, "Thông báo", MessageBoxButtons.OK);
                }
            }
            else
            {

                labelHoTen.Text = "Họ tên : ";
                labelLop.Text = "Lớp :";
                labelMasv.Text = "Mã sinh viên : ";
                labelNgaySinh.Text = "Ngày sinh : ";
                labelKhoa.Text = "Khoa : ";
                tenkhoa_bandau = "";
                masv = "";
                cmbKhoa.Enabled = cmbLop.Enabled = false;
                //bdsHocPhi.DataSource = null; ;
                MessageBox.Show("Không tìm thấy sinh viên có mã " + txtMaSV.Text.Trim() + ". Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            Program.myReader.Close();
        }

        private void cmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLop.SelectedValue != null)
            {
                malop_chuyen = cmbLop.SelectedValue.ToString();
            }

            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "select MAKH FROM LOP WHERE MALOP='" + malop_chuyen + "'";
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
            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "select NGHIHOC FROM SINHVIEN WHERE MASV='" + masv + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read() && Program.myReader.GetBoolean(0) == true)
            {
                MessageBox.Show("Sinh viên có mã " + masv + " đã nghỉ học . Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            Program.myReader.Close();

            if (txtMaSVMoi.Text.Trim()=="")
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên mới để chuyển lớp!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (loai_chuyen==1)//chuyen cung khoa
            {
                string lenh = "UPDATE SINHVIEN SET MALOP = N'"+malop_chuyen+"' WHERE MASV=N'"+masv+"'";
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
                MessageBox.Show("Chuyển thành công sinh viên có mã " + masv + " từ lớp " + malop_bandau + " sang lớp " + malop_chuyen + ".1", "Thông báo", MessageBoxButtons.OK);
            }

            if (loai_chuyen == 2)//chuyen khac khoa
            {
                if (Program.myReader != null) Program.myReader.Close();
                strLenh = "select MASV FROM LINK0.QLDSV.dbo.SINHVIEN WHERE MASV='" + txtMaSVMoi.Text + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                if (Program.myReader.Read())
                {
                    MessageBox.Show("Trùng mã sinh viên " + txtMaSVMoi.Text + " . Vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                Program.myReader.Close();
                strLenh = "select MASV, HO, TEN, MALOP, PHAI, NGAYSINH, NOISINH, DIACHI, NGHIHOC, GHICHU FROM LINK0.QLDSV.dbo.SINHVIEN WHERE MASV='" + masv + "'";
                
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                
                if (Program.myReader.Read())
                {
                    string lenh = "INSERT INTO SINHVIEN(MASV, HO, TEN, MALOP, PHAI, NGAYSINH, NOISINH, DIACHI, NGHIHOC, GHICHU) VALUES(N'" + txtMaSVMoi.Text + "',N'" + Program.myReader.GetString(1) + "',N'" + Program.myReader.GetString(2) + "',N'" + malop_chuyen + "','" + Program.myReader.GetBoolean(4) + "'," + Program.myReader.GetDateTime(5).ToString().Split(' ')[0] + ",N'" + Program.myReader.GetString(6) + "',N'" + Program.myReader.GetString(7) + "','" + Program.myReader.GetBoolean(8) + "',N'Chuyển từ lớp "+malop_bandau+" qua')";
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


                MessageBox.Show("Chuyển thành công sinh viên có mã " + masv + " từ lớp " + malop_bandau + " sang lớp " + malop_chuyen + ". Với mã sinh viên mới là "+txtMaSV.Text+".", "Thông báo", MessageBoxButtons.OK);
            }

            
        }

    }
}
