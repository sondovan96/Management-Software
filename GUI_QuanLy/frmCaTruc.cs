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
    public partial class frmCaTruc : Form
    {
        private BUS_CaTruc busCATRUC;
        private DTO_CaTruc dtoCATRUC;
        private bool check_flag = false;
        public frmCaTruc()
        {
            InitializeComponent();
            busCATRUC = new BUS_CaTruc();
        }

        public void HienThi()
        {
            DataTable dt = new DataTable();
            dt = busCATRUC.selectALL();
            gridControl1.DataSource = dt;
        }

        public void LockControls()
        {
            tsThoiGianTruc.Enabled = false;
            //control button
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnSua.Enabled = true;
        }
        public void UnLockControls()
        {
            tsThoiGianTruc.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnSua.Enabled = false;
        }

        public void RefreshAll()
        {
            txtMaCa.ResetText();
            tsThoiGianTruc.ResetText();
        }

        #region events

        private void frmCaTruc_Load(object sender, EventArgs e)
        {
            txtMaCa.Enabled = false;
            HienThi();
            LockControls();
            
        }

        private void gridCatruc_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
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
                txtMaCa.Text = gridCatruc.GetRowCellValue(gridCatruc.FocusedRowHandle, gridCatruc.Columns[1]).ToString();
                tsThoiGianTruc.EditValue = gridCatruc.GetRowCellValue(gridCatruc.FocusedRowHandle, gridCatruc.Columns[2]).ToString();
            }
            catch
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            UnLockControls();
            check_flag = true;
            RefreshAll();
            txtMaCa.Text = busCATRUC.CreateMaCa();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LockControls();
            RefreshAll();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if(check_flag == true)
            {

                dtoCATRUC = new DTO_CaTruc(txtMaCa.Text,tsThoiGianTruc.EditValue.ToString());
                if(busCATRUC.Add(dtoCATRUC) == true)
                {
                    XtraMessageBox.Show("Thêm thành công ca trực!");
                    if (addCa != null)
                    {
                        addCa(this, new EventArgs());
                    }
                }
                else
                {
                    XtraMessageBox.Show("Thêm thất bại!");
                }
                
            }
            else
            {
                dtoCATRUC = new DTO_CaTruc(txtMaCa.Text, tsThoiGianTruc.EditValue.ToString());
                if (busCATRUC.Update(dtoCATRUC) == true)
                {
                    XtraMessageBox.Show("Sửa thành công ca trực!");
                    if (updateCa != null)
                    {
                        updateCa(this, new EventArgs());
                    }
                }
                else
                {
                    XtraMessageBox.Show("Sửa thất bại!");
                }
            }
            HienThi();
            RefreshAll();
            LockControls();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            check_flag = false;
            UnLockControls();
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string maca = gridCatruc.GetRowCellValue(gridCatruc.FocusedRowHandle, gridCatruc.Columns[1]).ToString();
            if (XtraMessageBox.Show("Xác nhận xoá đối tượng?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(busCATRUC.Delete(maca)==true)
                {
                    XtraMessageBox.Show("Xoá thành công!");
                    if(deleteCa!=null)
                    {
                        deleteCa(this, new EventArgs());
                    }
                }
                else
                {
                    XtraMessageBox.Show("Xoá không thành công!");
                }
                
            }
            HienThi();
            RefreshAll();
        }

        private event EventHandler addCa;
        public event EventHandler AddCa
        {
            add { addCa += value; }
            remove { AddCa -= value; }
        }

        private event EventHandler deleteCa;
        public event EventHandler DeleteCa
        {
            add { deleteCa += value; }
            remove { DeleteCa -= value; }
        }

        private event EventHandler updateCa;
        public event EventHandler UpdateCa
        {
            add { updateCa += value; }
            remove { UpdateCa -= value; }
        }
    #endregion

    }
}
