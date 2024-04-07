using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;


public partial class result_detail : System.Web.UI.Page
{
    private string conn_string;
    private string jobid;
    private string type;

    protected void Page_Load(object sender, EventArgs e)
    {
        Label1.Visible = false;
        conn_string = ConfigurationManager.ConnectionStrings["CmkHRAcctDB"].ConnectionString;
        jobid = Request.QueryString["jobid"];
        type = Request.QueryString["type"];
        result_list();

    }

    protected void result_list()
    {
        string command_text = "SELECT JOBID, FILENAME, CREATION_DATE AS [CREATION DATE] " +
                              " FROM cmk_MasterTax_job_results WHERE FILENAME IS NOT NULL AND JOBID = " + jobid +
                              " ORDER BY CREATION_DATE";

        OdbcConnection conn = new OdbcConnection(conn_string);
        OdbcCommand command = new OdbcCommand(command_text, conn);

        conn.Open();

        GridView1.DataSource = command.ExecuteReader();
        GridView1.DataBind();

        if (GridView1.Rows.Count == 0)
        {
            Label1.Visible = true;
            Label1.Text = "No Results Found";
        }


        conn.Close();
    }

    protected void RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink link1 = (HyperLink)e.Row.FindControl("HyperLink1");
            HyperLink link2 = (HyperLink)e.Row.FindControl("HyperLink2");
	    HyperLink link3 = (HyperLink)e.Row.FindControl("HyperLink3");

            switch (type)
            {
                case "PTS":
                    link1.Visible = true;
                    break;
                case "RTS":
                    link2.Visible = true;
                    break;
                case "MTS":
		    link3.Visible = true;
                    break;
                default:
                    break;
            }
        }


    }
}
