using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors;
using System.Windows.Forms;
using DTO_QuanLy;
using BUS_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmChangeAccount : Form
    {
        private DataRow rowACCOUNT;
        private BUS_Account busACCOUNT;
        private DTO_Account dtoACCOUNT;
        public frmChangeAccount()
        {
            InitializeComponent();
        }
        public frmChangeAccount(DataRow row)
        {
            InitializeComponent();
            rowACCOUNT = row;
            busACCOUNT = new BUS_Account();
        }
        public void KhoiTao()
        {
            txtUser.Text = rowACCOUNT[0].ToString();
            txtUser.Enabled = false;
            
        }
        public bool checkText()
        {
            if(txtpass1.Text=="" || txtpass2.Text=="")
            {
                return false;
            }
            return true;
        }

        private void frmChangeAccount_Load(object sender, EventArgs e)
        {
            KhoiTao();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if(checkText()==true)
            {
                if(txtpass2.Text.Equals(txtpass1.Text))
                {
                    dtoACCOUNT = new DTO_Account(txtUser.Text,txtpass2.Text, Convert.ToInt32(rowACCOUNT[2]),"");
                    if (busACCOUNT.Update(dtoACCOUNT)==true)
                    {
                        XtraMessageBox.Show("Đổi mật khẩu thành công");
                        this.Hide();
                    }
                    else
                    {
                        XtraMessageBox.Show("Đổi mật khẩu không thành công");
                    }
                   
                }
                else
                {
                    XtraMessageBox.Show("Mật khẩu xác nhận không khớp!!!");                
                }
            }
            else
            {
                XtraMessageBox.Show("Chưa Nhập đủ thông tin!!");
            }
            
        }
    }
}
