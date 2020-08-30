using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Data.SqlClient;
using System.Collections;

namespace QLDSV1
{
    public partial class frmClass : DevExpress.XtraEditors.XtraForm
    {
        SqlDataAdapter da;
        SqlCommand cmd;

        LopBLL lobll;
        String temp1="";
        String temp2="";
        String temp3="";
        //List<Lop> list = new List<Lop>();
        Stack<Lop> st = new Stack<Lop>();
        public frmClass()
        {
            InitializeComponent();
            lobll = new LopBLL();
        }
        public void ShowAllLop()
        {
            DataTable dt = lobll.getAllLop();
            dataGridView1.DataSource = dt;
        }
        public bool CheckData()
        {
            if (string.IsNullOrEmpty(txtMaLop.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã sinh viên", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtMaLop.Focus();
                return false;
            }
            return true;
        }
        private void FormClass_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLDSVDataSet1.V_DS_PHANMANH2' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANH2TableAdapter.Fill(this.qLDSVDataSet1.V_DS_PHANMANH2);
            // TODO: This line of code loads data into the 'qLDSVDataSet.V_DS_PHANMANH' table. You can move, or remove it, as needed.
            this.v_DS_PHANMANHTableAdapter.Fill(this.qLDSVDataSet.V_DS_PHANMANH);
            ShowAllLop();
            notice.Caption = Program.mHoten;
            notice2.Caption ="-"+ Program.mGroup;
            txtMaLop.Text = dataGridView1.Rows[0].Cells["MALOP"].Value.ToString();
            txtTenLop.Text = dataGridView1.Rows[0].Cells["TENLOP"].Value.ToString();
            txtMaKhoa.Text = dataGridView1.Rows[0].Cells["MAKH"].Value.ToString();
            if (lobll.checkDeleteLop(dataGridView1.Rows[0].Cells["MALOP"].Value.ToString()) > 0)
            {
                
                btnXoa.Enabled = false;
            }
            else
            {
                if(Program.mGroup.Equals("Khoa")) btnXoa.Enabled = false;
                else btnXoa.Enabled = true;
            }
            //test
            cmb1.SelectedIndex = -1;
            cmb1.SelectedIndex = Program.temp;
            if(Program.mGroup.Equals("Khoa"))
            {
                cmb1.Enabled = false;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                barButtonItem1.Enabled = false;
                barButtonItem2.Enabled = false;
                barButtonItem3.Enabled = false;
                dataGridView1.ReadOnly=true;
            }
            
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(Program.mGroup.Equals("PGV"))
            {
                try
                {
                    if (cmb1.SelectedValue != null)
                    {
                        Program.servername = cmb1.SelectedValue.ToString();
                    }
                    Program.mlogin = Program.remotelogin;
                    Program.password = Program.remotepassword;
                    DataConnection dc = new DataConnection();


                    //Program.KetNoi();
                    lobll = new LopBLL();

                    ShowAllLop();
                    txtMaLop.Text = dataGridView1.Rows[0].Cells["MALOP"].Value.ToString();
                    txtTenLop.Text = dataGridView1.Rows[0].Cells["TENLOP"].Value.ToString();
                    txtMaKhoa.Text = dataGridView1.Rows[0].Cells["MAKH"].Value.ToString();

                }
                catch (Exception)
                {


                }
            }
           
        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {

                txtMaLop.Text = dataGridView1.Rows[index].Cells["MALOP"].Value.ToString();
                txtTenLop.Text = dataGridView1.Rows[index].Cells["TENLOP"].Value.ToString();
                txtMaKhoa.Text = dataGridView1.Rows[index].Cells["MAKH"].Value.ToString();

                temp1 = dataGridView1.Rows[index].Cells["MALOP"].Value.ToString();
                temp2 = dataGridView1.Rows[index].Cells["TENLOP"].Value.ToString();
                temp3 = dataGridView1.Rows[index].Cells["MAKH"].Value.ToString();
                if (lobll.checkDeleteLop(dataGridView1.Rows[index].Cells["MALOP"].Value.ToString()) > 0)
                {

                    btnXoa.Enabled = false;
                }
                else
                {
                    if (Program.mGroup.Equals("Khoa")) btnXoa.Enabled = false;
                    else btnXoa.Enabled = true;
                }

            }
        }

        private void BtnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaLop.Text = "";
            txtTenLop.Text = "";
            
        }

        private void BarButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (lobll.CheckMaLop(txtMaLop.Text)> 0)
            {
                MessageBox.Show("Mã lớp không hợp lệ");
                //return 0;
            }
            if (CheckData()&& lobll.CheckMaLop(txtMaLop.Text) == 0)
            {
                Lop l = new Lop();
                l.MALOP = txtMaLop.Text;
                l.TENLOP = txtTenLop.Text;
                l.MAKH = txtMaKhoa.Text;
                if (lobll.InsertLop(l))
                {
                    ShowAllLop();

                }

                else
                {
                    MessageBox.Show("Đã có lỗi", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BarButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckData())
            {

                Lop l = new Lop();
                l.MALOP = txtMaLop.Text;
                l.TENLOP = txtTenLop.Text;
                l.MAKH = txtMaKhoa.Text;
                if (lobll.UpdateLop(l))
                {
                    ShowAllLop();
                }
                else
                {
                    MessageBox.Show("Đã có lỗi", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BtnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (CheckData())
            {
                Lop l = new Lop();
                l.MALOP = txtMaLop.Text;
                l.TENLOP = txtTenLop.Text;
                l.MAKH = txtMaKhoa.Text;
                st.Push(l);
                if (MessageBox.Show("Ban muon xoa khong", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (lobll.Delete(l))
                    {
                        ShowAllLop();
                    }
                    else
                    {
                        MessageBox.Show("Đã có lỗi", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                
            }
        }

        private void BarButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //txtMaLop.Text=temp1;
            //txtTenLop.Text=temp2;
            //txtMaKhoa.Text=temp3;
            if(st.Count>0)
            {
                Lop l = st.Pop();
                if (lobll.InsertLop(l))
                {
                    ShowAllLop();
                    //MessageBox.Show("Phục hồi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
            else
            {
                MessageBox.Show("Không có dữ liệu nào được xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void BarButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            txtMaLop.Text = temp1;
            txtTenLop.Text = temp2;
        }
    }
}