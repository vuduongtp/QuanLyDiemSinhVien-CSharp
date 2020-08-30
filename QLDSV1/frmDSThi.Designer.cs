namespace QLDSV1
{
    partial class frmDSThi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDSThi));
            this.cmbPhanManh = new System.Windows.Forms.ComboBox();
            this.vDSPHANMANH2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLDSVDataSet1 = new QLDSV1.QLDSVDataSet1();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV1.DS();
            this.cmbMon = new System.Windows.Forms.ComboBox();
            this.mONHOCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtNgay = new DevExpress.XtraEditors.DateEdit();
            this.v_DS_PHANMANH2TableAdapter = new QLDSV1.QLDSVDataSet1TableAdapters.V_DS_PHANMANH2TableAdapter();
            this.lOPTableAdapter = new QLDSV1.DSTableAdapters.LOPTableAdapter();
            this.mONHOCTableAdapter = new QLDSV1.DSTableAdapters.MONHOCTableAdapter();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtLan = new System.Windows.Forms.ComboBox();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANH2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPhanManh
            // 
            this.cmbPhanManh.DataSource = this.vDSPHANMANH2BindingSource;
            this.cmbPhanManh.DisplayMember = "TENKHOA";
            this.cmbPhanManh.FormattingEnabled = true;
            this.cmbPhanManh.Location = new System.Drawing.Point(176, 45);
            this.cmbPhanManh.Name = "cmbPhanManh";
            this.cmbPhanManh.Size = new System.Drawing.Size(121, 21);
            this.cmbPhanManh.TabIndex = 0;
            this.cmbPhanManh.ValueMember = "TENSERVER";
            this.cmbPhanManh.SelectedIndexChanged += new System.EventHandler(this.CmbPhanManh_SelectedIndexChanged);
            // 
            // vDSPHANMANH2BindingSource
            // 
            this.vDSPHANMANH2BindingSource.DataMember = "V_DS_PHANMANH2";
            this.vDSPHANMANH2BindingSource.DataSource = this.qLDSVDataSet1;
            // 
            // qLDSVDataSet1
            // 
            this.qLDSVDataSet1.DataSetName = "QLDSVDataSet1";
            this.qLDSVDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(56, 100);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(17, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Lớp";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(56, 186);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Môn học";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(56, 259);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(32, 13);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Lần thi";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(56, 330);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(40, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Ngày thi";
            // 
            // cmbLop
            // 
            this.cmbLop.DataSource = this.lOPBindingSource;
            this.cmbLop.DisplayMember = "TENLOP";
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(176, 100);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(121, 21);
            this.cmbLop.TabIndex = 5;
            this.cmbLop.ValueMember = "MALOP";
            this.cmbLop.SelectedIndexChanged += new System.EventHandler(this.ComboBox2_SelectedIndexChanged);
            // 
            // lOPBindingSource
            // 
            this.lOPBindingSource.DataMember = "LOP";
            this.lOPBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbMon
            // 
            this.cmbMon.DataSource = this.mONHOCBindingSource;
            this.cmbMon.DisplayMember = "TENMH";
            this.cmbMon.FormattingEnabled = true;
            this.cmbMon.Location = new System.Drawing.Point(176, 178);
            this.cmbMon.Name = "cmbMon";
            this.cmbMon.Size = new System.Drawing.Size(121, 21);
            this.cmbMon.TabIndex = 6;
            this.cmbMon.ValueMember = "TENMH";
            this.cmbMon.SelectedIndexChanged += new System.EventHandler(this.CmbMon_SelectedIndexChanged);
            // 
            // mONHOCBindingSource
            // 
            this.mONHOCBindingSource.DataMember = "MONHOC";
            this.mONHOCBindingSource.DataSource = this.dS;
            // 
            // txtNgay
            // 
            this.txtNgay.EditValue = null;
            this.txtNgay.Location = new System.Drawing.Point(176, 322);
            this.txtNgay.Name = "txtNgay";
            this.txtNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtNgay.Properties.Mask.EditMask = "";
            this.txtNgay.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtNgay.Properties.MaxValue = new System.DateTime(9999, 12, 31, 0, 0, 0, 0);
            this.txtNgay.Size = new System.Drawing.Size(121, 20);
            this.txtNgay.TabIndex = 7;
            // 
            // v_DS_PHANMANH2TableAdapter
            // 
            this.v_DS_PHANMANH2TableAdapter.ClearBeforeFill = true;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // mONHOCTableAdapter
            // 
            this.mONHOCTableAdapter.ClearBeforeFill = true;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(458, 169);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 38);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "In";
            this.simpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // txtLan
            // 
            this.txtLan.FormattingEnabled = true;
            this.txtLan.Items.AddRange(new object[] {
            "1",
            "2"});
            this.txtLan.Location = new System.Drawing.Point(176, 251);
            this.txtLan.Name = "txtLan";
            this.txtLan.Size = new System.Drawing.Size(121, 21);
            this.txtLan.TabIndex = 10;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(56, 48);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(24, 13);
            this.labelControl5.TabIndex = 11;
            this.labelControl5.Text = "Khoa";
            // 
            // frmDSThi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 394);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtLan);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.cmbMon);
            this.Controls.Add(this.cmbLop);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbPhanManh);
            this.Controls.Add(this.txtNgay);
            this.Name = "frmDSThi";
            this.Text = "formDSThi";
            this.Load += new System.EventHandler(this.FormDSThi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANH2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mONHOCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNgay.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPhanManh;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.ComboBox cmbMon;
        private QLDSVDataSet1 qLDSVDataSet1;
        private System.Windows.Forms.BindingSource vDSPHANMANH2BindingSource;
        private QLDSVDataSet1TableAdapters.V_DS_PHANMANH2TableAdapter v_DS_PHANMANH2TableAdapter;
        private DS dS;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private DSTableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.BindingSource mONHOCBindingSource;
        private DSTableAdapters.MONHOCTableAdapter mONHOCTableAdapter;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        public DevExpress.XtraEditors.DateEdit txtNgay;
        private System.Windows.Forms.ComboBox txtLan;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}