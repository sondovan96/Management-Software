using DTO_QuanLy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DAL_QuanLy
{
    
    public class DAL_BenhNhan
    {
        DBConnects db;
        public DAL_BenhNhan()
        {
            db = new DBConnects();
        }
        public DataTable selectALL()
        {
            string sql = "select * from dbo.BENH_NHAN";
            return db.Executed(sql);
        }
        public bool Add(DTO_BenhNhan dto)
        {
            try
            {
                string sql = string.Format("INSERT INTO [dbo].[BENH_NHAN]([MASOBN],[HOTEN],[DIACHI],[MAPHONG]) VALUES('{0}',N'{1}',N'{2}','{3}')"
                                , dto.MASOBN1, dto.HOTEN1,dto.DIACHI1, dto.MAPHONG1);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Update(DTO_BenhNhan dto)
        {
            try
            {
                string sql = string.Format("UPDATE [dbo].[BENH_NHAN]" +
                    "SET[HOTEN] = N'{0}'," +
                    "[DIACHI] = N'{1}'," +
                    "[MAPHONG] = '{2}'" +
                    "WHERE MASOBN = '{3}'", dto.HOTEN1,dto.DIACHI1, dto.MAPHONG1, dto.MASOBN1);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string MASOBN)
        {
            try
            {
                string sql = string.Format("DELETE FROM [dbo].[BENH_NHAN]" +
                "WHERE MASOBN = '{0}'", MASOBN);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public string CreateMaBenhNhan()
        {
            DataTable dt = new DataTable();
            dt = selectALL();
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
