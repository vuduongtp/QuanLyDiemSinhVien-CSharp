using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV1
{
    public partial class XtraReportInHocPhi : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportInHocPhi(string malop,string nienkhoa,int hocky)
        {
            InitializeComponent();
            this.sP_INHOCPHILOPTableAdapter1.Connection.ConnectionString = Program.connstr;
            this.sP_INHOCPHILOPTableAdapter1.Fill(ds1.SP_INHOCPHILOP, malop,nienkhoa,hocky);
        }

    }
}
