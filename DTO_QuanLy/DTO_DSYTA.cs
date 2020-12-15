using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_DSYTA
    {
        private string MASOYTA;
        private string HOTEN;
        private string SDT;
        private string DIACHI;

        public DTO_DSYTA()
        {

        }

        public DTO_DSYTA(string mASOYTA, string hOTEN, string sDT, string dIACHI)
        {
            MASOYTA = mASOYTA;
            HOTEN = hOTEN;
            SDT = sDT;
            DIACHI = dIACHI;
        }

        public string MASOYTA1 { get => MASOYTA; set => MASOYTA = value; }
        public string HOTEN1 { get => HOTEN; set => HOTEN = value; }
        public string SDT1 { get => SDT; set => SDT = value; }
        public string DIACHI1 { get => DIACHI; set => DIACHI = value; }
    }
}
