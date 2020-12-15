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
    
    public class BUS_BenhNhan
    {
        DAL_BenhNhan dal;
        public BUS_BenhNhan()
        {
            dal = new DAL_BenhNhan();
        }
        public DataTable selectALL()
        {
            return dal.selectALL();
        }
        public bool Add(DTO_BenhNhan dto)
        {
            return dal.Add(dto);
        }
        public bool Update(DTO_BenhNhan dto)
        {
            return dal.Update(dto);
        }
        public bool Delete(string MASOBN)
        {
            return dal.Delete(MASOBN);
        }
        public string CreateMaBenhNhan()
        {
            return dal.CreateMaBenhNhan();
        }
    }
}
