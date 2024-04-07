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
    //private DataSet ds;

    protected void Page_Load(object sender, EventArgs e)
    {
        conn_string = ConfigurationManager.ConnectionStrings["CmkHRAcctDB"].ConnectionString;
        //HyperLink1.NavigateUrl = "\\\\cmk-na\\us\\IT-AUTOMATION\\IT-AppDev_HRFinance\\Reports\\PR_MasterTax_Exports\\test_20090112.pts";
        HyperLink1.Visible = false;

    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();

    }
    protected void Calendar2_SelectionChanged(object sender, EventArgs e)
    {
        TextBox2.Text = "";
        TextBox2.Text = Calendar2.SelectedDate.ToShortDateString();

    }
    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {   
        if (TextBox1.Text != "")
        {
            try
            {
                Calendar1.SelectedDate = Convert.ToDateTime(TextBox1.Text);
            }
            catch 
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">"); 
                Response.Write(" window.alert(\"");
                Response.Write("Please use a valid Date format MM/DD/YYYY");
                Response.Write("\")</script>");

            }
        }
    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
        if (TextBox2.Text != "")
        {
            try
            {
                Calendar2.SelectedDate = Convert.ToDateTime(TextBox2.Text);
            }
            catch 
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
                Response.Write(" window.alert(\"");
                Response.Write("Please use a valid Date format MM/DD/YYYY");
                Response.Write("\")</script>");

            }
        }
    }
    protected bool date_range_check()
    {   
        string date1;
        date1 = Calendar1.SelectedDate.ToShortDateString();

        string date2;
        date2 = Calendar2.SelectedDate.ToShortDateString();


        if (TextBox1.Text != "" && TextBox2.Text != "")
        {
            try
            {
                Calendar1.SelectedDate = Convert.ToDateTime(TextBox1.Text);
                Calendar2.SelectedDate = Convert.ToDateTime(TextBox2.Text);

                if ((date1 != "1/1/0001" && date2 != "1/1/0001") && Calendar1.SelectedDate > Calendar2.SelectedDate)
                {
                    Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
                    Response.Write(" window.alert(\"");
                    Response.Write("Invalid Date Range");
                    Response.Write("\")</script>");


                    return false;
                }
                return true;
            }
            catch 
            {
                Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
                Response.Write(" window.alert(\"");
                Response.Write("Please use a valid Date format MM/DD/YYYY");
                Response.Write("\")</script>");


                return false;
            }
        }
        else {
            Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            Response.Write(" window.alert(\"");
            Response.Write("Please check your entries.");
            Response.Write("\")</script>");

            return false; }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (date_range_check() == true)
        {
            OdbcConnection connect = new OdbcConnection(conn_string);

            OdbcCommand cmd = new OdbcCommand("INSERT INTO cmk_MasterTax_job_log (TYPE, START_DATE,END_DATE, USERID, REQUEST_TYPE, JOB_STATUS) " +
            " SELECT 'PTS','" + Calendar1.SelectedDate.ToShortDateString() + "','" + Calendar2.SelectedDate.ToShortDateString() + "','" + 
            MyInfoUser.Value + "','IMMEDIATE','PENDING'", connect);

            /*COMMENTED OUT JOBS NOW GO TO A QUEUE
                    OdbcConnection connect = new OdbcConnection(conn_string);
                    OdbcCommand cmd = new OdbcCommand("{call sp_cmk_MasterTax_01_PTS_Export (?,?,?)}", connect);
                    cmd.CommandTimeout = 600;

                    OdbcParameter prm;
                    prm = cmd.Parameters.Add("@CHECK_DATE_BEGIN", OdbcType.Char, 10);
                    prm.Value = Calendar1.SelectedDate.ToShortDateString();

                    prm = cmd.Parameters.Add("@CHECK_DATE_END", OdbcType.Char, 10);
                    prm.Value = Calendar2.SelectedDate.ToShortDateString();

                    prm = cmd.Parameters.Add("@RETURN", OdbcType.Char, 1);
                    prm.Direction = ParameterDirection.Output;

                    //next 4 line should be commented
                    OdbcCommand cmd = new OdbcCommand("{call sp_cmk_MasterTax_03_PTS_Export (?)}", connect);
                    OdbcParameter prm;
                    prm = cmd.Parameters.Add("@RETURN", OdbcType.Char, 1);
                    prm.Direction = ParameterDirection.Output;

             */

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();

            Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            Response.Write(" window.alert(\"");
            Response.Write("Your request was submitted. Please go to the Export Job List.");
            Response.Write("\")</script>");


            //create_file();
            HyperLink1.Visible = true;
        }

    }

    /*
    protected void create_file()
    {
        OdbcConnection conn = new OdbcConnection(conn_string);
        ds = new DataSet();

        OdbcDataAdapter da = new OdbcDataAdapter("SELECT DISTINCT CHECK_DATE FROM cmk_MasterTax_FileFormat ORDER BY CHECK_DATE", conn);
        da.TableMappings.Add("Table", "CHECK_DATE");
        da.Fill(ds);

    
        
        for (int row =0; row < ds.Tables["CHECK_DATE"].Rows.Count; row++)
        {
            string get_date;
            get_date = ds.Tables["CHECK_DATE"].Rows[row][0].ToString();
            DateTime dt;
            dt = Convert.ToDateTime(get_date);

            OdbcDataAdapter da2 = new OdbcDataAdapter("SELECT RECORD FROM cmk_MasterTax_FileFormat WHERE CONVERT(CHAR(10),CHECK_DATE,101) = CONVERT(DATETIME,'" + dt
            + "') ORDER BY LINEID", conn);
            da2.TableMappings.Add("Table", "Output_FileFormat");
            da2.Fill(ds);

            StreamWriter file = new StreamWriter("C:\\temp\\test_"+ dt.ToString("yyyyMMdd") + ".txt");
            for (int row2 = 0; row2 < ds.Tables["Output_FileFormat"].Rows.Count; row2++)
            {
                file.WriteLine(ds.Tables["Output_FileFormat"].Rows[row2][0].ToString());
            }
            file.Close();

        }

    }
    */
}
