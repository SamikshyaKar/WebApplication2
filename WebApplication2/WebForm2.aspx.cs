using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string CS = "data source=.; database=Sample; Integrated Security= SSPI";
            using (SqlConnection Con = new SqlConnection(CS))
            {

                SqlCommand cmd2 = new SqlCommand("select * from tblemployee", Con);
                Con.Open();
                SqlDataReader rdr1 = cmd2.ExecuteReader();
                GridView2.DataSource = rdr1;
                GridView2.DataBind();
                rdr1.Close();
                Con.Dispose();
                Con.Close();
            }

        }
    }
}