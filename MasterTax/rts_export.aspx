<%@ Page Language="C#" AutoEventWireup="true" CodeFile="rts_export.aspx.cs" Inherits="pts_export" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <title>Reconcilation Tax Summary</title>
    
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
beginning snippets  -->

</head>
<body> 
    <div class="label"><asp:Label ID="Label1" runat="server" Text="Reconcilation Tax Summary Export"></asp:Label></div>
    <form id="form1" runat="server">
    <asp:HiddenField ID="MyInfoUser" runat="server" />   
    <div>
    <table>
    <tr>
    <td>Enter a Year: <asp:TextBox ID="Year" runat="server" MaxLength="4"></asp:TextBox></td>
    
    
    <td>Reporting Process Level: 
        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList>
        
    </td>
    
    </tr>
    <tr><td style="border-bottom-style:solid; border-bottom-width:thin;">Select a Quarter</td></tr>
    <tr>
    <td>
         <asp:RadioButtonList ID="RadioButtonList1" runat="server" >
            <asp:ListItem Text="Quarter 1" Value="Q1"></asp:ListItem>
            <asp:ListItem Text="Quarter 2" Value="Q2"></asp:ListItem>
            <asp:ListItem Text="Quarter 3" Value="Q3"></asp:ListItem>
            <asp:ListItem Text="Quarter 4" Value="Q4"></asp:ListItem>
        </asp:RadioButtonList>
        </td>
        <td>
        <asp:Button ID="Button1" runat="server" Text="Export RTS" onclick="Button1_Click" />
        </td>
    </tr>   
     <tr><td></td><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/Default.aspx?fm=3" Target="_parent">Export Job List</asp:HyperLink></td></tr>
    </table>
    </div>
    </form>
</body>
</html>