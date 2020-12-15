using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_QuanLy
{
    public partial class frmReport : Form
    {
        private DateTime ngayBD;
        private DateTime ngayKT;
        public frmReport()
        {
            InitializeComponent();
        }
        public frmReport(DateTime Ngaybd,DateTime Ngaykt)
        {
            InitializeComponent();
            ngayBD = Ngaybd;
            ngayKT = Ngaykt;

        }
        public void PrintReport()
        {
            reportPhanCong report = new reportPhanCong();
            report.Parameters["pNgaybd"].Value = ngayBD;
            report.Parameters["pNgaykt"].Value = ngayKT;
            //invisible parameters
            report.Parameters["pNgaybd"].Visible = false;
            report.Parameters["pNgaykt"].Visible = false;
            documentViewer1.DocumentSource = report;
            report.CreateDocument();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            PrintReport();
        }
    }
}
