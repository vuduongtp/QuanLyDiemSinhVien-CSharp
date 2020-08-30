using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;

namespace QLDSV1
{
    public partial class formTaoLogin : DevExpress.XtraEditors.XtraForm
    {
        
        LoginDAL dal;
       
        public formTaoLogin()
        {
            InitializeComponent();
            dal = new LoginDAL();
        }

        private void FormTaoLogin_Load(object sender, EventArgs e)
        {
            this.gIANGVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.GIANGVIEN' table. You can move, or remove it, as needed.
            this.gIANGVIENTableAdapter.Fill(this.dS.GIANGVIEN);
            // TODO: This line of code loads data into the 'dS.SINHVIEN' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'qLDSVDataSet1.V_DS_PHANMANH2' table. You can move, or remove it, as needed.

            this.v_DS_PHANMANH2TableAdapter.Fill(this.qLDSVDataSet1.V_DS_PHANMANH2);

            comboNhom.SelectedIndex = 0;
            cmbPhanManh.SelectedIndex = -1;
            cmbPhanManh.SelectedIndex = Program.temp;
            if (Program.mGroup.Equals("Khoa"))
            {
                cmbPhanManh.Enabled = false;
                comboNhom.Enabled = false;
            }
        }

        private void CmbPhanManh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbPhanManh.SelectedValue != null)
                {
                    Program.servername = cmbPhanManh.SelectedValue.ToString();
                }
                if (Program.servername.Equals(Program.tenServerDN))
                {
                    Program.mlogin = Program.mloginDN;
                    Program.password = Program.passwordDN;
                    DataConnection dc = new DataConnection();
                    this.gIANGVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.gIANGVIENTableAdapter.Fill(this.dS.GIANGVIEN);
                    // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.


                }
                else
                {
                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                    DataConnection dc = new DataConnection();
                    this.gIANGVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.gIANGVIENTableAdapter.Fill(this.dS.GIANGVIEN);

                }
            }
            catch (Exception)
            {

                //throw();
            }

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if(dal.CheckLogin(textLogin.Text)>0||dal.CheckUserName(cmbGiangVien.Text)>0)
            {
                MessageBox.Show("Mã giảng viên hoặc tên login đã bị trùng");
            }
            else
            {
                if(textPass.Text.Equals(textPassAgain.Text)==false)
                {
                    MessageBox.Show("Vui lòng nhập hai mật khẩu giống nhau");
                }
                else
                {
                    //MessageBox.Show(textLogin.Text + "," + textPass.Text + "," + cmbGiangVien.Text + "," + comboNhom.Text);
                    if(dal.themTaiKhoan(textLogin.Text, textPass.Text, cmbGiangVien.Text, comboNhom.Text))
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                }
            }
        }
    }
}