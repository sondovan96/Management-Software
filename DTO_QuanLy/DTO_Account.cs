using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QuanLy
{
    public class DTO_Account
    {
        private string user;
        private string pass;
        private int type;
        private string display;

        public DTO_Account(string user, string pass, int type, string display)
        {
            this.user = user;
            this.pass = pass;
            this.type = type;
            this.display = display;
        }

        public string User { get => user; set => user = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Type { get => type; set => type = value; }
        public string Display { get => display; set => display = value; }
    }
}
