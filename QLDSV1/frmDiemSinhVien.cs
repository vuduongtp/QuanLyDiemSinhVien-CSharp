﻿using System;
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
    public partial class frmDiemSinhVien : DevExpress.XtraEditors.XtraForm
    {
        DiemSinhVienDAL dal;
        DataConnection dc;
        public frmDiemSinhVien()
        {
            InitializeComponent();
            dal = new DiemSinhVienDAL();
            dc = new DataConnection();
            // This line of code is generated by Data Source Configuration Wizard
            monhocTableAdapter1.Fill(ds1.MONHOC);
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtmonhoc.Text)||string.IsNullOrEmpty(txtlanthi.Text)|| string.IsNullOrEmpty(txtlop.Text)|| int.Parse(txtlanthi.Text) >2)
            {
                MessageBox.Show("Bạn chưa nhập lần thi hoặc môn học", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //int lan = int.Parse(lanthi);
                txtmonhoc.Focus();
                txtlanthi.Focus();
                return false;
            }
            return true;
        }
        public bool IsNumber(string pValue)
        {
            foreach (Char c in pValue)
            {
                if (!Char.IsDigit(c))
                    return false;
            }
            return true;
        }
        public void ShowDanhSachSV(string malop,string mamh,int lanthi)
        {
            DataTable dt = dal.getDanhSachSV(malop,mamh,lanthi);
            tableDiem.DataSource = dt;

        }

        private void DiemSinhVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ds1.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            ds1.EnforceConstraints = false;
            this.lOPTableAdapter.Fill(this.ds1.LOP);
            // TODO: This line of code loads data into the 'qLDSVDataSet1.V_DS_PHANMANH2' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANH2TableAdapter.Fill(this.qLDSVDataSet1.V_DS_PHANMANH2);
            btnLuu.Enabled = false;
            cmbDiem.SelectedIndex = -1;
            cmbDiem.SelectedIndex = Program.temp;
            simpleButton1.Enabled = false;
            if (Program.mGroup.Equals("Khoa"))
            {
                cmbDiem.Enabled = false;
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Nhấn lưu lại để lưu");
            //btnSave.Enabled = true;
            int dem = 0;

            string mamh = txtmonhoc.EditValue.ToString();
            int lanthi = int.Parse(txtlanthi.Text);
            string notice = "";
            string notice3 = "Các sinh viên sau đây đã có điểm môn " + mamh + " lần " + 1 + " nếu lưu lại điểm tự động chuyển lần 2  : ";
            string notice1 = "Các sinh viên sau đây đã có điểm môn " + mamh + " lần 1 và 2 nên sẽ không thể lưu sinh viên này : ";
            string notice2 = "Các sinh viên sau đây chưa có điểm lần 1 nên không thể lưu lần 2: ";
            for (int i = 0; i < Program.demrow; i++)
            {
                int index = -1;
                index = i;
                BeanDiemSV dsv = new BeanDiemSV();
                string masv = gridView1.GetRowCellValue(index, "MASV").ToString();


                string string_diem = gridView1.GetRowCellValue(index, "DIEM").ToString();
                if (string.IsNullOrEmpty(string_diem))
                {
                    MessageBox.Show("Vui lòng nhập giá trị");
                    btnSave.Enabled = false;
                    break;
                }
                else
                {
                    double diem = Convert.ToDouble(string_diem);
                    if (diem < 0 || diem > 10)
                    {
                        MessageBox.Show("Bạn nhập giá trị điểm không hợp lệ vui lòng kiểm tra lại trước khi lưu");
                        btnSave.Enabled = false;
                        break;
                    }
                    else
                    {
                        if (lanthi == 1)
                        {
                            dem++;// dem so sinh vien se duoc cap nhat diem
                            if (dal.checkDiemSV(masv, mamh, 1) > 0 && dal.checkDiemSV(masv, mamh, 2) == 0)// lan 1 co diem, lan 2 chua co
                            {
                                notice3 += masv + ",";
                                //notice = notice3;
                            }
                            else if (dal.checkDiemSV(masv, mamh, 1) > 0 && dal.checkDiemSV(masv, mamh, 2) > 0)// lan 1 co diem, lan 2 co
                            {
                                dem--;
                                notice1 += masv + " " + ";";

                            }

                        }
                        if (lanthi == 2)
                        {
                            //dem++;
                            if (dal.checkDiemSV(masv, mamh, 1) > 0 && dal.checkDiemSV(masv, mamh, 2) > 0)// lan 1 co diem, lan 2 co
                            {
                                notice1 += masv + " " + ";";
                                //notice = notice1;
                            }
                            else if (dal.checkDiemSV(masv, mamh, 1) == 0)// lan 1 chua co
                            {

                                notice2 += masv + " " + ";";
                                //btnSave.Enabled = false;
                            }
                            else if (dal.checkDiemSV(masv, mamh, 1) > 0 && dal.checkDiemSV(masv, mamh, 2) == 0)// lan 1 co diem, lan 2 chua co
                            {
                                dem++;
                            }
                        }

                    }


                }


            }
            if (dem == Program.demrow)
            {

                btnLuu.Enabled = true;
            }
            if (lanthi == 1) MessageBox.Show(notice1 + "\n" + notice3);
            if (lanthi == 2) MessageBox.Show(notice1 + "\n" + notice2);
        }

        private void CmbDiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.mGroup.Equals("PGV"))
            {
                try
                {
                    if (cmbDiem.SelectedValue != null)
                    {
                        Program.servername = cmbDiem.SelectedValue.ToString();
                    }
                    if (Program.servername.Equals(Program.tenServerDN))
                    {
                        Program.mlogin = Program.mloginDN;
                        Program.password = Program.passwordDN;
                        DataConnection dc = new DataConnection();
                        dal = new DiemSinhVienDAL();
                        
                        this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                 
                        this.lOPTableAdapter.Fill(this.ds1.LOP);
                    }
                    else
                    {
                        Program.mlogin = Program.remotelogin;
                        Program.password = Program.remotepassword;
                        DataConnection dc = new DataConnection();
                        //MessageBox.Show(Program.servername);
                        
                        dal = new DiemSinhVienDAL();
                        this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;

                        this.lOPTableAdapter.Fill(this.ds1.LOP);
                    }
                       
                }
                catch (Exception)
                {


                }
            }
        }
   
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                string malop = txtlop.Text;
                string mamh = txtmonhoc.EditValue.ToString();
                int lanthi = int.Parse(txtlanthi.Text);
                ShowDanhSachSV(malop, mamh, lanthi);
                btnSave.Enabled = false;
                string notice = "" + Program.demrow;
                simpleButton1.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            DataConnection dc = new DataConnection();
            SqlConnection con = dc.getConnect();
            con.Open();
            SqlTransaction t = con.BeginTransaction();
            try
            {
                int lanthi = int.Parse(txtlanthi.Text);

                for (int i = 0; i < Program.demrow; i++)
                {

                    int index = -1;
                    index = i;
                    BeanDiemSV dsv = new BeanDiemSV();
                    dsv.MASV = gridView1.GetRowCellValue(index, "MASV").ToString();

                    dsv.MAMH = txtmonhoc.EditValue.ToString();

                    dsv.DIEM = gridView1.GetRowCellValue(index, "DIEM").ToString();
                    if (lanthi == 1)
                    {
                        if (dal.checkDiemSV(dsv.MASV, dsv.MAMH, 1) > 0 && dal.checkDiemSV(dsv.MASV, dsv.MAMH, 2) == 0)// lan 1 co diem, lan 2 chua
                        {
                            dsv.LANTHI = int.Parse(txtlanthi.Text) + 1;
                            dal.InsertDiem(dsv, con, t);
                            // MessageBox.Show("Lưu lại thành công");
                        }
                        else if (dal.checkDiemSV(dsv.MASV, dsv.MAMH, 1) > 0 && dal.checkDiemSV(dsv.MASV, dsv.MAMH, 2) > 0)//lan 1 co diem, lan 2 co
                        {
                            MessageBox.Show("Không thể lưu sinh viên này" + dsv.MASV);
                        }
                        else
                        {
                            dsv.LANTHI = int.Parse(txtlanthi.Text);
                            dal.InsertDiem(dsv, con, t);
                            //MessageBox.Show("Lưu lại thành công");
                        }
                    }
                    if (lanthi == 2)
                    {
                        if (dal.checkDiemSV(dsv.MASV, dsv.MAMH, 1) > 0 && dal.checkDiemSV(dsv.MASV, dsv.MAMH, 2) == 0)// lan 1 co diem, lan 2 ko
                        {
                            dsv.LANTHI = int.Parse(txtlanthi.Text);
                            dal.InsertDiem(dsv, con, t);
                            //MessageBox.Show("Lưu lại thành công");
                        }
                        else if (dal.checkDiemSV(dsv.MASV, dsv.MAMH, 1) > 0 && dal.checkDiemSV(dsv.MASV, dsv.MAMH, 2) > 0)// lan 1 lan 2 deu co diem
                        {
                            MessageBox.Show("Không thể lưu sinh viên này" + dsv.MASV);
                        }
                        else if (dal.checkDiemSV(dsv.MASV, dsv.MAMH, 1) == 0)
                        {
                            MessageBox.Show("Không thể lưu "+dsv.MASV);// lan 1 khong co diem
                        }

                    }


                }
                t.Commit();
                MessageBox.Show("Lưu lại thành công");
                btnSave.Enabled = false;
            }
            catch (Exception ex)
            {
                t.Rollback();
                MessageBox.Show("Lỗi "+ex.ToString());
            }

        }

        private void btnSuaDiem_Click(object sender, EventArgs e)
        {
            frmUpdateDiem frm = new frmUpdateDiem();
            //frm.MdiParent = this;
            frm.Show();
        }
    }
}