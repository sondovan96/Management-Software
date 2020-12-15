using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO_QuanLy;

namespace DAL_QuanLy
{
    public class DAL_Account
    {
        DBConnects db;
        public DAL_Account()
        {
            db = new DBConnects();
        }
        public DataTable selectAll()
        {
            string sql = "select * from dbo.account";
            return db.Executed(sql);
        }
        public bool Add(DTO_Account dto)
        {
            try
            {
                string sql = string.Format("INSERT INTO [dbo].[ACCOUNT]([USERNAME],[PASS],[TYPE],[DISPLAYNAME])" +
                    " VALUES(N'{0}',N'1962026656160185351301320480154111117132155',{1},N'{2}')",dto.User,dto.Type,dto.Display);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Update(DTO_Account dto)
        {
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(dto.Pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach (byte item in hasData)
            {
                hasPass += item;
            }
            try
            {
                string sql = string.Format("UPDATE [dbo].[ACCOUNT] " +
                    " SET [PASS] = N'{0}' ," +
                    "[TYPE] = {1} " +
                    " WHERE USERNAME = N'{2}' ", hasPass, dto.Type, dto.User);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateDisplay(DTO_Account dto)
        {
            try
            {
                string sql = string.Format("UPDATE [dbo].[ACCOUNT] " +
                    " SET [DISPLAYNAME] = N'{0}' ," +
                    "[TYPE] = {1} " +
                    " WHERE USERNAME = N'{2}' ", dto.Display,dto.Type,dto.User);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public DataTable GetAccountOfPass(string user, string pass)
        {

            byte[] temp = ASCIIEncoding.ASCII.GetBytes(pass);
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);
            string hasPass = "";
            foreach(byte item in hasData)
            {
                hasPass += item;
            }
            string sql = string.Format("EXEC GET_ACCOUNT {0},N'{1}'", user, hasPass);
            return db.Executed(sql);
        }
        public bool ResetAccount(string user)
        {
            try
            {
                string sql = string.Format("UPDATE [dbo].[ACCOUNT] " +
                    " SET [PASS] = N'{0}' " +
                    " WHERE USERNAME = N'{1}' ", "1962026656160185351301320480154111117132155", user);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteAccount(string user)
        {
            try
            {
                string sql = string.Format("DELETE " +
                    " FROM dbo.Account " +
                    " WHERE USERNAME = N'{0}' ", user);
                db.ExecuteNonQuery(sql);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
