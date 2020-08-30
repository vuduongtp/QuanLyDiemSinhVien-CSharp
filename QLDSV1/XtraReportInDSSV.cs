using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace QLDSV1
{
    public partial class XtraReportInDSSV : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReportInDSSV(string malop)
        {
            InitializeComponent();

            ds1.EnforceConstraints = false;
            this.sP_INDANHSACHSINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.sP_INDANHSACHSINHVIENTableAdapter.Fill(ds1.SP_INDANHSACHSINHVIEN, malop);

        }

    }
}
