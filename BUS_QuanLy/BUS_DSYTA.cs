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
    public class BUS_DSYTA
    {
        DAL_DSYTA dal;
        public BUS_DSYTA()
        {
            dal = new DAL_DSYTA();
        }
        public DataTable selectAll()
        {
            return dal.selectAll();
        }
        public bool Add(DTO_DSYTA dto)
        {
            return dal.Add(dto);
        }
        public bool Update(DTO_DSYTA dto)
        {
            return dal.Update(dto);
        }
        public bool Delete(string ma)
        {
            return dal.Delete(ma);
        }
        public string CreateMaYTA()
        {
            return dal.CreateMaYTA();
        }

    }
}
