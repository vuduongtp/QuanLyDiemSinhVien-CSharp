using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV1
{
    public partial class XtraReportInPhieuDiem : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportInPhieuDiem(string masv)
        {
            InitializeComponent();

            ds1.EnforceConstraints = false;
            this.sP_INPHIEUDIEMTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INPHIEUDIEMTableAdapter.Fill(ds1.SP_INPHIEUDIEM, masv);
            
        }

    }
}
