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
    public class BUS_PhongBenh
    {
        DAL_PhongBenh dal;
        public BUS_PhongBenh()
        {
            dal = new DAL_PhongBenh();
        }
        public DataTable selectAll()
        {
            return dal.selectAll();
        }
        public bool Add(DTO_PhongBenh dto)
        {
            return dal.Add(dto);
        }
        public bool Update(DTO_PhongBenh dto)
        {
            return dal.Update(dto);
        }
        public bool Delete(string ma)
        {
            return dal.Delete(ma);
        }
        public string CreateMaPhong()
        {
            return dal.CreateMaPhong();
        }
    }

}
