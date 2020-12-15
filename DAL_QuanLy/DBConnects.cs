using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_QuanLy
{
    public class DBConnects
    {
        SqlConnection sqlcnn;//Create object connect DB
        SqlDataAdapter da;//Create data Adapter
        DataSet ds;//Object contain DB when comunication
        public DBConnects()
        {
            string strcnn = @"Data Source=.\SQLEXPRESS; Database=QL_CATRUC;Integrated Security = True";//string connect sql
            sqlcnn = new SqlConnection(strcnn);
        }
        public DataTable Executed(string strsql)
        {
            using (da = new SqlDataAdapter(strsql, sqlcnn))
            {
                ds = new DataSet();
                da.Fill(ds);
                sqlcnn.Close();
            }
            return ds.Tables[0];
        }
        public void ExecuteNonQuery(string strsql)
        {
            using (SqlCommand sqlcmd = new SqlCommand(strsql, sqlcnn))
            {
                sqlcnn.Open();
                sqlcmd.ExecuteNonQuery();
                sqlcnn.Close();
            }
        }
    }
}
