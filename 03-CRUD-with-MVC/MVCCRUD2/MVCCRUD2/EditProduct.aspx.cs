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
    public partial class EditProduct : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=DELL\\SQLEXPRESS;Initial Catalog=MVCCRUD; Integrated Security=True;");
        protected void Page_Load(object sender, EventArgs e)
        {
           
            int pid = int.Parse(Request.QueryString["pid"].ToString());
            SqlCommand cmd = new SqlCommand("sp_get_specific_product", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", pid);
            SqlDataAdapter da=new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            da.Fill(dt);
            LblProdId.Text = dt.Rows[0]["ProductId"].ToString();
            HFProdId.Value = dt.Rows[0]["ProductId"].ToString() ;
            TxtProdName.Text = dt.Rows[0]["ProductName"].ToString ();
            TxtQty.Text = dt.Rows[0]["Quantity"].ToString () ;
            TxtUprice.Text = dt.Rows[0]["UnitPrice"].ToString();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("sp_update_product", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", HFProdId.Value);
            cmd.Parameters.AddWithValue("@pname",TxtProdName.Text); 
            cmd.Parameters.AddWithValue("@uprice",TxtUprice.Text);  
            cmd.Parameters.AddWithValue("@qty",TxtQty.Text);    
            if(con.State==ConnectionState.Closed)
                con.Open();
            cmd.ExecuteNonQuery();  
            con.Close();
            LblResult.Text = "Product record Updated Successfully.";
        }
    }
}