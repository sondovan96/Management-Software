using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_PhongBenh
    {
        private string MAPHONG;
        private string VITRI;

        public DTO_PhongBenh()
        {

        }
        public DTO_PhongBenh(string mAPHONG, string vITRI)
        {
            this.MAPHONG = mAPHONG;
            this.VITRI = vITRI;
        }

        public string MAPHONG1 { get => MAPHONG; set => MAPHONG = value; }
        public string VITRI1 { get => VITRI; set => VITRI = value; }
    }
}
