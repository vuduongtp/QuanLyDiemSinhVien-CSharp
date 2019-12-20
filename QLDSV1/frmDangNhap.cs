using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLDSV1
{
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            // this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSVDataSet.V_DS_PHANMANH);
            string chuoiketnoi = "Data Source=VUDUONG;Initial Catalog=QLDSV;Integrated Security=True";
            Program.conn.ConnectionString = chuoiketnoi;
            Program.conn.Open();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH");
            tENKHOAComboBox.DataSource = dt;
            tENKHOAComboBox.DisplayMember = "TENKHOA";
            tENKHOAComboBox.ValueMember = "TENSERVER";
            tENKHOAComboBox.SelectedIndex = 1;
            tENKHOAComboBox.SelectedIndex = 0;

        }

        private void tENKHOAComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = tENKHOAComboBox.SelectedValue.ToString();
            }
            catch (Exception) { };
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "")
            {
                MessageBox.Show("Tài khoản không được để trống.", "Lỗi", MessageBoxButtons.OK);
                txtLogin.Focus();
                return;
            }
            Program.mlogin = txtLogin.Text;
            Program.password = txtPass.Text;
            if (Program.KetNoi() == 0) return;
            // MessageBox.Show("Đăng nhập thành công.", "", MessageBoxButtons.OK);
            Program.mChinhanh = tENKHOAComboBox.SelectedIndex;// gan vi tri da duoc chon: 0 1 2
            Program.mloginDN = Program.mlogin;// giu lại tk va mk dang nhap
            Program.passwordDN = Program.password;
            string strLenh = "EXEC SP_DANGNHAP '" + Program.mlogin + "'";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();


            Program.username = Program.myReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login này không có quyền truy cập dữ liệu\n Hãy xem lại username, password", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.tenServerDN = tENKHOAComboBox.ValueMember.ToString();
            Program.myReader.Close();
            Program.conn.Close();
            //Program.frmChinh.MAGV.Text = "Mã giảng viên: " + Program.username;
            //Program.frmChinh.HOTEN.Text = "Họ tên: " + Program.mHoten;
            //Program.frmChinh.NHOM.Text = "Nhóm: " + Program.mGroup;

            if(String.Equals(Program.mGroup,"PGV") || String.Equals(Program.mGroup, "Khoa")){
                frmMain main = new frmMain(); // Instantiate a Form3 object.
                main.Show(); // Show Form3 and
                //this.Close(); // closes the Form2 instance.
            }
            if (String.Equals(Program.mGroup, "PKeToan"))
            {
                frmPhongKeToan hocphi = new frmPhongKeToan(); // Instantiate a Form3 object.
                hocphi.Show(); // Show Form3 and
                //this.Close(); // closes the Form2 instance.
            }
            //MessageBox.Show("Đăng nhập thành công.", "Thông báo", MessageBoxButtons.OK);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
