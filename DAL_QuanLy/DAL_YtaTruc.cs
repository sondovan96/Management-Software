using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;
using System.Data;

namespace DAL_QuanLy
{
    public class DAL_YtaTruc
    {
        DBConnects db;
        public DAL_YtaTruc()
        {
            db = new DBConnects();
        }
        public DataTable selectAll()
        {
            string sql = "EXEC SELECT_YTATRUC2";
            return db.Executed(sql);
        }
        public bool Add(DTO_YTaTruc dto)
        {
            try
            {
                string sql = string.Format("INSERT INTO [dbo].[YTA_TRUC]([MASOYTA],[MACA],[NGAY],[MAPHONG])" +
                    "VALUES('{0}', '{1}', '{2}', '{3}')",dto.MASOYTA1,dto.MACA1,dto.NGAY1,dto.MAPHONG1);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Update(DTO_YTaTruc dto)
        {
            try
            {
                string sql = string.Format("UPDATE [dbo].[YTA_TRUC]" +
                    "SET [NGAY] = '{0}'" +
                    ",[MAPHONG] = '{1}'" +
                    "WHERE [MASOYTA] = '{2}' AND [MACA]='{3}'", dto.NGAY1, dto.MAPHONG1, dto.MASOYTA1,dto.MACA1);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Delete(string mayta,string maca)
        {
            try
            {
                string sql = "DELETE FROM [dbo].[YTA_TRUC]" +
                    "WHERE MASOYTA = " + mayta +"AND MACA ="+maca;
                db.ExecuteNonQuery(sql);                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public DataTable infoBNofPhong(string maphong)
        {
            string sql = string.Format("select MASOBN,HOTEN" +
                "FROM BENH_NHAN BN INNER JOIN PHONGBENH PB ON BN.MAPHONG = PB.MAPHONG" +
                "WHERE PB.MAPHONG = '{0}'", maphong);
            return db.Executed(sql);
        }
        public DataTable DateReports(DateTime Ngaybd, DateTime Ngaykt)
        {
            string sql = string.Format("select YTT.MASOYTA,DS.HOTEN,CT.MACA,THOIGIANTRUC,NGAY,MAPHONG " +
                "FROM YTA_TRUC YTT, DS_YTA DS, CATRUC CT" +
                " WHERE YTT.MASOYTA = DS.MASOYTA" +
                " AND YTT.MACA = CT.MACA" +
                " AND NGAY BETWEEN '{0}' AND '{1}'", Ngaybd, Ngaykt);
            return db.Executed(sql);
        }
    }
}
