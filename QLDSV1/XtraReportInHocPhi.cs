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
            this.sP_INHOCPHILOPTableAdapter.Fill(ds1.SP_INHOCPHILOP, malop,nienkhoa,hocky);
        }

    }
}
