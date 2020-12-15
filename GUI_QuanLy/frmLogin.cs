using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BUS_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmLogin : Form
    {
        private BUS_Account busACCOUNT;
        public frmLogin()
        {
            InitializeComponent();
            busACCOUNT = new BUS_Account();
            KHOITAO();
        }

        public void KHOITAO()
        {
            txtUser.Focus();

            txtUser.TabIndex = 0;
            txtPass.TabIndex = 1;
            btnLogin.TabIndex = 2;
            btnThoat.TabIndex = 3;

            AcceptButton = btnLogin;
            CancelButton = btnThoat;
        }
        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "The Bezier";
        }
        private void frmLogin_Load(object sender, EventArgs e)
        {
            skins();
        }

        private void labelControl1_Click(object sender, EventArgs e)
        {

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPass.Text != "" && txtUser.Text != "")
            {
                DataTable dt = new DataTable();
                try
                {
                    dt = busACCOUNT.GetAccountOfPass(txtUser.Text, txtPass.Text);
                }
                catch (Exception)
                {
                    XtraMessageBox.Show("Lấy dữ liệu từ database thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Form frm = new frmMain(row);
                    this.Hide();
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    XtraMessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có muốn thoát?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
