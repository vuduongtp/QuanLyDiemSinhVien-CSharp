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
    public partial class frmMonHoc : Form
    {
        int vitri;
        int chucnang = 0;// xac dinh them, xoa, sua
        string mamh_edit = "";
        string tenmh_edit="";
        // string connstr_origin = Program.connstr;// gan chuoi ket noi mac dinh

        public Stack stack = new Stack();
        public class KhoiPhuc
        {
            int chucnang;
            String maMH;
            String tenMH;
            String lenh;

            public int Chucnang { get => chucnang; set => chucnang = value; }
            public string MaMH { get => maMH; set => maMH = value; }
            public string TenMH { get => tenMH; set => tenMH = value; }
            public string Lenh { get => lenh; set => lenh = value; }
        }


        public frmMonHoc()
        {
            InitializeComponent();
        }

        private void mONHOCBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void frmMonHoc_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DS.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.DS.V_DS_PHANMANH);

            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            //this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
            //// TODO: This line of code loads data into the 'DS.DIEM' table. You can move, or remove it, as needed.
            //// TODO: This line of code loads data into the 'DS.DIEM' table. You can move, or remove it, as needed.
            //this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            //this.dIEMTableAdapter.Fill(this.DS.DIEM);



            //chuoiketnoi = "Data Source=VUDUONG;Initial Catalog=QLDSV;Integrated Security=True";
            //Program.conn.ConnectionString = chuoiketnoi;
            //Program.conn.Open();
            //DataTable dt = new DataTable();
            //dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH where TENKHOA not like '%KT%'");

           // cmbChiNhanh.DataSource = dt;
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
            //mAMHTextEdit.Enabled = tENMHTextEdit.Enabled = false;
        }
        //DataRowView drv = (DataRowView)cmbChiNhanh.SelectedItem;
        //Program.servername = drv["TENSERVER"].ToString();

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
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

            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Loi ket noi.", "Thông báo", MessageBoxButtons.OK);

            }
            else
            {
                stack.Clear();
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
                this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dIEMTableAdapter.Fill(this.DS.DIEM);

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
        
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 1;
            vitri = bdsMonHoc.Position;// giữ lại để khi undo, con trỏ quay về mẩu tin cũ
            cmbChiNhanh.Enabled = false;
            groupBox1.Enabled = true;
            bdsMonHoc.AddNew();
            btnPhucHoi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnTaiLai.Enabled = true;
            mONHOCGridControl.Enabled = btnTaiLai1.Enabled = false;
            //mAMHTextEdit.Enabled = tENMHTextEdit.Enabled = true;
        
        }

        private void mONHOCBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsMonHoc.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        bool check = false;//check xem mon hoc da co diem chua
        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "exec SP_TIMDIEMTUMAMONHOC @mamh= '" + mAMHTextEdit.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            check = Program.myReader.Read();
            chucnang = 2;
            mamh_edit = mAMHTextEdit.Text.Trim();
            tenmh_edit = tENMHTextEdit.Text.Trim();
            cmbChiNhanh.Enabled = false;
            vitri = bdsMonHoc.Position;
            groupBox1.Enabled = true;
            btnPhucHoi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTaiLai1.Enabled = false;
            btnGhi.Enabled = btnTaiLai.Enabled=true;
            mONHOCGridControl.Enabled = false;
            mAMHTextEdit.Enabled = false;
            Program.myReader.Close();
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs ex)
        {
            if (mAMHTextEdit.Text.Trim()=="")
            {
                MessageBox.Show("Mã môn không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (tENMHTextEdit.Text.Trim() == "")
            {
                MessageBox.Show("Tên môn không được để trống. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                return;
            }

            if (Program.myReader != null) Program.myReader.Close();
            String strLenh = "Select TOP 1 MAMH from MONHOC where MAMH = '"+ mAMHTextEdit.Text.Trim() +"'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (chucnang == 1)//them
            {                       
                if (Program.myReader.Read())
                {
                   MessageBox.Show("Mã môn học bị trùng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                   return;
                }
                
            }

            if (chucnang == 2)//sua
            {
                
                if (String.Equals(mAMHTextEdit.Text.Trim(), mamh_edit)==false && check==true)
                {
                    MessageBox.Show("Không thể sửa mã môn học đã có điểm!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }
                if (Program.myReader.Read() && String.Equals(Program.myReader.GetString(0).Trim(), mamh_edit) == false)
                {
                    MessageBox.Show("Mã môn học bị trùng. Vui lòng nhập lại!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }           
            }


            try
                {
                    bdsMonHoc.EndEdit();
                    bdsMonHoc.ResetCurrentItem();
                    this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.mONHOCTableAdapter.Update(this.DS.MONHOC);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Lỗi ghi môn học: " + e, "Thông báo", MessageBoxButtons.OK);
                }

            if (chucnang == 1)//them
            {
                KhoiPhuc kp = new KhoiPhuc();
                kp.Chucnang = chucnang;
                kp.MaMH = mAMHTextEdit.Text.Trim();
                kp.TenMH = tENMHTextEdit.Text.Trim();
                kp.Lenh = "DELETE FROM MONHOC WHERE MAMH ='" + mAMHTextEdit.Text.Trim()+"'";
                stack.Push(kp);
            }
            if (chucnang == 2)//sua
            {
                KhoiPhuc kp = new KhoiPhuc();
                kp.Chucnang = chucnang;
                kp.MaMH = mAMHTextEdit.Text.Trim();
                kp.TenMH = tENMHTextEdit.Text.Trim();
                kp.Lenh= "UPDATE MONHOC SET MAMH=N'"+mamh_edit+"',TENMH=N'"+tenmh_edit+"' WHERE MAMH=N'"+ mAMHTextEdit.Text.Trim()+"'";
                stack.Push(kp);
            }

                groupBox1.Enabled = false;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                btnTaiLai1.Enabled = true;
                btnGhi.Enabled = btnTaiLai.Enabled = false; 
                mONHOCGridControl.Enabled = true;
                mAMHTextEdit.Enabled = true;
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
                    MessageBox.Show("Đã xoá môn học "+kp.TenMH);
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
                    MessageBox.Show("Đã sửa lại môn học " + kp.TenMH);
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
                    MessageBox.Show("Đã thêm lại môn học " + kp.TenMH);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.DS.DIEM);
            if (stack.Count > 0)
            {
                btnPhucHoi.Enabled = true;
            }
            else
            {
                btnPhucHoi.Enabled = false;
            }
        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = false;
            cmbChiNhanh.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnTaiLai1.Enabled = true;
            btnGhi.Enabled = btnTaiLai.Enabled=false;
            mAMHTextEdit.Enabled = true;
            mONHOCGridControl.Enabled = true;
            if (stack.Count > 0)
            {
                btnPhucHoi.Enabled = true;
            }
            else
            {
                btnPhucHoi.Enabled = false;
            }
            this.bdsMonHoc.CancelEdit();
            this.bdsMonHoc.Position=vitri;

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 3;
            bool check_xoa = true;
            if (Program.myReader!=null) Program.myReader.Close();
            String strLenh = "exec SP_TIMDIEMTUMAMONHOC @mamh= '" + mAMHTextEdit.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read())
            {
                MessageBox.Show("Không thể xoá môn học đã có điểm!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá môn học "+tENMHTextEdit.Text.Trim()+" ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                check_xoa = false;
                KhoiPhuc kp = new KhoiPhuc();
                kp.Chucnang = 3;
                kp.MaMH = mAMHTextEdit.Text.Trim();
                kp.TenMH = tENMHTextEdit.Text.Trim();
                kp.Lenh= "INSERT INTO MONHOC(MAMH, TENMH) VALUES('" + mAMHTextEdit.Text.Trim() + "','" + tENMHTextEdit.Text.Trim() + "')";
                stack.Push(kp);

                this.bdsMonHoc.RemoveCurrent();
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Update(this.DS.MONHOC);
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

        private void btnTaiLai1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.DS.DIEM);
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
