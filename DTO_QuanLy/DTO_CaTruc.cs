using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_CaTruc
    {
        private string MACA;
        private string THOIGIANTRUC;
        public DTO_CaTruc()
        {

        }
        public DTO_CaTruc(string mACA, string tHOIGIANTRUC)
        {
            this.MACA = mACA;
            this.THOIGIANTRUC = tHOIGIANTRUC;
        }

        public string MACA1 { get => MACA; set => MACA = value; }
        public string THOIGIANTRUC1 { get => THOIGIANTRUC; set => THOIGIANTRUC = value; }
    }
}
