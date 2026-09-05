using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVCCRUD2
{
    public partial class ShowAll : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=MVCCRUD; Integrated Security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowAllData();
        }

        void ShowAllData()
        {
            SqlCommand cmd = new SqlCommand("sp_get_all_product", con);
            cmd.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter da= new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GVProducts.DataSource = dt;
            GVProducts.DataBind();
        }
    }
}