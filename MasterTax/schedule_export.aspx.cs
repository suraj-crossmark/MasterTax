using System;
using System.Configuration;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Odbc;

public partial class schedule_export : System.Web.UI.Page
{
    private string conn_string;


    protected void Page_Load(object sender, EventArgs e)
    {
        conn_string = ConfigurationManager.ConnectionStrings["CmkHRAcctDB"].ConnectionString;

        if (!IsPostBack)
        {
            LoadDropDowns();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string h, m, t;
            DateTime schedule_date = new DateTime();
            DateTime from_date = new DateTime();
            DateTime to_date = new DateTime();

            h = this.DropDownList2.SelectedItem.ToString();
            m = this.DropDownList3.SelectedItem.ToString();
            t = this.DropDownList1.SelectedItem.ToString();
            schedule_date = Convert.ToDateTime(TextBox3.Text + " " + h + ":" + m + ":00 " + t);

            if (schedule_date < DateTime.Now)
            {
                message_prompt("Cannot schedule export earlier than today's date. Please enter a new date and time.");
            }
            else
            {
		 
		 /*COMMENTED OUT
      		  if (SelectedFileType.Value.ToString() == "PTS")
      		    {
       	           if (Convert.ToDateTime(TextBox1.Text) > Convert.ToDateTime(TextBox2.Text))
       	           {
      	           message_prompt("PTS Date Range is invalid");
       	             }
                  else
        	 {
        	 schedule_pts(Convert.ToDateTime(TextBox1.Text).ToShortDateString(), Convert.ToDateTime(TextBox2.Text).ToShortDateString(), schedule_date);
        	 message_prompt("Scheduled PTS Export has been submitted.");
        	    }
        	   }
                if (SelectedFileType.Value.ToString() == "RTS")
                {
                    string quarterinfo;
                    quarterinfo = TextBox4.Text.ToString() + "Q" + DropDownList4.Text.Substring(8, 1).ToString() + DropDownList5.Text.ToString();
                    schedule_rts(quarterinfo, schedule_date);
                    message_prompt("Scheduled RTS Export has been submitted. " + DropDownList4.SelectedItem.ToString());
          	      } 
                   */
                
                
                from_date = Convert.ToDateTime(TextBox1.Text + " " + h + ":" + m + ":00 " + t);
            	to_date = Convert.ToDateTime(TextBox2.Text + " " + h + ":" + m + ":00 " + t);
                
                    OdbcConnection connect = new OdbcConnection(conn_string);
		
		    OdbcCommand cmd = new OdbcCommand("INSERT INTO cmk_MasterTax_job_log (TYPE, START_DATE,END_DATE, USERID, REQUEST_TYPE, SCHEDULE_DATE, JOB_STATUS) " +
		    " SELECT 'PTS','" + from_date.ToString() + "','" + to_date.ToString() + "','" + 
		    MyInfoUser.Value + "','SCHEDULED', '" + schedule_date.ToString() + "', 'PENDING'", connect);

            			connect.Open();
            			cmd.ExecuteNonQuery();
            			connect.Close();
			
            			Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
            			Response.Write(" window.alert(\"");
            			Response.Write("Scheduled PTS Export has been submitted. Please go to the Export Job List.");
            			Response.Write("\")</script>");
	     
            }

        }

        catch 
        {
            message_prompt("Please check your entries and make sure that it follow the correct format.");
        }

        ClearFields();
        LoadDropDowns();

    }

    protected void LoadDropDowns()
    {
        for (int i = 1; i <= 12; i++)
        {
            DropDownList2.Items.Add(i.ToString());
        }

        for (int i = 0; i <= 59; i++)
        {
            if (i.ToString().Length < 2)
            {
                DropDownList3.Items.Add("0" + i.ToString());
            }
            else
            {
                DropDownList3.Items.Add(i.ToString());
            }
        }      

        DropDownList1.Items.Add("AM");
        DropDownList1.Items.Add("PM");

        DropDownList4.Items.Add("Quarter 1");
        DropDownList4.Items.Add("Quarter 2");
        DropDownList4.Items.Add("Quarter 3");
        DropDownList4.Items.Add("Quarter 4");

        OdbcConnection connect = new OdbcConnection(conn_string);

        OdbcCommand cmd = new OdbcCommand("SELECT DISTINCT HEAD_PROC_LEV FROM cmk_MasterTax_Eligible_Process_Levels UNION SELECT 'ALL' ", connect);
        connect.Open();
        DropDownList5.DataSource = cmd.ExecuteReader();
        DropDownList5.DataTextField = "HEAD_PROC_LEV";
        DropDownList5.DataBind();
        connect.Close();

    }

    protected void ClearFields()
    {
        DropDownList1.Items.Clear();
        DropDownList2.Items.Clear();
        DropDownList3.Items.Clear();
        DropDownList4.Items.Clear();

        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }

    protected void schedule_pts(string sdate, string edate, DateTime scheduleddate)
    {
        OdbcConnection connect = new OdbcConnection(conn_string);

        OdbcCommand cmd = new OdbcCommand("INSERT INTO cmk_MasterTax_job_log (TYPE, START_DATE,END_DATE, USERID, REQUEST_TYPE, SCHEDULE_DATE, JOB_STATUS) " +
        " SELECT 'PTS','" + sdate + "','" + edate + "','" +
        MyInfoUser.Value + "','SCHEDULED', CONVERT(DATETIME,'" + scheduleddate.ToString() + "'), 'PENDING'", connect);

        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
    }

    protected void schedule_rts(string quarter, DateTime scheduleddate)
    {

        OdbcConnection connect = new OdbcConnection(conn_string);

        OdbcCommand cmd = new OdbcCommand("INSERT INTO cmk_MasterTax_job_log (TYPE, QUARTER, USERID, REQUEST_TYPE, SCHEDULE_DATE, JOB_STATUS) " +
        " SELECT 'RTS','" + quarter.ToString() + "','" +
         MyInfoUser.Value + "','SCHEDULED', CONVERT(DATETIME,'" + scheduleddate.ToString() + "'), 'PENDING'", connect);

        connect.Open();
        cmd.ExecuteNonQuery();
        connect.Close();
    }

    protected void message_prompt(string msg)
    {
        Response.Write("<script language=\"javascript\" type=\"text/javascript\">");
        Response.Write(" window.alert(\"");
        Response.Write(msg);
        Response.Write("\")</script>");
    }
}