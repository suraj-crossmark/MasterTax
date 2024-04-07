<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pts_export.aspx.cs" Inherits="pts_export" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Payroll Tax Summary</title>
    
    
<!-- Checks to see if they users in the right group 
<xml ID="writersXML" SRC="/servlet/Profile"></xml>
<script src="/lawson/cmkNet/javascript/MyInfoProfile.js" type="text/javascript"></script>
<script type="text/javascript">
    function checkgroup() {
        try {

            var group = findLawsonGroup("writersXML", "Mastertax Users");

            if (group == undefined) {
                window.location = "http://myinfo.crossmark.internal.pvt";
            }
            else { getmyinfouser(); }
        }
        catch (e) {
            window.location = "http://myinfo.crossmark.internal.pvt";
        }
        
        
    }

    function getmyinfouser() 
    {
        document.form1.MyInfoUser.value = findLawsonAttrValue("writersXML", "id"); 
    }
    
    window.onload = checkgroup;
</script>
 beginning snippets -->
<!-- end snippets -->

</head>
<body>
    <div class="label"><asp:Label ID="Label1" runat="server" Text="Payroll Tax Summary Export"></asp:Label></div>
    <form id="form1" runat="server">
        <asp:HiddenField ID="MyInfoUser" runat="server" />    
    <div>

    <table>
    <tr>        
    <td>Start Date:&nbsp&nbsp 
        <asp:TextBox ID="TextBox1" runat="server"  Width="100px" ontextchanged="TextBox1_TextChanged"></asp:TextBox></td>
    <td>End Date:&nbsp&nbsp 
        <asp:TextBox ID="TextBox2" runat="server" Width="100px" ontextchanged="TextBox2_TextChanged"></asp:TextBox></td>
    </tr>
    <tr>
    <td><asp:Calendar ID="Calendar1" runat="server" ShowGridLines="true" 
            onselectionchanged="Calendar1_SelectionChanged"></asp:Calendar></td>
    <td><asp:Calendar ID="Calendar2" runat="server" ShowGridLines="true" 
            onselectionchanged="Calendar2_SelectionChanged"></asp:Calendar></td>
    </tr>
    </table>
    <br />
    <asp:Button ID="Button1" runat="server" Text="Submit Request" onclick="Button1_Click" />       
    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp    
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/Default.aspx?fm=3" Target="_parent">Export Job List</asp:HyperLink>
        
    </div>
    </form>
</body>
</html> 