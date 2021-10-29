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
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string CS = "data source=.; database=Sample; Integrated Security=SSPI";
            SqlConnection Con = new SqlConnection(CS);
            SqlCommand cmd1 = new SqlCommand(" select * from tblemployee", Con);
            Con.Open();
            //cmd1.ExecuteReader();
            //GridView1.DataSource = cmd1.ExecuteReader();
            SqlDataReader rdr = cmd1.ExecuteReader();
            GridView1.DataSource = rdr;
            GridView1.DataBind();
            rdr.Close();
            
            Con.Close();
        }
    }
}

//=========================================

//SqlConnection conn = null;
//SqlCommand cmd = null;

//try
//{
//    conn = new SqlConnection(Settings.Default.qlsdat_extensionsConnectionString)
//    cmd = new SqlCommand(reportDataSource, conn);
//cmd.CommandType = CommandType.StoredProcedure;
//    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = year;
//    cmd.Parameters.Add("@startDate", SqlDbType.DateTime).Value = start;
//    cmd.Parameters.Add("@endDate", SqlDbType.DateTime).Value = end;

//        conn.Open(); //opens connection

//    DataSet dset = new DataSet();
//new SqlDataAdapter(cmd).Fill(dset);
//    this.gridDataSource.DataSource = dset.Tables[0];
//}
//catch(Exception ex)
//{
//    Logger.Log(ex);
//    throw;
//}
//finally
//{
//    if(conn != null)
//        conn.Dispose();

//        if(cmd != null)
//        cmd.Dispose();
//} 

//=======================================

//SqlConnection connection = new SqlConnection("connection string");
//SqlCommand cmd = new SqlCommand("SELECT * FROM SomeTable", connection);
//SqlDataReader reader = cmd.ExecuteReader();
//connection.Open();
//if (reader != null)
//{
//      while (reader.Read())
//      {
//              //do something
//      }
//}
//reader.Close(); // <- too easy to forget
//reader.Dispose(); // <- too easy to forget
//connection.Close(); // <- too easy to forget

//Instead, wrap them in using statements:
//Hide Copy Code
//using(SqlConnection connection = new SqlConnection("connection string"))
//{

//    connection.Open();

//    using(SqlCommand cmd = new SqlCommand("SELECT * FROM SomeTable", connection))
//    {
//        using (SqlDataReader reader = cmd.ExecuteReader())
//        {
//            if (reader != null)
//            {
//                while (reader.Read())
//                {
//                    //do something
//                }
//            }
//        } // reader closed and disposed up here

//    } // command disposed here

//} //connection closed and disposed here