using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using System.Data;

namespace DAL_QuanLy
{
    public class DAL_PhongBenh
    {
        DBConnects db;
        public DAL_PhongBenh()
        {
            db = new DBConnects();
        }
        public DataTable selectAll()
        {
            string sql = "select * from dbo.PHONGBENH";
            return db.Executed(sql);
        }
        public bool Add(DTO_PhongBenh dto)
        {
            try
            {
                string sql = string.Format("INSERT INTO[dbo].[PHONGBENH]([MAPHONG],[VITRI])" +
                "VALUES('{0}', N'{1}')", dto.MAPHONG1, dto.VITRI1);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(DTO_PhongBenh dto)
        {
            try
            {
                string sql = string.Format("UPDATE [dbo].[PHONGBENH]" +
                    "SET[VITRI] = N'{0}'" +
                    "WHERE MAPHONG = '{1}'", dto.VITRI1, dto.MAPHONG1);
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
                string sql = string.Format("DELETE FROM [dbo].[PHONGBENH]" +
                    "WHERE MAPHONG = N'{0}'", ma);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public string CreateMaPhong()
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
                if (k < 10)
                {
                    ma = "000";
                }
                else if (k < 100)
                {
                    ma = "00";
                }
                else if (k < 1000)
                {
                    ma = "0";
                }
                ma = ma + k.ToString();
            }
            return ma;
        }
    }
}
