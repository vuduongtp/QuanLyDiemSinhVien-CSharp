﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLDSV1
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private Form CheckExists(Type ftype)//kiem tra form da mo chua
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }


        private void btnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();

            }
        }

        private void frmMain_Load_1(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Springtime");
            MAGV.Text = "Mã giảng viên: " + Program.username;
            HOTEN.Text = "Họ tên: " + Program.mHoten;
            NHOM.Text = "Nhóm: " + Program.mGroup;
            if (Program.mGroup != "PGV")
            {
                btnChuyenLop.Enabled = false;
            }
        }

        private void btnSinhVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmSinhVien));
            if (frm != null) frm.Activate();
            else
            {
                frmSinhVien f = new frmSinhVien();
                f.MdiParent = this;
                f.Show();

            }
        }

        private void btnChuyenLop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmChuyenLop));
            if (frm != null) frm.Activate();
            else
            {
                frmChuyenLop f = new frmChuyenLop();
                f.MdiParent = this;
                f.Show();

            }
        }

        private void btnInDSSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmInDanhSachSV));
            if (frm != null) frm.Activate();
            else
            {
                frmInDanhSachSV f = new frmInDanhSachSV();
                f.MdiParent = this;
                f.Show();

            }
        }

        private void btnInPhieuDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmInPhieuDiem));
            if (frm != null) frm.Activate();
            else
            {
                frmInPhieuDiem f = new frmInPhieuDiem();
                f.MdiParent = this;
                f.Show();

            }
        }
    }
}
