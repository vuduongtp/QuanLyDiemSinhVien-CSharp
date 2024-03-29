﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace QLDSV1
{
    public partial class frmPhongKeToan : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public frmPhongKeToan()
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

        private void frmHocPhi_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            MAGV.Text = "Mã giảng viên: " + Program.username;
            HOTEN.Text = "Họ tên: " + Program.mHoten;
            NHOM.Text = "Nhóm: " + Program.mGroup;
        }

        private void btnDongHocPhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                frmDongHocPhi f = new frmDongHocPhi();
                f.MdiParent = this;
                f.Show();

            }
        }

        private void btnInHocPhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmInHocPhi));
            if (frm != null) frm.Activate();
            else
            {
                frmInHocPhi f = new frmInHocPhi();
                f.MdiParent = this;
                f.Show();

            }
        }

        private void BarButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTaoLogin));
            if (frm != null) frm.Activate();
            else
            {
                frmTaoLogin f = new frmTaoLogin();
                f.MdiParent = this;
                f.Show();

            }
        }
    }
}