using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS_QuanLy;
using DTO_QuanLy;
using DevExpress.XtraEditors;

namespace GUI_QuanLy
{
    public partial class frmBenhNhan : Form
    {
        private BUS_BenhNhan busBENHNHAN;
        private BUS_PhongBenh busPHONGBENH;
        private DTO_BenhNhan dtoBENHNHAN;
        private bool check_flag = false;
        public frmBenhNhan()
        {
            InitializeComponent();
            busBENHNHAN = new BUS_BenhNhan();
            busPHONGBENH = new BUS_PhongBenh();
        }

        public void HienThi()
        {
            //display gridview
            DataTable dt_BN = new DataTable();
            dt_BN = busBENHNHAN.selectALL();
            gridControl1.DataSource = dt_BN;

            //display lookupedit PHONGBENH
            DataTable dt_PB = new DataTable();
            dt_PB = busPHONGBENH.selectAll();
            lueMAPHONG.Properties.DataSource = dt_PB;
            lueMAPHONG.Properties.DisplayMember = "MAPHONG";
            lueMAPHONG.Properties.ValueMember = "MAPHONG";
        }

        public void LockControls()
        {
            //button controls
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            //text edit control
            txtDiaChi.Enabled = false;
            txtHoTen.Enabled = false;
            lueMAPHONG.Enabled = false;
        }
        public void UnLockControls()
        {
            //button controls
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            //text edit control
            txtDiaChi.Enabled = true;
            txtHoTen.Enabled = true;
            lueMAPHONG.Enabled = true;
        }
        public void refreshAll()
        {
            txtDiaChi.ResetText();
            txtHoTen.ResetText();
            txtMaBN.ResetText();
            lueMAPHONG.EditValue = "--Chọn Mã Phòng--";
        }
        public bool checkText()
        {
            if(txtDiaChi.Text.Trim()!=null && txtHoTen.Text.Trim() !=null && lueMAPHONG.EditValue !="--Chọn Mã Phòng--")
            {
                return true;
            }
            return false;
        }


        private void frmBenhNhan_Load(object sender, EventArgs e)
        {
            HienThi();
            LockControls();
            txtMaBN.Enabled = false;
        }

        private void gridBenhNhan_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaBN.Text = gridBenhNhan.GetRowCellValue(gridBenhNhan.FocusedRowHandle, gridBenhNhan.Columns[1]).ToString();
                txtHoTen.Text = gridBenhNhan.GetRowCellValue(gridBenhNhan.FocusedRowHandle, gridBenhNhan.Columns[2]).ToString();
                txtDiaChi.Text = gridBenhNhan.GetRowCellValue(gridBenhNhan.FocusedRowHandle, gridBenhNhan.Columns[3]).ToString();
                lueMAPHONG.EditValue = gridBenhNhan.GetRowCellValue(gridBenhNhan.FocusedRowHandle, gridBenhNhan.Columns[4]);
            }
            catch (Exception)
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            check_flag = true;
            UnLockControls();
            refreshAll();
            txtMaBN.Text = busBENHNHAN.CreateMaBenhNhan();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LockControls();
            refreshAll();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            check_flag = false;
            UnLockControls();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (checkText() == true)
            {
                if (check_flag == true)
                {
                    dtoBENHNHAN = new DTO_BenhNhan(txtMaBN.Text, txtHoTen.Text, txtDiaChi.Text, lueMAPHONG.EditValue.ToString());
                    if (busBENHNHAN.Add(dtoBENHNHAN) == true)
                    {
                        XtraMessageBox.Show("Thêm bệnh nhân có mã" + txtMaBN.Text + " thành công.");
                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm bệnh nhân không thành công!!!");
                    }

                }
                else
                {
                    dtoBENHNHAN = new DTO_BenhNhan(txtMaBN.Text, txtHoTen.Text, txtDiaChi.Text, lueMAPHONG.EditValue.ToString());
                    if (busBENHNHAN.Update(dtoBENHNHAN) == true)
                    {
                        XtraMessageBox.Show("Sửa bệnh nhân có mã" + txtMaBN.Text + " thành công.");
                    }
                    else
                    {
                        XtraMessageBox.Show("Sửa bệnh nhân không thành công!!!");
                    }
                }
                HienThi();
                refreshAll();
                LockControls();
            }
            else
            {
                XtraMessageBox.Show("Chưa điền đủ thông tin!!!");
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string mabenhnhan = gridBenhNhan.GetRowCellValue(gridBenhNhan.FocusedRowHandle, gridBenhNhan.Columns[1]).ToString();
            if (XtraMessageBox.Show("Xác nhận xoá đối tượng?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (busBENHNHAN.Delete(mabenhnhan) == true)
                {
                    XtraMessageBox.Show("Xoá thành công!");
                }
                else
                {
                    XtraMessageBox.Show("Xoá Không Thành công!!!");
                }
                HienThi();
            }
            refreshAll();
        }

        private void lueMAPHONG_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "btnThemPhong")
            {
                frmPhongBenh frm = new frmPhongBenh();
                frm.AddPhong += Frm_AddPhong;
                frm.DeletePhong += Frm_DeletePhong;
                frm.UpdatePhong += Frm_UpdatePhong;
                frm.Show();
            }
        }

        private void Frm_UpdatePhong(object sender, EventArgs e)
        {
            HienThi();
        }

        private void Frm_DeletePhong(object sender, EventArgs e)
        {
            HienThi();
        }

        private void Frm_AddPhong(object sender, EventArgs e)
        {
            HienThi();
        }
    }
}
