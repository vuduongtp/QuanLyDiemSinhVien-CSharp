using DevExpress.XtraReports.UI;
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
    public partial class frmInHocPhi : Form
    {
        string malop = "";
        string tenlop = "";
        string nienkhoa = "";
        int hocky;
        public frmInHocPhi()
        {
            InitializeComponent();
        }

        private void frmInHocPhi_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.DANHSACHLOP' table. You can move, or remove it, as needed.
            this.dANHSACHLOPTableAdapter.Fill(this.dS.DANHSACHLOP);
            btnIn.Enabled = false;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue != null)
            {
                malop = comboBox1.SelectedValue.ToString();
                tenlop = comboBox1.Text.ToString();
            }
            btnIn.Enabled = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem != null)
            {
                hocky = Int32.Parse(comboBox2.SelectedItem.ToString());
            }
            btnIn.Enabled = true;
            //MessageBox.Show("Niên khoá không được để trống."+ comboBox2.SelectedItem, "Thông báo", MessageBoxButtons.OK);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (txtNienKhoa.Text.Trim()=="")
            {
                MessageBox.Show("Niên khoá không được để trống.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
                nienkhoa = txtNienKhoa.Text.Trim();
            XtraReportInHocPhi rpt = new XtraReportInHocPhi(malop,nienkhoa,hocky);
            rpt.xrLabelLop.Text = "Lớp : " + tenlop;
            rpt.xrLabelNienKhoa.Text = "Niên khoá : " + nienkhoa;
            rpt.xrLabelHocKy.Text = "Học kỳ : " + hocky;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
