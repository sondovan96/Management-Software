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
using DTO_QuanLy;
using BUS_QuanLy;

namespace GUI_QuanLy
{
    public partial class frmDSYTA : Form
    {
        private BUS_DSYTA busDSYTA;
        private DTO_DSYTA dtoDSYTA;
        private bool check_flag = false;

        public frmDSYTA()
        {
            InitializeComponent();
            busDSYTA = new BUS_DSYTA();
        }

        public void HienThi()
        {
            DataTable dt = new DataTable();
            dt = busDSYTA.selectAll();
            gridControl1.DataSource = dt;
            
        }
        public void LockControls()
        {
            //text edit
            txtMayta.Enabled = false;
            txtDiachi.Enabled = false;
            txtHoten.Enabled = false;
            txtSDT.Enabled = false;
            //control button
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
        }

        public void UnlockControls()
        {
            txtDiachi.Enabled = true;
            txtHoten.Enabled = true;
            txtSDT.Enabled = true;
            //control button
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }
        public void RefreshAll()
        {
            txtMayta.ResetText();
            txtDiachi.ResetText();
            txtHoten.ResetText();
            txtSDT.ResetText();
            LockControls();
        }
        public bool checkText()
        {
            if(txtHoten.Text.Trim()!="" && txtDiachi.Text.Trim()!="" && txtSDT.Text.Trim()!="")
            {
                return true;
            }
            return false;
        }
        #region Events
        private void frmDSYTA_Load(object sender, EventArgs e)
        {
            HienThi();
            LockControls();
        }

        private void gridDSYTA_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
            LockControls();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            RefreshAll();
            UnlockControls();
            check_flag = true;
            //create MaYTA
            txtMayta.Text = busDSYTA.CreateMaYTA();

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(check_flag == true)
            {
                if(checkText() == true)
                {
                    if(XtraMessageBox.Show("Bạn có muốn thêm Y Tá mới?","Thông báo",MessageBoxButtons.OKCancel,MessageBoxIcon.Question)==DialogResult.OK)
                    {
                        dtoDSYTA = new DTO_DSYTA(txtMayta.Text, txtHoten.Text, txtSDT.Text, txtDiachi.Text);
                        if (busDSYTA.Add(dtoDSYTA)==true)
                        {
                            XtraMessageBox.Show("Thêm Thành công.");
                            if (addYta != null)
                            {
                                addYta(this, new EventArgs());
                            }

                        }
                        else
                        { 
                            XtraMessageBox.Show("Thêm Không Thành công!!!");
                            return;
                        }       
                        HienThi();
                        RefreshAll();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Chưa điền đủ thông tin!!!");
                }
            }
            else
            {
                if (checkText() == true)
                {
                    if (XtraMessageBox.Show("Bạn có muốn sửa Y Tá có mã:"+txtMayta.Text+"?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        dtoDSYTA = new DTO_DSYTA(txtMayta.Text, txtHoten.Text, txtSDT.Text, txtDiachi.Text);
                        if (busDSYTA.Update(dtoDSYTA)==true)
                        {
                            XtraMessageBox.Show("Sửa Thành công.");
                            if (updateYta != null)
                            {
                                updateYta(this, new EventArgs());
                            }
                        }
                        else
                        {
                            XtraMessageBox.Show("Sửa Không Thành công!!!");
                            return;
                        }
                        HienThi();
                        RefreshAll();
                    }
                }
                else
                {
                    XtraMessageBox.Show("Chưa điền đủ thông tin!!!");
                }
            }
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                txtMayta.Text = gridDSYTA.GetRowCellValue(gridDSYTA.FocusedRowHandle, gridDSYTA.Columns[1]).ToString();
                txtHoten.Text = gridDSYTA.GetRowCellValue(gridDSYTA.FocusedRowHandle, gridDSYTA.Columns[2]).ToString();
                txtSDT.Text = gridDSYTA.GetRowCellValue(gridDSYTA.FocusedRowHandle, gridDSYTA.Columns[3]).ToString();
                txtDiachi.Text = gridDSYTA.GetRowCellValue(gridDSYTA.FocusedRowHandle, gridDSYTA.Columns[4]).ToString();
            }
            catch
            {

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkText() == false)
            {
                XtraMessageBox.Show("Vui lòng chọn 1 dòng để sửa!");
            }
            else
            {
                UnlockControls();
                check_flag = false;
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string mayta = gridDSYTA.GetRowCellValue(gridDSYTA.FocusedRowHandle, gridDSYTA.Columns[1]).ToString();
            if (XtraMessageBox.Show("Xác nhận xoá đối tượng?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(busDSYTA.Delete(mayta) == true)
                {
                    XtraMessageBox.Show("Xoá thành công!");
                    if(deleteYta!=null)
                    {
                        deleteYta(this, new EventArgs());
                    }
                }
                else
                {
                    XtraMessageBox.Show("Xoá Không Thành công!!!");
                    return;
                }
                HienThi();
            }
            RefreshAll();
        }


        private event EventHandler addYta;
        public event EventHandler AddYta
        {
            add { addYta += value; }
            remove { AddYta -= value; }
        }

        private event EventHandler deleteYta;
        public event EventHandler DeleteYta
        {
            add { deleteYta += value; }
            remove { DeleteYta -= value; }
        }

        private event EventHandler updateYta;
        public event EventHandler UpdateYta
        {
            add { updateYta += value; }
            remove { UpdateYta -= value; }
        }


        #endregion
    }
}
