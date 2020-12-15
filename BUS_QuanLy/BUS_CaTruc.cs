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
    public class BUS_CaTruc
    {
        DAL_CaTruc dal;
        public BUS_CaTruc()
        {
            dal = new DAL_CaTruc();
        }
        public DataTable selectALL()
        {
            return dal.selectALL();
        }
        public bool Add(DTO_CaTruc dto)
        {
            return dal.Add(dto);
        }
        public bool Update(DTO_CaTruc dto)
        {
            return dal.Update(dto);
        }
        public bool Delete(string MACA)
        {
            return dal.Delete(MACA);
        }
        public string CreateMaCa()
        {
            return dal.CreateMaCa();
        }
    }
}
