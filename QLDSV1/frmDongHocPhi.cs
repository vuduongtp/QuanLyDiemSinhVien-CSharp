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
    public partial class frmDongHocPhi : Form
    {
        string masv = "";
        int vitri;
        int chucnang = 0;// xac dinh them, xoa, sua
        int hocky_edit=0;
        string nienkhoa_edit = "";

        public frmDongHocPhi()
        {
            InitializeComponent();
        }

        private void btbTimKiem_Click(object sender, EventArgs e)
        {
            masv = txtMaSV.Text.Trim();
            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "Select TOP 1 MASV,HO,TEN,MALOP from SINHVIEN where MASV = '" + masv + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read())
            {
                txtHoTen.Text = "Họ tên : "+Program.myReader.GetString(1) + " " + Program.myReader.GetString(2);
                txtMaLop.Text = "Mã lớp : "+Program.myReader.GetString(3);
                this.hOCPHITableAdapter.Fill(this.dS.HOCPHI);
                bdsHocPhi.Filter = "MASV = '"+masv+"'";
                gridControl1.Enabled = true;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = true;
                btnPhucHoi.Enabled = true;
            }
            else
            {
                
                gridControl1.Enabled = false;
                txtMaLop.Text = "";
                txtHoTen.Text = "";
                masv = "";
                groupBox2.Enabled = false;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = false;
                btnPhucHoi.Enabled = false;
                btnGhi.Enabled = btnQuayLai.Enabled = btnTaiLai.Enabled = false;
                bdsHocPhi.RemoveFilter();
                //bdsHocPhi.DataSource = null; ;
                MessageBox.Show("Không tìm thấy sinh viên có mã " + masv + ". Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            
        }

        private void frmDongHocPhi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.HOCPHI' table. You can move, or remove it, as needed.
            this.hOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
            //this.hOCPHITableAdapter.Fill(this.dS.HOCPHI);           
            gridControl1.Enabled = false;
            groupBox2.Enabled = false;

            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnPhucHoi.Enabled = false;
            btnGhi.Enabled = btnQuayLai.Enabled = false;

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {        
            chucnang = 1;
            vitri = bdsHocPhi.Position;// giữ lại để khi undo, con trỏ quay về mẩu tin cũ
            groupBox2.Enabled = true;
            bdsHocPhi.AddNew();
            mASVTextEdit.Text = masv;
            btnPhucHoi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = false;
            btnGhi.Enabled = btnQuayLai.Enabled = true;
            gridControl1.Enabled = false;
            btnTimKiem.Enabled = false;
        }

        private void btnQuayLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox2.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnPhucHoi.Enabled = true;
            btnGhi.Enabled = btnQuayLai.Enabled = false;
            gridControl1.Enabled = true;
            this.bdsHocPhi.CancelEdit();
            this.bdsHocPhi.Position = vitri;
            btnTimKiem.Enabled = btnTaiLai.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 3;
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá? ", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.bdsHocPhi.RemoveCurrent();
                this.hOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.hOCPHITableAdapter.Update(this.dS.HOCPHI);
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 2;
            nienkhoa_edit = nIENKHOATextEdit.Text.Trim();
            hocky_edit = Int32.Parse(hOCKYTextEdit.Text.Trim());
            vitri = bdsHocPhi.Position;
            groupBox2.Enabled = true;
            btnPhucHoi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled  = btnTaiLai.Enabled = false;
            btnGhi.Enabled = btnQuayLai.Enabled = true;
            gridControl1.Enabled = false;
            btnTimKiem.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (nIENKHOATextEdit.Text.Trim() == "")
            {
                MessageBox.Show("Niên khoá không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (hOCKYTextEdit.Text.Trim() == "")
            {
                MessageBox.Show("Học kỳ không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (hOCPHITextEdit.Text.Trim() == "")
            {
                MessageBox.Show("Học phí không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (sOTIENDADONGTextEdit.Text.Trim() == "")
            {
                MessageBox.Show("Số tiền đã đóng không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (Int32.Parse(hOCKYTextEdit.Text.Trim()) <1 || Int32.Parse(hOCKYTextEdit.Text.Trim()) >3)
            {
                MessageBox.Show("Chỉ có học kì 1 hoặc 2 hoặc 3. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            string nien_khoa = nIENKHOATextEdit.Text.Trim();
            int hoc_ky = Int32.Parse(hOCKYTextEdit.Text.Trim());
         
            if (chucnang == 1)//them
            {
                if (Program.myReader != null) Program.myReader.Close();
                String strLenh = "Select * from HOCPHI where MASV = N'" + masv + "'";
                Program.myReader = Program.ExecSqlDataReader(strLenh);

                while (Program.myReader.Read()) {
                    if (String.Equals(Program.myReader.GetString(1).Trim(),nien_khoa) && Program.myReader.GetInt32(2)==hoc_ky)
                    {
                        MessageBox.Show("Thông tin học phí bị trùng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                }
            }

            if (chucnang == 2)//sua
            {
                if (Program.myReader != null) Program.myReader.Close();
                String strLenh = "Select * from HOCPHI where MASV = N'" + masv + "' "+ "and (NIENKHOA!=N'"+nienkhoa_edit+"' or HOCKY!="+hocky_edit+")";
                Program.myReader = Program.ExecSqlDataReader(strLenh);
                int count=0;
                while (Program.myReader.Read())
                {
                    count++;
                    if (String.Equals(Program.myReader.GetString(1).Trim(), nien_khoa) && Program.myReader.GetInt32(2) == hoc_ky)
                    {
                        MessageBox.Show("Thông tin học phí bị trùng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                        return;
                    }
                   // Program.myReader["HOCKY"].ToString()
                   
                }
                //MessageBox.Show(strLenh+"Số dòng:"+count, "Thông báo", MessageBoxButtons.OK);
            }
            

            try
            {
                bdsHocPhi.EndEdit();
                bdsHocPhi.ResetCurrentItem();
                this.hOCPHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.hOCPHITableAdapter.Update(this.dS.HOCPHI);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi học phí: " + ex, "Thông báo", MessageBoxButtons.OK);
            }
            groupBox2.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnPhucHoi.Enabled = true;
            btnGhi.Enabled = btnQuayLai.Enabled = false;
            gridControl1.Enabled = true;
            Program.myReader.Close();
            btnTimKiem.Enabled = btnTaiLai.Enabled = true;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {//nut tai lai
            this.hOCPHITableAdapter.Fill(this.dS.HOCPHI);
            bdsHocPhi.Filter = "MASV = '" + masv + "'";
        }
    }
}
