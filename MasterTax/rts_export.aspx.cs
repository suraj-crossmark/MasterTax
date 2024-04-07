using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;


public partial class pts_export : System.Web.UI.Page
{

    private string conn_string;
    
    


    protected void Page_Load(object sender, EventArgs e)
    {
        conn_string = ConfigurationManager.ConnectionStrings["CmkHRAcctDB"].ConnectionString;
        DateTime current = DateTime.Now;


        if (!IsPostBack)
        {

            Year.Text = String.Format("{0:yyyy}", current);
        
            OdbcConnection connect = new OdbcConnection(conn_string);

            OdbcCommand cmd = new OdbcCommand("SELECT DISTINCT HEAD_PROC_LEV FROM cmk_MasterTax_Eligible_Process_Levels UNION SELECT 'ALL' ", connect);
            connect.Open();


            DropDownList1.DataSource = cmd.ExecuteReader();
            DropDownList1.DataTextField = "HEAD_PROC_LEV";
            DropDownList1.DataBind();
            connect.Close();
            HyperLink1.Visible = false;
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        string quarterinfo;

        quarterinfo = Year.Text + RadioButtonList1.SelectedItem.Value + DropDownList1.Text;

        OdbcConnection connect = new OdbcConnection(conn_string);

        OdbcCommand cmd = new OdbcCommand("INSERT INTO cmk_MasterTax_job_log (TYPE, QUARTER, USERID, REQUEST_TYPE, JOB_STATUS) " +
        " SELECT 'RTS','" + quarterinfo.ToString() + "','" +
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
