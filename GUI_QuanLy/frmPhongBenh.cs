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
    public partial class frmPhongBenh : Form
    {
        private BUS_PhongBenh busPHONGBENH;
        private DTO_PhongBenh dtoPHONGBENH;
        private bool check_flag = false;
        public frmPhongBenh()
        {
            InitializeComponent();
            busPHONGBENH = new BUS_PhongBenh();
        }

        public void HienThi()
        {
            DataTable dt = new DataTable();
            dt = busPHONGBENH.selectAll();
            gridControl1.DataSource = dt;
        }
        public void LockControls()
        {
            //button controls
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
            //text edit control
            txtVitri.Enabled = false;
            txtMaphong.Enabled = false;
        }
        public void UnLockControls()
        {
            //button controls
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
            //text edit control
            txtVitri.Enabled = true;
            txtMaphong.Enabled = true;
        }
        public void refreshAll()
        {
            txtMaphong.ResetText();
            txtVitri.ResetText();
        }
        
        public bool checkText()
        {
            if(txtVitri.Text.Trim()!=null &&txtMaphong.Text.Trim()!=null)
            {
                return true;
            }
            return false;
        }

        #region events
        private void frmPhongBenh_Load(object sender, EventArgs e)
        {
            HienThi();
            LockControls();
        }

        private void gridPhongBenh_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            check_flag = true;
            refreshAll();
            UnLockControls();
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
            txtMaphong.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(checkText()==true)
            {
                if(check_flag == true)
                {
                    dtoPHONGBENH = new DTO_PhongBenh(txtMaphong.Text, txtVitri.Text);
                    if(busPHONGBENH.Add(dtoPHONGBENH)==true)
                    {
                        XtraMessageBox.Show("Thêm phòng bệnh " + txtMaphong.Text + " thành công!");
                        if (addPhong != null)
                        {
                            addPhong(this, new EventArgs());
                        }

                    }
                    else
                    {
                        XtraMessageBox.Show("Thêm phòng bệnh không thành công!!!");
                    }
                }
                else
                {
                    if(checkText()==true)
                    {
                        dtoPHONGBENH = new DTO_PhongBenh(txtMaphong.Text, txtVitri.Text);
                        if (busPHONGBENH.Update(dtoPHONGBENH) == true)
                        {
                            XtraMessageBox.Show("Sửa phòng bệnh " + txtMaphong.Text + " thành công!");
                            if (updatePhong != null)
                            {
                                updatePhong(this, new EventArgs());
                            }

                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa phòng bệnh không thành công!!!");
                        }
                    }
                    else
                    {
                        XtraMessageBox.Show("Chọn dòng cần sửa!");
                    }
                    
                }
                refreshAll();
                LockControls();
                HienThi();
            }
            else
            {
                XtraMessageBox.Show("Chưa nhập đủ dữ liệu!");
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMaphong.Text = gridPhongBenh.GetRowCellValue(gridPhongBenh.FocusedRowHandle, gridPhongBenh.Columns[1]).ToString();
                txtVitri.Text = gridPhongBenh.GetRowCellValue(gridPhongBenh.FocusedRowHandle, gridPhongBenh.Columns[2]).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string maPhong = gridPhongBenh.GetRowCellValue(gridPhongBenh.FocusedRowHandle, gridPhongBenh.Columns[1]).ToString();
            if (XtraMessageBox.Show("Xác nhận xoá đối tượng?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(busPHONGBENH.Delete(maPhong)==true)
                {
                    
                    XtraMessageBox.Show("Xoá thành công!");
                    if (deletePhong != null)
                    {
                        deletePhong(this, new EventArgs());
                    }
                }
                else
                {
                    XtraMessageBox.Show("Xoá Không Thành công!!!");
                }
                HienThi();
            }
            refreshAll();
        }

        private event EventHandler addPhong;
        public event EventHandler AddPhong
        {
            add { addPhong += value; }
            remove { AddPhong -= value; }
        }

        private event EventHandler deletePhong;
        public event EventHandler DeletePhong
        {
            add { deletePhong += value; }
            remove { DeletePhong -= value; }
        }

        private event EventHandler updatePhong;
        public event EventHandler UpdatePhong
        {
            add { updatePhong += value; }
            remove { UpdatePhong -= value; }
        }
        #endregion
    }
}
