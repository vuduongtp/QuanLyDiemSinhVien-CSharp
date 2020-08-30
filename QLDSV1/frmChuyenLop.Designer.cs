namespace QLDSV1
{
    partial class frmChuyenLop
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnChuyenLop = new System.Windows.Forms.Button();
            this.labelKhoa = new System.Windows.Forms.Label();
            this.labelLop = new System.Windows.Forms.Label();
            this.labelNgaySinh = new System.Windows.Forms.Label();
            this.labelMasv = new System.Windows.Forms.Label();
            this.labelHoTen = new System.Windows.Forms.Label();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtMaSVMoi = new System.Windows.Forms.TextBox();
            this.txtMaSV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.lOPBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dS = new QLDSV1.DS();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.vDSPHANMANHBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lOPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vDSPHANMANHBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lOPTableAdapter = new QLDSV1.DSTableAdapters.LOPTableAdapter();
            this.v_DS_PHANMANHTableAdapter = new QLDSV1.DSTableAdapters.V_DS_PHANMANHTableAdapter();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANHBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANHBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.btnChuyenLop);
            this.panel1.Controls.Add(this.labelKhoa);
            this.panel1.Controls.Add(this.labelLop);
            this.panel1.Controls.Add(this.labelNgaySinh);
            this.panel1.Controls.Add(this.labelMasv);
            this.panel1.Controls.Add(this.labelHoTen);
            this.panel1.Controls.Add(this.btnTimKiem);
            this.panel1.Controls.Add(this.txtMaSVMoi);
            this.panel1.Controls.Add(this.txtMaSV);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbLop);
            this.panel1.Controls.Add(this.cmbKhoa);
            this.panel1.Location = new System.Drawing.Point(228, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 397);
            this.panel1.TabIndex = 0;
            // 
            // btnChuyenLop
            // 
            this.btnChuyenLop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.btnChuyenLop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChuyenLop.Location = new System.Drawing.Point(194, 353);
            this.btnChuyenLop.Name = "btnChuyenLop";
            this.btnChuyenLop.Size = new System.Drawing.Size(139, 30);
            this.btnChuyenLop.TabIndex = 5;
            this.btnChuyenLop.Text = "Chuyển lớp";
            this.btnChuyenLop.UseVisualStyleBackColor = false;
            this.btnChuyenLop.Click += new System.EventHandler(this.btnChuyenLop_Click);
            // 
            // labelKhoa
            // 
            this.labelKhoa.AutoSize = true;
            this.labelKhoa.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelKhoa.Location = new System.Drawing.Point(194, 178);
            this.labelKhoa.Name = "labelKhoa";
            this.labelKhoa.Size = new System.Drawing.Size(47, 17);
            this.labelKhoa.TabIndex = 4;
            this.labelKhoa.Text = "Khoa :";
            // 
            // labelLop
            // 
            this.labelLop.AutoSize = true;
            this.labelLop.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelLop.Location = new System.Drawing.Point(194, 150);
            this.labelLop.Name = "labelLop";
            this.labelLop.Size = new System.Drawing.Size(39, 17);
            this.labelLop.TabIndex = 4;
            this.labelLop.Text = "Lớp :";
            // 
            // labelNgaySinh
            // 
            this.labelNgaySinh.AutoSize = true;
            this.labelNgaySinh.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelNgaySinh.Location = new System.Drawing.Point(194, 120);
            this.labelNgaySinh.Name = "labelNgaySinh";
            this.labelNgaySinh.Size = new System.Drawing.Size(74, 17);
            this.labelNgaySinh.TabIndex = 4;
            this.labelNgaySinh.Text = "Ngày sinh :";
            // 
            // labelMasv
            // 
            this.labelMasv.AutoSize = true;
            this.labelMasv.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelMasv.Location = new System.Drawing.Point(194, 61);
            this.labelMasv.Name = "labelMasv";
            this.labelMasv.Size = new System.Drawing.Size(90, 17);
            this.labelMasv.TabIndex = 4;
            this.labelMasv.Text = "Mã sinh viên :";
            // 
            // labelHoTen
            // 
            this.labelHoTen.AutoSize = true;
            this.labelHoTen.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelHoTen.Location = new System.Drawing.Point(194, 92);
            this.labelHoTen.Name = "labelHoTen";
            this.labelHoTen.Size = new System.Drawing.Size(55, 17);
            this.labelHoTen.TabIndex = 4;
            this.labelHoTen.Text = "Họ tên :";
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnTimKiem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTimKiem.Location = new System.Drawing.Point(421, 13);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(88, 34);
            this.btnTimKiem.TabIndex = 3;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // txtMaSVMoi
            // 
            this.txtMaSVMoi.Location = new System.Drawing.Point(297, 296);
            this.txtMaSVMoi.Name = "txtMaSVMoi";
            this.txtMaSVMoi.Size = new System.Drawing.Size(185, 25);
            this.txtMaSVMoi.TabIndex = 2;
            this.txtMaSVMoi.Text = "n16cn34";
            // 
            // txtMaSV
            // 
            this.txtMaSV.Location = new System.Drawing.Point(216, 19);
            this.txtMaSV.Name = "txtMaSV";
            this.txtMaSV.Size = new System.Drawing.Size(185, 25);
            this.txtMaSV.TabIndex = 2;
            this.txtMaSV.Text = "n16cn34";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(121, 256);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Chọn lớp chuyển đến :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Nhập mã sinh viên mới :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Chọn khoa chuyển đến :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập mã sinh viên :";
            // 
            // cmbLop
            // 
            this.cmbLop.DataSource = this.lOPBindingSource1;
            this.cmbLop.DisplayMember = "TENLOP";
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(297, 253);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(185, 25);
            this.cmbLop.TabIndex = 0;
            this.cmbLop.ValueMember = "MALOP";
            this.cmbLop.SelectedIndexChanged += new System.EventHandler(this.cmbLop_SelectedIndexChanged);
            // 
            // lOPBindingSource1
            // 
            this.lOPBindingSource1.DataMember = "LOP";
            this.lOPBindingSource1.DataSource = this.dS;
            // 
            // dS
            // 
            this.dS.DataSetName = "DS";
            this.dS.EnforceConstraints = false;
            this.dS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.DataSource = this.vDSPHANMANHBindingSource1;
            this.cmbKhoa.DisplayMember = "TENKHOA";
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(297, 205);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(185, 25);
            this.cmbKhoa.TabIndex = 0;
            this.cmbKhoa.ValueMember = "TENSERVER";
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // vDSPHANMANHBindingSource1
            // 
            this.vDSPHANMANHBindingSource1.DataMember = "V_DS_PHANMANH";
            this.vDSPHANMANHBindingSource1.DataSource = this.dS;
            // 
            // lOPBindingSource
            // 
            this.lOPBindingSource.DataMember = "LOP";
            this.lOPBindingSource.DataSource = this.dS;
            // 
            // vDSPHANMANHBindingSource
            // 
            this.vDSPHANMANHBindingSource.DataMember = "V_DS_PHANMANH";
            this.vDSPHANMANHBindingSource.DataSource = this.dS;
            // 
            // lOPTableAdapter
            // 
            this.lOPTableAdapter.ClearBeforeFill = true;
            // 
            // v_DS_PHANMANHTableAdapter
            // 
            this.v_DS_PHANMANHTableAdapter.ClearBeforeFill = true;
            // 
            // frmChuyenLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1060, 487);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmChuyenLop";
            this.Text = "Chuyển lớp sinh viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmChuyenLop_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANHBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lOPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vDSPHANMANHBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DS dS;
        private System.Windows.Forms.TextBox txtMaSV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.BindingSource lOPBindingSource;
        private DSTableAdapters.LOPTableAdapter lOPTableAdapter;
        private System.Windows.Forms.BindingSource vDSPHANMANHBindingSource;
        private DSTableAdapters.V_DS_PHANMANHTableAdapter v_DS_PHANMANHTableAdapter;
        private System.Windows.Forms.Label labelLop;
        private System.Windows.Forms.Label labelNgaySinh;
        private System.Windows.Forms.Label labelHoTen;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Label labelMasv;
        private System.Windows.Forms.Label labelKhoa;
        private System.Windows.Forms.Button btnChuyenLop;
        private System.Windows.Forms.TextBox txtMaSVMoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource lOPBindingSource1;
        private System.Windows.Forms.BindingSource vDSPHANMANHBindingSource1;
    }
}