namespace QLDSV1
{
    partial class formTaoLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formTaoLogin));
            this.cmbPhanManh = new System.Windows.Forms.ComboBox();
            this.vDSPHANMANH2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qLDSVDataSet1 = new QLDSV1.QLDSVDataSet1();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.v_DS_PHANMANH2TableAdapter = new QLDSV1.QLDSVDataSet1TableAdapters.V_DS_PHANMANH2TableAdapter();
            this.comboNhom = new System.Windows.Forms.ComboBox();
            this.textLogin = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textPassAgain = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbGiangVien = new System.Windows.Forms.ComboBox();
            this.gIANGVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV1.DS();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.sINHVIENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sINHVIENTableAdapter = new QLDSV1.DSTableAdapters.SINHVIENTableAdapter();
            this.gIANGVIENTableAdapter = new QLDSV1.DSTableAdapters.GIANGVIENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANH2BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIANGVIENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbPhanManh
            // 
            this.cmbPhanManh.DataSource = this.vDSPHANMANH2BindingSource;
            this.cmbPhanManh.DisplayMember = "TENKHOA";
            this.cmbPhanManh.FormattingEnabled = true;
            this.cmbPhanManh.Location = new System.Drawing.Point(506, 29);
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
            this.labelControl1.Location = new System.Drawing.Point(431, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(24, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Khoa";
            // 
            // v_DS_PHANMANH2TableAdapter
            // 
            this.v_DS_PHANMANH2TableAdapter.ClearBeforeFill = true;
            // 
            // comboNhom
            // 
            this.comboNhom.FormattingEnabled = true;
            this.comboNhom.Items.AddRange(new object[] {
            "Khoa",
            "PGV"});
            this.comboNhom.Location = new System.Drawing.Point(173, 272);
            this.comboNhom.Name = "comboNhom";
            this.comboNhom.Size = new System.Drawing.Size(121, 21);
            this.comboNhom.TabIndex = 2;
            // 
            // textLogin
            // 
            this.textLogin.Location = new System.Drawing.Point(173, 115);
            this.textLogin.Name = "textLogin";
            this.textLogin.Size = new System.Drawing.Size(121, 21);
            this.textLogin.TabIndex = 3;
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(454, 115);
            this.textPass.Name = "textPass";
            this.textPass.PasswordChar = '*';
            this.textPass.Size = new System.Drawing.Size(121, 21);
            this.textPass.TabIndex = 4;
            // 
            // textPassAgain
            // 
            this.textPassAgain.Location = new System.Drawing.Point(454, 201);
            this.textPassAgain.Name = "textPassAgain";
            this.textPassAgain.PasswordChar = '*';
            this.textPassAgain.Size = new System.Drawing.Size(121, 21);
            this.textPassAgain.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(75, 115);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(72, 13);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "Tên đăng nhập";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(360, 123);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(44, 13);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Mật khẩu";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(360, 204);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(85, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Nhập lại mật khẩu";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(75, 280);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(27, 13);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "Nhóm";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(75, 199);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(66, 13);
            this.labelControl6.TabIndex = 11;
            this.labelControl6.Text = "Mã giảng viên";
            // 
            // cmbGiangVien
            // 
            this.cmbGiangVien.DataSource = this.gIANGVIENBindingSource;
            this.cmbGiangVien.DisplayMember = "MAGV";
            this.cmbGiangVien.FormattingEnabled = true;
            this.cmbGiangVien.Location = new System.Drawing.Point(173, 199);
            this.cmbGiangVien.Name = "cmbGiangVien";
            this.cmbGiangVien.Size = new System.Drawing.Size(121, 21);
            this.cmbGiangVien.TabIndex = 12;
            this.cmbGiangVien.ValueMember = "MAGV";
            // 
            // gIANGVIENBindingSource
            // 
            this.gIANGVIENBindingSource.DataMember = "GIANGVIEN";
            this.gIANGVIENBindingSource.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(454, 258);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(121, 62);
            this.simpleButton1.TabIndex = 13;
            this.simpleButton1.Text = "Đăng kí";
            this.simpleButton1.Click += new System.EventHandler(this.SimpleButton1_Click);
            // 
            // sINHVIENBindingSource
            // 
            this.sINHVIENBindingSource.DataMember = "SINHVIEN";
            this.sINHVIENBindingSource.DataSource = this.dS;
            // 
            // sINHVIENTableAdapter
            // 
            this.sINHVIENTableAdapter.ClearBeforeFill = true;
            // 
            // gIANGVIENTableAdapter
            // 
            this.gIANGVIENTableAdapter.ClearBeforeFill = true;
            // 
            // formTaoLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 431);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.cmbGiangVien);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textPassAgain);
            this.Controls.Add(this.textPass);
            this.Controls.Add(this.textLogin);
            this.Controls.Add(this.comboNhom);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbPhanManh);
            this.Name = "formTaoLogin";
            this.Text = "formTaoLogin";
            this.Load += new System.EventHandler(this.FormTaoLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANH2BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLDSVDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gIANGVIENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sINHVIENBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPhanManh;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private QLDSVDataSet1 qLDSVDataSet1;
        private System.Windows.Forms.BindingSource vDSPHANMANH2BindingSource;
        private QLDSVDataSet1TableAdapters.V_DS_PHANMANH2TableAdapter v_DS_PHANMANH2TableAdapter;
        private System.Windows.Forms.ComboBox comboNhom;
        private System.Windows.Forms.TextBox textLogin;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textPassAgain;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private System.Windows.Forms.ComboBox cmbGiangVien;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DS dS;
        private System.Windows.Forms.BindingSource sINHVIENBindingSource;
        private DSTableAdapters.SINHVIENTableAdapter sINHVIENTableAdapter;
        private System.Windows.Forms.BindingSource gIANGVIENBindingSource;
        private DSTableAdapters.GIANGVIENTableAdapter gIANGVIENTableAdapter;
    }
}