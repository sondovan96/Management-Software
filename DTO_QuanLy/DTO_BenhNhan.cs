using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_BenhNhan
    {
        private string MASOBN;
        private string HOTEN;
        private string DIACHI;
        private string MAPHONG;

        //CONSTRUCTOR
        public DTO_BenhNhan()
        {

        }

        public DTO_BenhNhan(string mASOBN, string hOTEN, string dIACHI, string mAPHONG)
        {
            MASOBN = mASOBN;
            HOTEN = hOTEN;
            DIACHI = dIACHI;
            MAPHONG = mAPHONG;
        }

        public string MASOBN1 { get => MASOBN; set => MASOBN = value; }
        public string HOTEN1 { get => HOTEN; set => HOTEN = value; }
        public string DIACHI1 { get => DIACHI; set => DIACHI = value; }
        public string MAPHONG1 { get => MAPHONG; set => MAPHONG = value; }
    }
}
