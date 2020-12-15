using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using System.Data;

namespace DAL_QuanLy
{
    public class DAL_CaTruc
    {
        DBConnects db;
        public DAL_CaTruc()
        {
            db = new DBConnects();
        }
        public DataTable selectALL()
        {
            string sql = "select * from dbo.CATRUC";
            return db.Executed(sql);
        }
        public bool Add(DTO_CaTruc dto)
        {
            try
            {
                string sql = string.Format("INSERT INTO [dbo].[CATRUC]([MACA],[THOIGIANTRUC])" +
                    "VALUES('{0}', '{1}')",dto.MACA1,dto.THOIGIANTRUC1);
                db.ExecuteNonQuery(sql);
                return true;
            }catch(Exception ex)
            {
                return false;
            }
        }
        public bool Update(DTO_CaTruc dto)
        {
            try
            {
                string sql = string.Format("UPDATE [dbo].[CATRUC]" +
                    "SET[THOIGIANTRUC] = '{0}'" +
                    "WHERE MACA = '{1}'", dto.THOIGIANTRUC1, dto.MACA1);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string MACA)
        {
            try
            {
                string sql = "DELETE FROM [dbo].[CATRUC]" +
                                "WHERE MACA = " + MACA;
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string CreateMaCa()
        {
            DataTable dt = new DataTable();
            dt = selectALL();
            string ma = "";
            if (dt.Rows.Count <= 0)
            {
                ma = "01";
            }
            else
            {
                int k;
                k = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0].ToString());
                k = k + 1;
                if (k < 10)
                {
                    ma = "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }
    }
}
