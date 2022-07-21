using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace OpCacheWithSqlDependency
{
    public partial class Index : System.Web.UI.Page
    {
        DataSet ds;
        SqlConnection conn;
        SqlDataAdapter da;
        protected void Page_Load(object sender, EventArgs e)
        {   //cmd --aspnet_regsql -E -ed -et -s DESKTOP-G4J7E8F\SQLEXPRESS -d EntityDb -t mydata
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["myconn"].ConnectionString);
            conn.Open();
            ds = new DataSet();
            da = new SqlDataAdapter("Select * from mydata", conn);
            da.Fill(ds,"empdata");
            GridView1.DataSource = ds.Tables["empdata"];
            GridView1.DataBind();


        }
    }
}