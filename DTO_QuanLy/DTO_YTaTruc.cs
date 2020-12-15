using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_YTaTruc
    {
        private string MASOYTA;
        private string MACA;
        private DateTime NGAY;
        private string MAPHONG;

        public DTO_YTaTruc(string mASOYTA, string mACA, DateTime nGAY, string mAPHONG)
        {
            this.MASOYTA = mASOYTA;
            this.MACA = mACA;
            this.NGAY = nGAY;
            this.MAPHONG = mAPHONG;
        }

        public string MASOYTA1 { get => MASOYTA; set => MASOYTA = value; }
        public string MACA1 { get => MACA; set => MACA = value; }
        public DateTime NGAY1 { get => NGAY; set => NGAY = value; }
        public string MAPHONG1 { get => MAPHONG; set => MAPHONG = value; }
    }
}
