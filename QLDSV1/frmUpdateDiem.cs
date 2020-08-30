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

namespace QLDSV1
{
    public partial class frmUpdateDiem : DevExpress.XtraEditors.XtraForm
    {
        DiemSinhVienDAL dal;
        public frmUpdateDiem()
        {
            InitializeComponent();
            dal = new DiemSinhVienDAL();
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtmasv.Text) || string.IsNullOrEmpty(txtmamh.Text))
            {
                MessageBox.Show("Hãy nhập mã sinh viên và môn học.", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmasv.Focus();
                return false;
            }
            return true;
        }
        public void ShowDiem(string masv, string mamh)
        {
            DataTable dt = dal.getdIEM(masv, mamh);
            table_diem.DataSource = dt;
        }
        private void FormUpdateDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            txtmamh.SelectedIndex = -1;
            simpleButton2.Enabled = false;
        }

        private void Txtmamh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtmamh.SelectedIndex > -1)
            {
                Program.maMHComboBox = txtmamh.SelectedValue.ToString();
                //MessageBox.Show(Program.maMHComboBox);
            }

        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                string masv = txtmasv.Text;
                string mamh = Program.maMHComboBox;
                ShowDiem(masv, mamh);
                if(dal.checkdiem(masv,mamh)==2)
                {
                    MessageBox.Show("Sinh viên này đã nhập điểm 2 lần bạn chỉ sửa được lần 2");
                }
                else if(dal.checkdiem(masv, mamh) == 0)
                {
                    MessageBox.Show("Sinh viên này chưa có điểm");
                }
                simpleButton2.Enabled = true;
            }
        }

        private void Table_diem_Click(object sender, EventArgs e)
        {
            int index = gridView1.FocusedRowHandle;
            if (index >= 0)
            {
                txtlanthi.Text = gridView1.GetRowCellValue(index, "LAN").ToString();
                txtdiem.Text = gridView1.GetRowCellValue(index, "DIEM").ToString();
            }
        }

        private void SimpleButton2_Click(object sender, EventArgs e)
        {
            BeanDiemSV dsv = new BeanDiemSV();
            string masv = txtmasv.Text;
            string mamh = Program.maMHComboBox;
            if(dal.checkdiem(masv, mamh) == 2)
            {
                string lanthi = txtlanthi.Text;
                if(lanthi.Equals("1"))
                {
                    MessageBox.Show("Bạn chỉ có thể sửa điểm lần 2 vui lòng nhập lại");
                }
                else if(lanthi.Equals("2"))
                {
                    dsv.MASV = txtmasv.Text;
                    dsv.MAMH = Program.maMHComboBox;
                    dsv.LANTHI = int.Parse(txtlanthi.Text);
                    dsv.DIEM = txtdiem.Text;
                    dal.updateDiem(dsv);
                    ShowDiem(masv, mamh);
                }
            }
            else if(dal.checkdiem(masv, mamh) == 1)
            {
                dsv.MASV = txtmasv.Text;
                dsv.MAMH = Program.maMHComboBox;
                dsv.LANTHI = int.Parse(txtlanthi.Text);
                dsv.DIEM = txtdiem.Text;
                dal.updateDiem(dsv);
                ShowDiem(masv, mamh);
                MessageBox.Show("Lưu điểm thành công");
            }
            else if(dal.checkdiem(masv, mamh) == 0)
            {
                MessageBox.Show("Sinh viên nay chưa có điểm bạn không thể sửa");
            }
        }
    }
    }