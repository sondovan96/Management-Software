using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;
using DevExpress.XtraEditors;

namespace GUI_QuanLy
{
    public partial class frmAccount : Form
    {
        private BUS_Account busACCOUNT;
        private DTO_Account dtoACCOUNT;
        private bool check_flag = false;
        public frmAccount()
        {
            InitializeComponent();
            busACCOUNT = new BUS_Account();
        }

        public void HienThi()
        {
            DataTable dt = new DataTable();
            dt = busACCOUNT.selectAll();
            gridControl1.DataSource = dt;
        }
        public void LockControls()
        {
            //text edit
            txtUser.Enabled = false;
            txtPass.Enabled = false;
            //control button
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            rdbIT.Checked = true;
            rdbCatruc.Enabled = false;
            rdbIT.Enabled = false;
        }

        public void UnlockControls()
        {
            txtPass.Enabled = true;
            txtUser.Enabled = true;
            //control button
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            rdbCatruc.Enabled = true;
            rdbIT.Enabled = true;
        }
        public void RefreshAll()
        {
            txtUser.ResetText();
            txtPass.ResetText();
            
        }
        public bool checkText()
        {
            if(txtPass.Text =="" ||txtUser.Text == "")
            {
                return false;
            }
            return true;
        }
        public int checkBox()
        {
            if(rdbIT.Checked==true)
            {
                return 1;
            }
            return 2;
        }
        private void frmAccount_Load(object sender, EventArgs e)
        {
            HienThi();
            LockControls();
        }

        private void gridAccount_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if(txtUser.Text !="")
            {
                if (XtraMessageBox.Show("Bạn có muốn đặt lại mật khẩu mặc định?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (busACCOUNT.ResetAccount(txtUser.Text) == true)
                    {
                        XtraMessageBox.Show("Reset mật khẩu thành công! Mật khẩu mặc định là 1");
                    }
                    else
                    {
                        XtraMessageBox.Show("Reset mật khẩu không thành công!");
                    }
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa chọn User để đặt!");
            }
           
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                txtUser.Text = gridAccount.GetRowCellValue(gridAccount.FocusedRowHandle, gridAccount.Columns[1]).ToString();
                txtPass.Text = gridAccount.GetRowCellValue(gridAccount.FocusedRowHandle, gridAccount.Columns[2]).ToString();
                int loai = Convert.ToInt32(gridAccount.GetRowCellValue(gridAccount.FocusedRowHandle, gridAccount.Columns[3]));
                if(loai ==1)
                {
                    rdbIT.Checked = true;
                }
                else
                {
                    rdbCatruc.Checked = true;
                }
            }
            catch
            {

            }
        }
        private void btnLammoi_Click(object sender, EventArgs e)
        {
            RefreshAll();
            LockControls();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            check_flag = true;
            UnlockControls();
            RefreshAll();
            rdbIT.Checked = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if(txtUser.Text!="")
            {
                check_flag = false;
                UnlockControls();
                txtUser.Enabled = false;
            }
            else
            {
                XtraMessageBox.Show("Chọn 1 user để sửa!");
            }
           
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(check_flag == true)
            {
                if(checkText()==true)
                {
                    dtoACCOUNT = new DTO_Account(txtUser.Text, "", checkBox(), txtPass.Text);
                    if(busACCOUNT.Add(dtoACCOUNT)==true)
                    {
                        XtraMessageBox.Show("Thêm Account thành công!");
                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm Account thất bại!");
                    }
                    
                }
                else
                {
                    XtraMessageBox.Show("Chưa nhập đủ dữ liệu");
                }
                HienThi();
                LockControls();
            }
            else
            {
                if (checkText() == true)
                {
                    dtoACCOUNT = new DTO_Account(txtUser.Text, "", checkBox(), txtPass.Text);
                    if (busACCOUNT.UpdateDisplay(dtoACCOUNT) == true)
                    {
                        XtraMessageBox.Show("Sửa Account thành công!");
                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa Account thất bại!");
                    }
                }
                else
                {
                    XtraMessageBox.Show("Chưa nhập đủ dữ liệu");
                }
                HienThi();
                LockControls();
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string user = gridAccount.GetRowCellValue(gridAccount.FocusedRowHandle, gridAccount.Columns[1]).ToString();
            if (XtraMessageBox.Show("Bạn có muốn xóa user "+ user + "?","Thông báo!",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if(busACCOUNT.DeleteAccount(user) ==true)
                {
                    XtraMessageBox.Show("Xóa thành công!!!");
                }
                else
                {
                    XtraMessageBox.Show("Xóa không thành công!!!");
                }
                HienThi();
            }
        }
    }
}
