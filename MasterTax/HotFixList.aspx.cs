using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class HotFixList : System.Web.UI.Page
{
    public string conn_string = ConfigurationManager.ConnectionStrings["CmkHRAcctDBSqlClient"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection conn = new SqlConnection(conn_string);

        string command = "SELECT HOTFIXNUMBER AS HOTFIX, DESCRIPTION, CONVERT(CHAR(10),APPLIEDDATE,101) AS [APPLIED DATE] FROM cmk_MasterTax_HotfixList ORDER BY HOTFIXNUMBER DESC";

        SqlDataSource test = new SqlDataSource(conn_string, command);

        GridView1.DataSource = test;

        GridView1.DataBind();

    }
}
