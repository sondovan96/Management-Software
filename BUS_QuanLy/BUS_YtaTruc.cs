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
    public class BUS_YtaTruc
    {
        DAL_YtaTruc dal;
        public BUS_YtaTruc()
        {
            dal = new DAL_YtaTruc();
        }
        public DataTable selectAll()
        {
            return dal.selectAll();
        }
        public bool Add(DTO_YTaTruc dto)
        {
            return dal.Add(dto);
        }
        public bool Update(DTO_YTaTruc dto)
        {
            return dal.Update(dto);
        }
        public bool Delete(string mayta,string maca)
        {
            return dal.Delete(mayta,maca);
        }
        public DataTable DateReports(DateTime Ngaybd, DateTime Ngaykt)
        {

            return dal.DateReports(Ngaybd,Ngaykt);
        }
    }
}
