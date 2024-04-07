<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Export_job_list.aspx.cs" Inherits="Export_job_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    
<!-- Checks to see if they users in the right group 
<xml ID="writersXML" SRC="/servlet/Profile"></xml>
<script src="/lawson/cmkNet/Mastertax/MyInfoProfile.js" type="text/javascript"></script>
<script type="text/javascript">
    function checkgroup() {
        try {

            var group = findLawsonGroup("writersXML", "Mastertax Users");

            if (group == undefined) {
                window.location = "http://myinfo.crossmark.internal.pvt";
            }
        }
        catch (e) {
            window.location = "http://myinfo.crossmark.internal.pvt";
        }
    }
    window.onload = checkgroup;
</script>
beginning snippets -->
<!-- end snippets -->

</head>
<body>
    <form id="form1" runat="server">

    <asp:Button ID="Button1" runat="server" Text="Refresh List" 
        onclick="Button1_Click" />
    <br />
    <br />
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            onrowdatabound="GridView1_RowDataBound" AllowPaging="true" PageSize="12" OnPageIndexChanging="grdView_PageIndexChanging">
        <Columns>
                     <asp:BoundField
              HeaderText="JOBID"
              DataField="JOBID" />    
                           <asp:BoundField
              HeaderText="TYPE"
              DataField="TYPE" />    
                           <asp:BoundField
              HeaderText="PARAMETERS"
              DataField="PARAMETERS" />    
                           <asp:BoundField
              HeaderText="USERID"
              DataField="USERID" />    
                           <asp:BoundField
              HeaderText="REQUEST TYPE"
              DataField="REQUEST TYPE" />    
                           <asp:BoundField
              HeaderText="SCHEDULE DATE"
              DataField="SCHEDULE DATE" />   
                           <asp:BoundField
              HeaderText="SUBMIT DATE"
              DataField="SUBMIT DATE" />    
                          <asp:HyperLinkField              
              HeaderText="JOB STATUS"
              DataNavigateUrlFields="JOBID,TYPE"
              DataNavigateUrlFormatString="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/result_detail.aspx?jobid={0}&type={1}"
              DataTextField="JOB STATUS" />  
                           <asp:BoundField
              HeaderText="COMPLETED DATE"
              DataField="COMPLETED DATE" />   
              

        </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
