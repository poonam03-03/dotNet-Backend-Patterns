using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MVCCRUD2.Models
{
    public partial class Add : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=MVCCRUD; Integrated Security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_add_product", con);
            cmd.CommandType=System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pname", TxtProdName.Text);
            cmd.Parameters.AddWithValue("@uprice",TxtUprice.Text);
            cmd.Parameters.AddWithValue("@qty",TxtQty.Text);    
            if(con.State==ConnectionState.Closed)
            {
                con.Open(); 
            }
            cmd.ExecuteNonQuery();
            con.Close();
            LblResult.Text = "Product record Added Successfully.";


        }
    }
}