using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV1
{
    public partial class XtraReportBangDiemSV : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportBangDiemSV(string malop,string mamh,int lanthi)
        {
            InitializeComponent();
            this.sP_BANGDIEMTableAdapter1.Connection.ConnectionString = Program.connstr;
            ds4.EnforceConstraints = false;
            this.sP_BANGDIEMTableAdapter1.Fill(ds4.SP_BANGDIEM, malop, mamh, lanthi);

        }

    }
}
