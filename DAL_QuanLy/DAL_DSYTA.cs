using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using System.Data;

namespace DAL_QuanLy
{
    public class DAL_DSYTA
    {
        DBConnects db;
        public DAL_DSYTA()
        {
            db = new DBConnects();
        }
        public DataTable selectAll()
        {
            string sql = "select * from dbo.DS_YTA";
            return db.Executed(sql);
        }
        public bool Add(DTO_DSYTA dto)
        {
            try
            {
                string sql = string.Format("INSERT[dbo].[DS_YTA]([MASOYTA], [HOTEN], [SDT], [DIACHI]) " +
                    "VALUES(N'{0}', N'{1}', '{2}', N'{3}')", dto.MASOYTA1, dto.HOTEN1, dto.SDT1, dto.DIACHI1);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public bool Update(DTO_DSYTA dto)
        {
            try
            {
                string sql = string.Format("UPDATE [dbo].[DS_YTA]" +
                    "SET[HOTEN] = N'{0}'," +
                    "[SDT] = '{1}',"+
                    "[DIACHI]=N'{2}'"+
                    "WHERE MASOYTA = '{3}'",dto.HOTEN1,dto.SDT1,dto.DIACHI1,dto.MASOYTA1);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string ma)
        {
            try
            {
                string sql = "DELETE FROM [dbo].[DS_YTA]" +
                    "WHERE MASOYTA = " + ma;
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string CreateMaYTA()
        {
            DataTable dt = new DataTable();
            dt = selectAll();
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "0001";
            }
            else
            {
                int k;
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString());
                k = k + 1;
                if(k<10)
                {
                    ma = "000";
                }
                else if(k<100)
                {
                    ma = "00";
                }
                else if(k<1000)
                {
                    ma = "0";
                }
                ma = ma+k.ToString();
            }
            return ma;
        }
        
    }
}
