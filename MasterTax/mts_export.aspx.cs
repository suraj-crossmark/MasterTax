using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;


public partial class mts_export : System.Web.UI.Page
{

    private string conn_string;
    
    


    protected void Page_Load(object sender, EventArgs e)
    {
        conn_string = ConfigurationManager.ConnectionStrings["CmkHRAcctDB"].ConnectionString;
        DateTime current = DateTime.Now;

	          if (!IsPostBack)
        {

            Year.Text = String.Format("{0:yyyy}", current);
        
             HyperLink1.Visible = false;
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        string monthlyinfo;

        monthlyinfo = Year.Text + RadioButtonList1.SelectedItem.Value + "CSA";

        OdbcConnection connect = new OdbcConnection(conn_string);

        OdbcCommand cmd = new OdbcCommand("INSERT INTO cmk_MasterTax_job_log (TYPE, QUARTER, USERID, REQUEST_TYPE, JOB_STATUS) " +
        " SELECT 'MTS','" + monthlyinfo.ToString() + "','" +
        MyInfoUser.Value + "','IMMEDIATE','PENDING'", connect);


        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();

        Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
        Response.Write(" window.alert(\"");
        Response.Write("Your request was submitted. Please go to the Export Job List.");
        Response.Write("\")</script>");

        HyperLink1.Visible = true;
    }
}
