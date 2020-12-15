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

namespace GUI_QuanLy
{
    public partial class frmPickReport : Form
    {
        private BUS_YtaTruc busYTATRUC;
        public frmPickReport()
        {
            InitializeComponent();
            busYTATRUC = new BUS_YtaTruc();
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt = busYTATRUC.DateReports(dtpNgaybd.Value,dtpNgaykt.Value);
            gridControl1.DataSource = dt;
        }

        private void frmPickReport_Load(object sender, EventArgs e)
        {

        }

        private void gridPhancong_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column == gridColumn1)
            {
                e.DisplayText = Convert.ToString(e.RowHandle + 1);
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            try
            {
                frmReport f = new frmReport(dtpNgaybd.Value, dtpNgaykt.Value);
                f.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
