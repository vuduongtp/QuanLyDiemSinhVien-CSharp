using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV1
{
    public partial class XtraReportDSTHIHETMON : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportDSTHIHETMON(string malop)
        {
            InitializeComponent();
            this.sP_DSTHIHETMONTableAdapter1.Connection.ConnectionString = Program.connstr;
            ds1.EnforceConstraints = false;
            this.sP_DSTHIHETMONTableAdapter1.Fill(ds1.SP_DSTHIHETMON, malop);
        }

    }
}
