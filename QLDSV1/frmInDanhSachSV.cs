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
    public partial class frmInDanhSachSV : Form
    {
        string malop = "";
        string tenlop = "";
        public frmInDanhSachSV()
        {
            InitializeComponent();
        }

        private void frmInDanhSachSV_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.lOPTableAdapter.Fill(this.dS.LOP);
            // TODO: This line of code loads data into the 'dS.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.dS.V_DS_PHANMANH);
            comboBox1.SelectedIndex = -1;
            comboBox1.SelectedIndex = Program.mChinhanh;
            btnIn.Enabled = false;
            if (Program.mGroup == "PGV")
            {
                comboBox1.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.mGroup.Equals("PGV"))
            {
                try
                {
                    Program.servername = comboBox1.SelectedValue.ToString();
                    if (Program.servername.Equals(Program.tenServerDN))
                    {
                        Program.mlogin = Program.mloginDN;
                        Program.password = Program.passwordDN;
                        //DataConnection dc = new DataConnection();

                    }
                    else
                    {
                        Program.mlogin = Program.remotelogin;
                        Program.password = Program.remotepassword;
                        //DataConnection dc = new DataConnection();

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
                this.lOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.lOPTableAdapter.Fill(this.dS.LOP);

            }
            comboBox2.SelectedIndex = -1;
            btnIn.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedValue != null)
            {
                malop = comboBox2.SelectedValue.ToString();
                tenlop = comboBox2.Text.ToString();
            }
            btnIn.Enabled = true;
            //MessageBox.Show(malop+"."+tenlop, "Thông báo", MessageBoxButtons.OK);
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            XtraReportInDSSV rpt = new XtraReportInDSSV(malop);
            rpt.xrLabelLop.Text = "Lớp : " + tenlop;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
 }

