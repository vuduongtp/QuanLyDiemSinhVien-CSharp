using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV1
{
    public partial class XtraReportBangDiemTK : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportBangDiemTK(string malop)
        {
            InitializeComponent();
            this.sP_BANGDIEMTONGKETTableAdapter.Connection.ConnectionString = Program.connstr;
            ds1.EnforceConstraints = false;
            this.sP_BANGDIEMTONGKETTableAdapter.Fill(ds1.SP_BANGDIEMTONGKET, malop);
        }

    }
}
