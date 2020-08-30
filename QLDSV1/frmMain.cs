using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using System.Data.SqlClient;

namespace QLDSV1
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        DataConnection dc;
        SqlDataAdapter da;
        SqlCommand cmd;
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
        private void BarButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
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

        private void BarButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmClass));
            if (frm != null) frm.Activate();
            else
            {
                frmClass fcl = new frmClass();
                fcl.MdiParent = this;
                fcl.Show();
            }
               
        }

        private void BarButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDiemSinhVien));
            if (frm != null) frm.Activate();
            else
            {
                frmDiemSinhVien dsv = new frmDiemSinhVien();
                dsv.MdiParent = this;
                dsv.Show();
            }
               
            
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Summer");
            //DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Springtime");
            MAGV.Text = "Mã giảng viên: " + Program.username;
            HOTEN.Text = "Họ tên: " + Program.mHoten;
            NHOM.Text = "Nhóm: " + Program.mGroup;
            if (!Program.mGroup.Equals("PGV"))
            {
                barButtonItem8.Enabled = false;
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            //btnMonHoc
            Form frm = this.CheckExists(typeof(frmMonHoc));
            if (frm != null) frm.Activate();
            else
            {
                frmMonHoc mh = new frmMonHoc();
                mh.MdiParent = this;
                mh.Show();
            }
                
        }

        private void BarButtonItem4_ItemClick_1(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmReportBangDiem));
            if (frm != null) frm.Activate();
            else
            {
                frmReportBangDiem frp = new frmReportBangDiem();
                frp.MdiParent = this;
                frp.Show();
            }
                
        }

        private void BarButtonItem5_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmBangDiemTK));
            if (frm != null) frm.Activate();
            else
            {
                frmBangDiemTK frp = new frmBangDiemTK();
                frp.MdiParent = this;
                frp.Show();
            }
                
        }

        private void BarButtonItem6_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmDSThi));
            if (frm != null) frm.Activate();
            else
            {
                frmDSThi frp = new frmDSThi();
                frp.MdiParent = this;
                frp.Show();
            }
        }

        private void BarButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(formTaoLogin));
            if (frm != null) frm.Activate();
            else
            {
                formTaoLogin frp = new formTaoLogin();
                frp.MdiParent = this;
                frp.Show();
            }
        }

        private void BarButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmChuyenLop));
            if (frm != null) frm.Activate();
            else
            {
                frmChuyenLop frp = new frmChuyenLop();
                frp.MdiParent = this;
                frp.Show();
            }
        }

        private void BarButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmInDanhSachSV));
            if (frm != null) frm.Activate();
            else
            {
                frmInDanhSachSV frp = new frmInDanhSachSV();
                frp.MdiParent = this;
                frp.Show();
            }
        }


        private void BarButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmInPhieuDiem));
            if (frm != null) frm.Activate();
            else
            {
                frmInPhieuDiem frp = new frmInPhieuDiem();
                frp.MdiParent = this;
                frp.Show();
            }
        }
    }
}