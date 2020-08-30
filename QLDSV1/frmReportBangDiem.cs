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
using DevExpress.XtraReports.UI;

namespace QLDSV1
{
    public partial class frmReportBangDiem : DevExpress.XtraEditors.XtraForm
    {

        public frmReportBangDiem()
        {
            InitializeComponent();
        }

        private void FormReportBangDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet1.V_DS_PHANMANH2' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANH2TableAdapter.Fill(this.qLDSVDataSet1.V_DS_PHANMANH2);
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.mONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.mONHOCTableAdapter.Fill(this.dS.MONHOC);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            

            cmbTenLop.SelectedIndex = 0;
            Program.rptMalop = cmbTenLop.SelectedValue.ToString();
            cmbMonHoc.SelectedIndex = 0;
            cmbkhoa.SelectedIndex = -1;
            cmbkhoa.SelectedIndex = Program.temp;
            Program.rptMaMh = cmbMonHoc.SelectedValue.ToString();
            if (Program.mGroup.Equals("Khoa"))
            {
                cmbkhoa.Enabled = false;
            }
        }

        private void SimpleButton1_Click(object sender, EventArgs e)
        {
            XtraReportBangDiemSV rpt = new XtraReportBangDiemSV(Program.rptMalop, Program.rptMaMh, int.Parse(txtLan.Text));
            rpt.xrLop.Text = cmbTenLop.Text;
            rpt.xrMh.Text = cmbMonHoc.Text;
            rpt.xrlan.Text = txtLan.Text;
            rpt.xrNL.Text = Program.mHoten;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();

        }

        private void CmbTenLop_SelectedIndexChanged(object sender, EventArgs e)
        {



            try
            {
                if (cmbTenLop.SelectedValue != null)
                {
                    Program.rptMalop = cmbTenLop.SelectedValue.ToString();
                }
                //MessageBox.Show(Program.rptMalop);
            }
            catch (Exception)
            {


            }

        }

        private void CmbMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbMonHoc.SelectedValue != null) {
                    Program.rptMaMh = cmbMonHoc.SelectedValue.ToString();
                    }
                //MessageBox.Show(Program.rptMaMh);
            }
            catch (Exception)
            {


            }
        }

        private void Cmbkhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbkhoa.SelectedValue != null)
                {
                    Program.servername = cmbkhoa.SelectedValue.ToString();
                }
                if (Program.servername.Equals(Program.tenServerDN))
                {
                    Program.mlogin = Program.mloginDN;
                    Program.password = Program.passwordDN;
                    DataConnection dc = new DataConnection();
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Fill(this.dS.LOP);
                    // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
                   

                }
                else
                {
                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                    DataConnection dc = new DataConnection();
                    this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.lOPTableAdapter.Fill(this.dS.LOP);

                }
            }
            catch (Exception)
            {

                
            }
            

        }
    }
}