using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ADOcrudoops
{
    internal class DBManager
    {
        protected string mycommand;
        protected string res;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        public DBManager()
        {
            conn.ConnectionString = "data source = DELL\\SQLEXPRESS; initial catalog=AP2024; integrated security=true";
        }

        public bool isinsertupdatedelete()
        {
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            cmd.CommandText = mycommand;
            cmd.Connection = conn;
            int r = cmd.ExecuteNonQuery();
            conn.Close();
            if (r > 0)
                return true;
            else
                return false;
        }



        public DataTable tofetchrecord()
        {
            SqlDataAdapter adapter = new SqlDataAdapter(mycommand, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
    }
}