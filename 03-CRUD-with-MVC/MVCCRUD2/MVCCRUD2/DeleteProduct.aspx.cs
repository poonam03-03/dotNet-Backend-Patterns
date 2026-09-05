using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVCCRUD2
{
    public partial class DeleteProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=MVCCRUD; Integrated Security=True;");
            int pid = int.Parse(Request.QueryString["pid"].ToString());
            SqlCommand cmd = new SqlCommand("sp_delete_product", con);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid",pid);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Product record deleted successfully.');window.location.href='ShowAll.aspx';</script>");
        }
    }
}