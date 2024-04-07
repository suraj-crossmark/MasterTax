using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class Export_job_list : System.Web.UI.Page
{
    private string conn_string;
    DataView dsView = new DataView();
    DataSet ds = new DataSet();

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Refresh", "15");
        conn_string = ConfigurationManager.ConnectionStrings["CmkHRAcctDBSqlClient"].ConnectionString;

        if (!IsPostBack)
        {
            dsView = bindgrid();
            GridView1.DataSource = dsView;
            GridView1.DataBind();
        }

    }


    private DataView bindgrid()
    {
        string Strquery = "SELECT JOBID, TYPE, " +
               " 'Parameters selected: ' + " +
               " CASE WHEN START_DATE IS NULL AND TYPE <> 'MTS' THEN " +
               "     'QUARTER: ' + QUARTER " +
               "      WHEN START_DATE IS NOT NULL THEN " +
               "     CONVERT(CHAR(10),START_DATE,101) +  ' TO ' + " +
               "     CONVERT(CHAR(10),END_DATE,101) " +
               "     WHEN START_DATE IS NULL AND TYPE = 'MTS' THEN " +
               "     'MONTHLY: ' + QUARTER " +
               " END  AS PARAMETERS,  " +
               " USERID, REQUEST_TYPE AS [REQUEST TYPE], " +
               " ISNULL(CONVERT(CHAR(20),SCHEDULE_DATE,100),'') AS [SCHEDULE DATE], " +
               " SUBMIT_DATE AS [SUBMIT DATE], JOB_STATUS AS [JOB STATUS],  " +
               " ISNULL(CONVERT(CHAR(20),COMPLETED_DATE,100),'') AS [COMPLETED DATE] " +
               " FROM cmk_MasterTax_job_log (nolock) ORDER BY JOBID DESC";

        SqlDataAdapter sadp = new SqlDataAdapter(Strquery, conn_string);
        sadp.Fill(ds);

        dsView = ds.Tables[0].DefaultView;

        return dsView;
    }


    protected void joblist_refresh()
    {
        dsView = bindgrid();
        GridView1.DataSource = dsView;
        GridView1.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        joblist_refresh();
    }


    protected void grdView_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataSource = bindgrid();
        GridView1.DataBind(); 
    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    HyperLink Link = e.Row.FindControl("HyperLink1") as HyperLink;

        //    if (Link.Text != "VIEW FILE(S)" )
        //    {
        //        Link.Enabled = false;
        //    }
        //} 
        
    }
}
