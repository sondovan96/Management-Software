using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using DAL_QuanLy;
using System.Data;

namespace BUS_QuanLy
{
    public class BUS_Account
    {
        private DAL_Account dal;
        public BUS_Account()
        {
            dal = new DAL_Account();
        }
        public DataTable selectAll()
        {
            
            return dal.selectAll();
        }
        public DataTable GetAccountOfPass(string user, string pass)
        {
            return dal.GetAccountOfPass(user, pass);
        }
        public bool Update(DTO_Account dto)
        {
            return dal.Update(dto);
        }
        public bool ResetAccount(string user)
        {
            return dal.ResetAccount(user);
        }
        public bool Add(DTO_Account dto)
        {
            return dal.Add(dto);
        }
        public bool UpdateDisplay(DTO_Account dto)
        {
            return dal.UpdateDisplay(dto);
        }
        public bool DeleteAccount(string user)
        {
            return dal.DeleteAccount(user);
        }
    }
}
