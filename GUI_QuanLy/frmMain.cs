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
using DevExpress.XtraBars;

namespace GUI_QuanLy
{
    public partial class frmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private DataRow rowACCOUNT;
        public frmMain()
        {
            InitializeComponent();
        }
        public frmMain(DataRow row)
        {
            rowACCOUNT = row;
            InitializeComponent();
        }
        public void skins()
        {
            DevExpress.LookAndFeel.DefaultLookAndFeel themes = new DevExpress.LookAndFeel.DefaultLookAndFeel();
            themes.LookAndFeel.SkinName = "The Bezier";
        }
        public void KHOITAO()
        {

            txtUser.Caption = rowACCOUNT[3].ToString();
            int type = Convert.ToInt32(rowACCOUNT[2].ToString());
            if (type == 1)
            {
                btnPhanQuyen.Enabled = true;
            }
            else
            {
                btnPhanQuyen.Enabled = false;
            }

            
        }
        private Form IsActive(Type ftype)
        {
            foreach(Form f in this.MdiChildren)
            {
                if(f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            skins();
            KHOITAO();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsActive(typeof(frmYTa_Truc));
            if(frm == null)
            {
                Form f = new frmYTa_Truc();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsActive(typeof(frmDSYTA));
            if (frm == null)
            {
                Form f = new frmDSYTA();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsActive(typeof(frmCaTruc));
            if (frm == null)
            {
                Form f = new frmCaTruc();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem10_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsActive(typeof(frmBenhNhan));
            if (frm == null)
            {
                Form f = new frmBenhNhan();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem11_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsActive(typeof(frmPhongBenh));
            if (frm == null)
            {
                Form f = new frmPhongBenh();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(XtraMessageBox.Show("Bạn có muốn thoát?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void ribbon_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.statDate.Caption = dateTime.ToString();
        }

        private void barButtonItem3_ItemClick(object sender, ItemClickEventArgs e)
        {
            if(XtraMessageBox.Show("Bạn có muốn đăng xuất không?", "Chú ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Form frm = new frmLogin();
                frm.ShowDialog();
                this.Close();
            }
        }

        private void barButtonItem12_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsActive(typeof(frmPickReport));
            if (frm == null)
            {
                Form f = new frmPickReport();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsActive(typeof(frmChangeAccount));
            if (frm == null)
            {
                Form f = new frmChangeAccount(rowACCOUNT);
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Form frm = IsActive(typeof(frmAccount));
            if (frm == null)
            {
                Form f = new frmAccount();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void barMdiChildrenListItem2_ListItemClick(object sender, ListItemClickEventArgs e)
        {

        }
    }
}