﻿using System;
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
    public partial class frmMonHoc : Form
    {
        int vitri;
        string chuoiketnoi;
        int chucnang = 0;// xac dinh them, xoa, sua
        string mamh_edit = "";
        // string connstr_origin = Program.connstr;// gan chuoi ket noi mac dinh

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
            
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.

            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
            // TODO: This line of code loads data into the 'DS.DIEM' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'DS.DIEM' table. You can move, or remove it, as needed.
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.DS.DIEM);



            chuoiketnoi = "Data Source=VUDUONG;Initial Catalog=QLDSV;Integrated Security=True";
            Program.conn.ConnectionString = chuoiketnoi;
            Program.conn.Open();
            DataTable dt = new DataTable();
            dt = Program.ExecSqlDataTable("SELECT * FROM V_DS_PHANMANH where TENKHOA not like '%KT%'");
            cmbChiNhanh.DataSource = dt;
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
            //mAMHTextEdit.Enabled = tENMHTextEdit.Enabled = false;
        }
        //DataRowView drv = (DataRowView)cmbChiNhanh.SelectedItem;
        //Program.servername = drv["TENSERVER"].ToString();

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() != "System.Data.DataRowView")
            {             
                Program.servername = cmbChiNhanh.SelectedValue.ToString();
            }
            if (cmbChiNhanh.SelectedIndex == Program.mChinhanh)
            {
                
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;

            }
            if (cmbChiNhanh.SelectedIndex != Program.mChinhanh && Program.mGroup == "PGV")
                {
                    
                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;

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
                
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
                this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
                this.dIEMTableAdapter.Fill(this.DS.DIEM);

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

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 2;
            mamh_edit = mAMHTextEdit.Text.Trim();
            cmbChiNhanh.Enabled = false;
            vitri = bdsMonHoc.Position;
            groupBox1.Enabled = true;
            btnPhucHoi.Enabled = btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnTaiLai1.Enabled = false;
            btnGhi.Enabled = btnTaiLai.Enabled=true;
            mONHOCGridControl.Enabled = false;
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
            String strLenh = "Select TOP 1 MAMH from LINK0.QLDSV.dbo.MONHOC where MAMH = '"+ mAMHTextEdit.Text.Trim() +"'";
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
                groupBox1.Enabled = false;
                btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
                btnPhucHoi.Enabled = btnTaiLai1.Enabled = true;
                btnGhi.Enabled = btnTaiLai.Enabled = false; 
                mONHOCGridControl.Enabled = true;
                cmbChiNhanh.Enabled = true;
                Program.myReader.Close();

        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnTaiLai_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            groupBox1.Enabled = false;
            cmbChiNhanh.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnPhucHoi.Enabled = btnTaiLai1.Enabled = true;
            btnGhi.Enabled = btnTaiLai.Enabled=false;
            mONHOCGridControl.Enabled = true;
            this.bdsMonHoc.CancelEdit();
            this.bdsMonHoc.Position=vitri;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            chucnang = 3;
            if(Program.myReader!=null) Program.myReader.Close();
            String strLenh = "Select TOP 1 MAMH from LINK0.QLDSV.dbo.DIEM where MAMH = '" + mAMHTextEdit.Text.Trim() + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader.Read())
            {
                MessageBox.Show("Không thể xoá môn học đã có điểm!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Bạn có chắc chắn muốn xoá môn học "+tENMHTextEdit.Text.Trim()+" ?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                this.bdsMonHoc.RemoveCurrent();
                this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
                this.mONHOCTableAdapter.Update(this.DS.MONHOC);
            }
            Program.myReader.Close();
        }

        private void btnTaiLai1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.DS.MONHOC);
            this.dIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.dIEMTableAdapter.Fill(this.DS.DIEM);
        }
    }
}