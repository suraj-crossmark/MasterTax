using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;


public partial class db_call_test : System.Web.UI.Page
{
    private string conn_string;
    private DataViewManager dsView;
    private DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        conn_string = ConfigurationManager.ConnectionStrings["CmkHRAcctDB"].ConnectionString;
    }

    protected void test(object sender, EventArgs e)
    {
        OdbcConnection conn = new OdbcConnection(conn_string);

        OdbcDataReader rdr = null;


        try
        {
            conn.Open();

            OdbcCommand cmd = new OdbcCommand("select top 5 * from z_temp_gl_mapping", conn);

            rdr = cmd.ExecuteReader();

            
            while (rdr.Read())
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
                Response.Write(" window.alert(\"");
                Response.Write("Result: " + rdr[0]);
                Response.Write("\")</script>");


            }
        }
        catch(Exception msg)
        {
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            Response.Write(" window.alert(\"");
            Response.Write(msg);
            Response.Write("\")</script>");
        }
        finally
        {
            // close the reader
            if (rdr != null)
            {
                rdr.Close();
            }

            // 5. Close the connection
            if (conn != null)
            {
                conn.Close();
            }
        }

    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        OdbcConnection conn = new OdbcConnection(conn_string);

        OdbcCommand command = new OdbcCommand("SELECT * FROM Z_JB_Temp_CA", conn);

        conn.Open();

        GridView1.DataSource = command.ExecuteReader();

        GridView1.DataBind();

        conn.Close();


        /*
        ds = new DataSet("test");

        OdbcDataAdapter da = new OdbcDataAdapter("SELECT * FROM Z_JB_Temp_CA", conn);
        da.TableMappings.Add("Table", "Z_JB_Temp_CA");
        da.Fill(ds);

        dsView = ds.DefaultViewManager;

        GridView1.DataSource = dsView;
        GridView1.DataMember = "Z_JB_Temp_CA";
        */


    }
}
