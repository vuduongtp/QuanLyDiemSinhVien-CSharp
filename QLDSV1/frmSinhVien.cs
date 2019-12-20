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
    public partial class frmSinhVien : Form
    {
        string chuoiketnoi="";
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

            //chuoiketnoi = "Data Source=VUDUONG;Initial Catalog=QLDSV;Integrated Security=True";
            //Program.conn.ConnectionString = chuoiketnoi;
            //Program.conn.Open();
            //DataTable dt = new DataTable();
            //dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH where TENKHOA not like '%KT%'");
            //cmbChiNhanh.DataSource = dt;
            cmbChiNhanh.DisplayMember = "TENKHOA";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "PGV")
            {
                cmbChiNhanh.Enabled = true;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
            }
            groupBox1.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = false;

        }

        private void cmbChiNhanh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Program.mGroup.Equals("PGV"))
            {
                try
                {
                    Program.servername = cmbChiNhanh.SelectedValue.ToString();
                    Program.mChinhanh = cmbChiNhanh.SelectedIndex;
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
            //else
            //{
            //    MessageBox.Show("Login này không có quyền truy cập dữ liệu của Khoa khác.", "", MessageBoxButtons.OK);
            //}

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Loi ket noi.", "Thông báo", MessageBoxButtons.OK);

            }
            else
            {

                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.dS.LOP);
                // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.
                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);

            }
        }

        
    }
}
