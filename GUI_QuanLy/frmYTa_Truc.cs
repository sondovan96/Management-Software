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
using DevExpress.Utils.Win;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraLayout;
using DTO_QuanLy;
using LookUpEdit_Add_Button_To_Popup;

namespace GUI_QuanLy
{
    public partial class frmYTa_Truc : Form
    {
        BUS_YtaTruc busYTATRUC;
        BUS_CaTruc busCATRUC;
        BUS_DSYTA busDSYTA;
        BUS_PhongBenh busPHONGBENH;
        DTO_YTaTruc dtoYTATRUC;
        private bool flag_Insert = false;
        private string mayta;
        public frmYTa_Truc()
        {
            InitializeComponent();

            busYTATRUC = new BUS_YtaTruc();
            busCATRUC = new BUS_CaTruc();
            busPHONGBENH = new BUS_PhongBenh();
            busDSYTA = new BUS_DSYTA();

        }
        public void HIENTHI()
        {
            //load grid look up MA Y TA
            DataTable dtMaYTA = new DataTable();
            dtMaYTA = busDSYTA.selectAll();
            gridLUMaYta.Properties.DataSource = dtMaYTA;
            gridLUMaYta.Properties.DisplayMember = "MASOYTA";
            gridLUMaYta.Properties.ValueMember = "MASOYTA";

            //load grid look up Ma Ca
            DataTable dtMaCa = new DataTable();
            dtMaCa = busCATRUC.selectALL();
            gridLUMaCa.Properties.DataSource = dtMaCa;
            gridLUMaCa.Properties.DisplayMember = "MACA";
            gridLUMaCa.Properties.ValueMember = "MACA";

            //load grid look up Ma PHONG
            DataTable dtMaPhong = new DataTable();
            dtMaPhong = busPHONGBENH.selectAll();
            gridLUMaPhong.Properties.DataSource = dtMaPhong;
            gridLUMaPhong.Properties.DisplayMember = "MAPHONG";
            gridLUMaPhong.Properties.ValueMember = "MAPHONG";

            //load gridview PHAN CONG
            DataTable dtPhancong = new DataTable();
            dtPhancong = busYTATRUC.selectAll();
            gridControl1.DataSource = dtPhancong;
        }
        
        public void LockControl()
        {
            gridLUMaYta.Enabled = false;
            gridLUMaPhong.Enabled = false;
            gridLUMaCa.Enabled = false;
            dtpNgay.Enabled = false;
            //control button
            btnLuu.Enabled = false;
            btnThem.Enabled = true;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
        }

        public void UnLockControl()
        {
            gridLUMaYta.Enabled = true;
            gridLUMaPhong.Enabled = true;
            gridLUMaCa.Enabled = true;
            dtpNgay.Enabled = true;
            //control button
            btnLuu.Enabled = true;
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
        }

        private void frmDS_YTa_Load(object sender, EventArgs e)
        {
            //// TODO: This line of code loads data into the 'qL_CATRUCDataSet.YTA_TRUC' table. You can move, or remove it, as needed.
            //this.yTA_TRUCTableAdapter.Fill(this.qL_CATRUCDataSet.YTA_TRUC);
            HIENTHI();
            LockControl();

        }

        public void resetAll()
        {
            gridLUMaYta.EditValue = "--Chọn Mã Y Tá--";
            gridLUMaCa.EditValue = "--Chọn Mã Ca--";
            gridLUMaPhong.EditValue = "--Chọn Mã Phòng--";
            dtpNgay.ResetText();
            LockControl();
        }

        private void gridPhancong_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetAll();
            HIENTHI();
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            resetAll();
            UnLockControl();
            flag_Insert = true;
        }

        private void gridControl1_Click(object sender, EventArgs e)
        {
            try
            {
                gridLUMaYta.EditValue = gridPhancong.GetRowCellValue(gridPhancong.FocusedRowHandle, gridPhancong.Columns[1]);
                gridLUMaCa.EditValue = gridPhancong.GetRowCellValue(gridPhancong.FocusedRowHandle, gridPhancong.Columns[3]);
                dtpNgay.Text = gridPhancong.GetRowCellValue(gridPhancong.FocusedRowHandle, gridPhancong.Columns[5]).ToString();
                gridLUMaPhong.EditValue = gridPhancong.GetRowCellValue(gridPhancong.FocusedRowHandle, gridPhancong.Columns[6]);
            }
            catch
            {

            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            mayta = gridPhancong.GetRowCellValue(gridPhancong.FocusedRowHandle, gridPhancong.Columns[1]).ToString();
            string maca = gridPhancong.GetRowCellValue(gridPhancong.FocusedRowHandle, gridPhancong.Columns[3]).ToString();
            if(flag_Insert == true)
            {
                try
                {
                    dtoYTATRUC = new DTO_YTaTruc(gridLUMaYta.EditValue.ToString(), gridLUMaCa.EditValue.ToString(), dtpNgay.Value, gridLUMaPhong.EditValue.ToString());
                    busYTATRUC.Add(dtoYTATRUC);
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }
                XtraMessageBox.Show("Thêm thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                HIENTHI();
            }
            else
            {
                try
                {
                    dtoYTATRUC = new DTO_YTaTruc(mayta, maca, dtpNgay.Value, gridLUMaPhong.EditValue.ToString());
                    busYTATRUC.Update(dtoYTATRUC);
                }
                catch (Exception ex)
                {

                    XtraMessageBox.Show(ex.Message);
                }
                XtraMessageBox.Show("Sửa thông tin thành công!", "Thông báo", MessageBoxButtons.OK);
                HIENTHI();
            }
            resetAll();

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridLUMaYta.EditValue.Equals("--Chọn Mã Y Tá--"))
            {
                XtraMessageBox.Show("Vui lòng chọn 1 dòng để sửa!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                UnLockControl();
                gridLUMaYta.Enabled = false;
                gridLUMaCa.Enabled = false;
                flag_Insert = false;
            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridLUMaYta.EditValue.Equals("--Chọn Mã Y Tá--"))
            {
                XtraMessageBox.Show("Vui lòng chọn 1 dòng để xoá!", "Thông báo", MessageBoxButtons.OK);
            }
            else
            {
                if (XtraMessageBox.Show("Xác nhận xoá đối tượng?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    busYTATRUC.Delete(gridLUMaYta.EditValue.ToString(), gridLUMaCa.EditValue.ToString());
                    XtraMessageBox.Show("Xoá thành công!");
                    HIENTHI();
                }
            }
            resetAll();
        }

        private void btnEdit_Delete_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            mayta = gridPhancong.GetRowCellValue(gridPhancong.FocusedRowHandle, gridPhancong.Columns[1]).ToString();
            string maca = gridPhancong.GetRowCellValue(gridPhancong.FocusedRowHandle, gridPhancong.Columns[3]).ToString();
            if (XtraMessageBox.Show("Xác nhận xoá đối tượng?", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    busYTATRUC.Delete(mayta, maca);
                    //gridPhancong.DeleteSelectedRows();
                    XtraMessageBox.Show("Xoá thành công!");
                    HIENTHI();
                }
            
            resetAll();
        }



        private void gridLUMaYta_Properties_Popup(object sender, EventArgs e)
        {

        }

        private void gridLUMaYta_Properties_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "btnThemYTa")
            {
                frmDSYTA frm = new frmDSYTA();
                frm.AddYta += Frm_AddYta;
                frm.DeleteYta += Frm_DeleteYta;
                frm.UpdateYta += Frm_UpdateYta;
                frm.Show();
            }
        }

        private void Frm_UpdateYta(object sender, EventArgs e)
        {
            HIENTHI();
        }

        private void Frm_DeleteYta(object sender, EventArgs e)
        {
            HIENTHI();
        }

        private void Frm_AddYta(object sender, EventArgs e)
        {
            HIENTHI();
        }

        private void gridLUMaPhong_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            HIENTHI();
        }

        private void Frm_DeletePhong(object sender, EventArgs e)
        {
            HIENTHI();
        }

        private void Frm_AddPhong(object sender, EventArgs e)
        {
            HIENTHI();
        }

        private void gridLUMaCa_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Tag == "btnThemCaTruc")
            {
                frmCaTruc frm = new frmCaTruc();
                frm.AddCa += Frm_AddCa;
                frm.UpdateCa += Frm_UpdateCa;
                frm.DeleteCa += Frm_DeleteCa;
                frm.Show();
            }
        }

        private void Frm_DeleteCa(object sender, EventArgs e)
        {
            HIENTHI();
        }

        private void Frm_UpdateCa(object sender, EventArgs e)
        {
            HIENTHI();
        }

        private void Frm_AddCa(object sender, EventArgs e)
        {
            HIENTHI();
        }
    }
}
