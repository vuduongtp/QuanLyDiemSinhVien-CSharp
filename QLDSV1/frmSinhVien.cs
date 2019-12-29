using System;
using System.Collections;
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
    public partial class frmSinhVien : Form
    {
        
        int vitri_lop = -1;
        int vitri = 0;
        string malop = "";
        int chucnang = 0;
        string chuoikhoiphuc_update = "";
        int nghihoc = -1;
        int phai = -1;

        public Stack stack = new Stack();
        public class KhoiPhuc
        {
            int chucnang;
            String maSV;
            String lenh;

            public int Chucnang { get => chucnang; set => chucnang = value; }
            public string Lenh { get => lenh; set => lenh = value; }
            public string MaSV { get => maSV; set => maSV = value; }
        }

        public frmSinhVien()
        {
            InitializeComponent();
        }
        

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS.V_DS_PHANMANH);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            
            //chuoiketnoi = "Data Source=VUDUONG;Initial Catalog=QLDSV;Integrated Security=True";
            //Program.conn.ConnectionString = chuoiketnoi;
            //Program.conn.Open();
            //DataTable dt = new DataTable();
            //dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH where TENKHOA not like '%KT%'");
            //cmbChiNhanh.DataSource = dt;

            cmbChiNhanh.DisplayMember = "TENKHOA";
            cmbChiNhanh.ValueMember = "TENSERVER";
            cmbChiNhanh.SelectedIndex = -1;
            cmbChiNhanh.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "PGV")
            {
                cmbChiNhanh.Enabled = true;
            }
            else
            {
                cmbChiNhanh.Enabled = false;
                btnGhi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            }
            groupBox1.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = btnTaiLai.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnPhucHoi.Enabled = false;
            btnGhi.Enabled = btnQuayLai.Enabled = false;

        }

        private void cmbChiNhanh_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Program.mGroup.Equals("PGV"))
            {
                try
                {
                    Program.servername = cmbChiNhanh.SelectedValue.ToString();
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
                stack.Clear();
                if (gridViewLop.GetRowCellValue(0, "MALOP")!=null) {
                    this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                    malop = gridViewLop.GetRowCellValue(0, "MALOP").ToString().Trim();
                    bdsSinhVien.Filter = "MALOP = '" + malop + "'";
                }
            }
            if (stack.Count > 0)
            {
                btnPhucHoi.Enabled = true;
            }
            else
            {
                btnPhucHoi.Enabled = false;
            }
        }

        private void gridViewLop_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if (vitri_lop != e.RowHandle)
            {
                bdsSinhVien.RemoveFilter();
                vitri_lop = e.RowHandle;
                malop = gridViewLop.GetRowCellValue(vitri_lop, "MALOP").ToString().Trim();
                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
                bdsSinhVien.Filter = "MALOP = '" + malop + "'";
                if (Program.mGroup == "PGV")
                {
                    btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                }
                // MessageBox.Show(malop, "Thông báo", MessageBoxButtons.OK);
                btnTaiLai.Enabled = true;
            }
            else
            {
                return;
            }
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 1;
            vitri = bdsSinhVien.Position;// giữ lại để khi undo, con trỏ quay về mẩu tin cũ
            groupBox1.Enabled = true;
            mALOPTextEdit.Enabled = false;
            cmbChiNhanh.Enabled = false;
            bdsSinhVien.AddNew();
            nGHIHOCCheckEdit.Enabled = false;
            nGHIHOCCheckEdit.EditValue = false;
            pHAICheckEdit.EditValue = true;
            mALOPTextEdit.Text = malop;
            btnPhucHoi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = false;
            btnGhi.Enabled = btnQuayLai.Enabled = true;
            gridControlSinhVien.Enabled = gridControlLop.Enabled = false;
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //MessageBox.Show("Phai:"+pHAICheckEdit.EditValue.ToString());
            //MessageBox.Show("Nghi hoc: "+nGHIHOCCheckEdit.EditValue.ToString());
            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            bdsSinhVien.Filter = "MALOP = '" + malop + "'";
            if (stack.Count > 0)
            {
                btnPhucHoi.Enabled = true;
            }
            else
            {
                btnPhucHoi.Enabled = false;
            }
        }

        private void btnQuayLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnQuayLai.Enabled = false;
            gridControlSinhVien.Enabled = gridControlLop.Enabled = true;
            this.bdsSinhVien.CancelEdit();
            this.bdsSinhVien.Position = vitri;
            nGHIHOCCheckEdit.Enabled = true;
            mASVTextEdit.Enabled = true;
            btnTaiLai.Enabled = true;
            cmbChiNhanh.Enabled = true;
            if (stack.Count > 0)
            {
                btnPhucHoi.Enabled = true;
            }
            else
            {
                btnPhucHoi.Enabled = false;
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (String.Equals(pHAICheckEdit.EditValue.ToString(),"True"))
            {
                phai = 1;
            }
            else
            {
                phai = 0;
            }
            if (String.Equals(nGHIHOCCheckEdit.EditValue.ToString(), "True"))
            {
                nghihoc = 1;
            }
            else
            {
                nghihoc = 0;
            }
            chuoikhoiphuc_update = "UPDATE SINHVIEN SET MASV=N'" + mASVTextEdit.Text.Trim() + "', HO=N'" + hOTextEdit.Text.Trim() + "', TEN=N'" + tENTextEdit.Text.Trim() + "', MALOP=N'" + mALOPTextEdit.Text.Trim() + "', PHAI=" + phai + ", NGAYSINH=" + nGAYSINHDateEdit.Text.Trim() + ", NOISINH=N'" + nOISINHTextEdit.Text.Trim() + "', DIACHI=N'" + dIACHITextEdit.Text.Trim() + "', NGHIHOC=" + nghihoc + ", GHICHU=N'" + gHICHUTextEdit.Text.Trim() + "'";
            chucnang = 2;
            vitri = bdsSinhVien.Position;
            mALOPTextEdit.Enabled = mASVTextEdit.Enabled=false;
            groupBox1.Enabled = true;
            btnPhucHoi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = false;
            btnGhi.Enabled = btnQuayLai.Enabled = true;
            gridControlSinhVien.Enabled = gridControlLop.Enabled = false;
            cmbChiNhanh.Enabled = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 3;
            bool check_xoa = true;
            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "exec SP_TIMDIEMTUMASINHVIEN @masv= '" + mASVTextEdit.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read())
            {
                MessageBox.Show("Không thể xoá sinh viên đã có điểm!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (Program.myReader != null) Program.myReader.Close();
            strLenh = "exec SP_TIMHOCPHITUMASINHVIEN @masv= '" + mASVTextEdit.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read())
            {
                MessageBox.Show("Không thể xoá sinh viên đã đóng học phí!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá sinh viên có mã " + mASVTextEdit.Text.Trim() + " ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (String.Equals(pHAICheckEdit.EditValue.ToString(), "True"))
                {
                    phai = 1;
                }
                else
                {
                    phai = 0;
                }
                if (String.Equals(nGHIHOCCheckEdit.EditValue.ToString(), "True"))
                {
                    nghihoc = 1;
                }
                else
                {
                    nghihoc = 0;
                }
                check_xoa = false;
                KhoiPhuc kp = new KhoiPhuc();
                kp.Chucnang = 3;
                kp.MaSV = mASVTextEdit.Text.Trim();
                kp.Lenh = "INSERT INTO SINHVIEN(MASV, HO, TEN, MALOP, PHAI, NGAYSINH, NOISINH, DIACHI, NGHIHOC, GHICHU) VALUES(N'" + mASVTextEdit.Text.Trim() + "',N'" + hOTextEdit.Text.Trim() + "',N'" + tENTextEdit.Text.Trim() + "',N'" + mALOPTextEdit.Text.Trim() + "'," + phai + "," + nGAYSINHDateEdit.Text.Trim() + ",N'" + nOISINHTextEdit.Text.Trim() + "',N'" + dIACHITextEdit.Text.Trim() + "'," + nghihoc + ",N'" + gHICHUTextEdit.Text.Trim() + "')";
                stack.Push(kp);

                this.bdsSinhVien.RemoveCurrent();
                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);
                check_xoa = true;
            }
            if (check_xoa == false)
            {
                stack.Pop();
            }
            Program.myReader.Close();
            if (stack.Count > 0)
            {
                btnPhucHoi.Enabled = true;
            }
            else
            {
                btnPhucHoi.Enabled = false;
            }
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (mASVTextEdit.Text.Trim() == "" || hOTextEdit.Text.Trim() == "" || tENTextEdit.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên, họ, tên không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (nGAYSINHDateEdit.Text.Trim() == "" || nOISINHTextEdit.Text.Trim()=="" || dIACHITextEdit.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh, nơi sinh, địa chỉ không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "exec SP_TIMSV @X= '" + mASVTextEdit.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (chucnang == 1)//them
            {
                if (Program.myReader.Read())
                {
                    MessageBox.Show("Mã sinh viên học bị trùng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

            }

            //if (chucnang == 2)//sua
            //{

                
            //}


            try
            {
                bdsSinhVien.EndEdit();
                bdsSinhVien.ResetCurrentItem();
                this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.sINHVIENTableAdapter.Update(this.dS.SINHVIEN);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi sinh viên: " + ex, "Thông báo", MessageBoxButtons.OK);
            }

            if (chucnang == 1)//them
            {
                KhoiPhuc kp = new KhoiPhuc();
                kp.Chucnang = chucnang;
                kp.MaSV = mASVTextEdit.Text.Trim();
                kp.Lenh = "DELETE FROM SINHVIEN WHERE MASV =N'" + mASVTextEdit.Text.Trim() + "'";
                stack.Push(kp);
            }
            if (chucnang == 2)//sua
            {
                KhoiPhuc kp = new KhoiPhuc();
                kp.Chucnang = chucnang;
                kp.MaSV = mASVTextEdit.Text.Trim();
                kp.Lenh = chuoikhoiphuc_update + " WHERE MASV=N'"+mASVTextEdit.Text.Trim()+"'";
                stack.Push(kp);
            }


            groupBox1.Enabled = false;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnTaiLai.Enabled = true;
            btnGhi.Enabled = btnQuayLai.Enabled = false;
            gridControlSinhVien.Enabled = gridControlLop.Enabled= true;
            mASVTextEdit.Enabled = true;
            nGHIHOCCheckEdit.Enabled = true;
            cmbChiNhanh.Enabled = true;
            if (stack.Count > 0)
            {
                btnPhucHoi.Enabled = true;
            }
            else
            {
                btnPhucHoi.Enabled = false;
            }
            Program.myReader.Close();
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            KhoiPhuc kp = (KhoiPhuc)stack.Pop();
            if (kp.Chucnang == 1)//them
            {

                SqlCommand sqlcom = new SqlCommand(kp.Lenh, Program.conn);
                try
                {
                    sqlcom.ExecuteNonQuery();
                    MessageBox.Show("Đã xoá sinh viên có mã " + kp.MaSV);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            if (kp.Chucnang == 2)//sua
            {
                SqlCommand sqlcom = new SqlCommand(kp.Lenh, Program.conn);
                try
                {
                    sqlcom.ExecuteNonQuery();
                    MessageBox.Show("Đã sửa lại sinh viên có mã " + kp.MaSV);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(kp.Lenh);
                }
            }

            if (kp.Chucnang == 3)//xoa
            {
                SqlCommand sqlcom = new SqlCommand(kp.Lenh, Program.conn);
                try
                {
                    sqlcom.ExecuteNonQuery();
                    MessageBox.Show("Đã thêm lại sinh viên có mã " + kp.MaSV);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(kp.Lenh);
                }
            }

            this.sINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sINHVIENTableAdapter.Fill(this.dS.SINHVIEN);
            bdsSinhVien.Filter = "MALOP = '" + malop + "'";
            if (stack.Count > 0)
            {
                btnPhucHoi.Enabled = true;
            }
            else
            {
                btnPhucHoi.Enabled = false;
            }
        }
    }
}
