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
    public partial class formdangnhap : Form
    {
        public formdangnhap()
        {
            InitializeComponent();
        }
        

        private void DangNhap_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet1.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            //this.v_DS_PHANMANHTableAdapter1.Fill(this.qLDSVDataSet1.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'qLDSVDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            //this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSVDataSet.V_DS_PHANMANH);
            string chuoiketnoi = "Data Source=VUDUONG;Initial Catalog=QLDSV;Integrated Security=True";
            Program.conn.ConnectionString = chuoiketnoi;
            Program.conn.Open();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH");
            Program.bds_dspm.DataSource = dt;
            cmbCN.DataSource = dt;
            cmbCN.DisplayMember = "TENKHOA";
            cmbCN.ValueMember = "TENSERVER";
            cmbCN.SelectedIndex = -1;
            cmbCN.SelectedIndex = 0;
          

        }

        private void CmbCN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbCN.SelectedIndex != -1)
                {
                    Program.servername = cmbCN.SelectedValue.ToString();
                    Program.temp = cmbCN.SelectedIndex;
                }
            }
            catch (Exception) { };
        }

        private void Btndangnhap_Click(object sender, EventArgs e)
        {
            if (txtLogin.Text.Trim() == "" || txtPass.Text.Trim() == "")
            {
                MessageBox.Show("Login name và mật mã không được trống", "", MessageBoxButtons.OK);
                return;
            }
            Program.mlogin = txtLogin.Text; Program.password = txtPass.Text;
            if (Program.KetNoi() == 0) return;

            Program.mChinhanh = cmbCN.SelectedIndex;
            Program.tenServerDN = cmbCN.SelectedValue.ToString();
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;
            string strLenh = "EXEC SP_DANGNHAP '" + Program.mlogin + "'";

            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            Program.myReader.Read();
            

            Program.username = Program.myReader.GetString(0);     // Lay user name
            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }
            Program.mHoten = Program.myReader.GetString(1);
            Program.mGroup = Program.myReader.GetString(2);
            Program.myReader.Close();
            Program.conn.Close();
            //MessageBox.Show("Giảng vien - Nhom : " + Program.mHoten + " - " + Program.mGroup, "", MessageBoxButtons.OK);

            //FormClass fLogin = new FormClass();
            //fLogin.Show();
            //SinhVien fsv = new SinhVien();
            //fsv.Show();
            if (String.Equals(Program.mGroup, "PGV") || String.Equals(Program.mGroup, "Khoa"))
            {
                frmMain fm = new frmMain();
                fm.Show();
                //this.Close(); // closes the Form2 instance.
            }
            if (String.Equals(Program.mGroup, "PKeToan"))
            {
                frmPhongKeToan hocphi = new frmPhongKeToan(); // Instantiate a Form3 object.
                hocphi.Show(); // Show Form3 and
                //this.Close(); // closes the Form2 instance.
            }
            
            

        }

        private void thoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
