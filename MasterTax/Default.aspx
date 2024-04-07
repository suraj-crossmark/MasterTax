<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MasterTax Exports</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />


<!-- Checks to see if they users in the right group 

<xml ID="writersXML" SRC="/servlet/Profile"></xml>
<script src="/lawson/cmkNet/Mastertax/MyInfoProfile.js" type="text/javascript"></script>
<script type="text/javascript">
    function checkgroup() {
        try {

            var group = findLawsonGroup("writersXML", "Mastertax Users");

            if (group == undefined) {
                window.location = "https://azupvweb0048.crossmark.internal.pvt/lawson/portal/index.htm#";
            }
        }
        catch (e) {
            window.location = "https://azupvweb0048.crossmark.internal.pvt/lawson/portal/index.htm#";
        }
    }
        window.onload = checkgroup;
        
</script>
beginning snippets -->
<!-- end snippets -->
   
</head>

<body>

<%
    int form_nbr;
    try
    {  form_nbr = Convert.ToInt32(Request.QueryString["fm"]);
       Menu1.Items[form_nbr].Selected = true;
       MultiView1.ActiveViewIndex = form_nbr;
    }
    catch{ 
        form_nbr = 0;
        Menu1.Items[form_nbr].Selected = true;
        MultiView1.ActiveViewIndex = form_nbr;
    }
%>

   <form class="form" id="form1" runat="server">
    <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" 
        StaticEnableDefaultPopOutImage="False"
        onmenuitemclick="Menu1_MenuItemClick"
        >
        <StaticHoverStyle Font-Bold="true" ForeColor="Blue"/>
        <StaticSelectedStyle Font-Bold="true" BackColor="Aqua" ForeColor="Blue"/>
        <StaticMenuItemStyle Width="130px" ForeColor="GrayText" />
    <Items>
        <asp:MenuItem Text="PTS Export" Value="0"  NavigateUrl="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/Default.aspx?fm=0"></asp:MenuItem>
        <asp:MenuItem Text="RTS Export" Value="1" NavigateUrl="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/Default.aspx?fm=1"></asp:MenuItem>
        <asp:MenuItem Text="Schedule Export" Value="2" NavigateUrl="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/Default.aspx?fm=2"></asp:MenuItem>
        <asp:MenuItem Text="Export Job List" Value="3" NavigateUrl="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/Default.aspx?fm=3"></asp:MenuItem>
        <asp:MenuItem Text="Hotfix List" Value="4" NavigateUrl="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/Default.aspx?fm=4"></asp:MenuItem>
        <asp:MenuItem Text="MTS Export" Value="5" NavigateUrl="https://azupvweb0048.crossmark.internal.pvt/lawson/cmkNet/MasterTax/Default.aspx?fm=5"></asp:MenuItem>
    </Items>
    </asp:Menu>
    </form>
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="PTS" runat="server">
        <iframe class="iframe"  frameborder="0" width="950px" height="350px" src="pts_export.aspx"></iframe>
        </asp:View>
        <asp:View ID="RTS" runat="server">
        <iframe class="iframe"  frameborder="0" width="950px" height="250px" src="rts_export.aspx"></iframe>
        </asp:View>
        <asp:View ID="Schedule" runat="server">
        <iframe class="iframe"  frameborder="0" width="950px" height="200px" src="schedule_export.aspx"></iframe>
        </asp:View>
        <asp:View ID="Exports" runat="server">
        <iframe class="iframe"  frameborder="0" width="950px" height="350px" src="Export_job_list.aspx"></iframe>
        </asp:View>
        <asp:View ID="HotfixList" runat="server">
        <iframe class="iframe"  frameborder="0" width="950px" height="350px" src="HotFixList.aspx"></iframe>
        </asp:View>
        <asp:View ID="MTS" runat="server">
	<iframe class="iframe"  frameborder="0" width="950px" height="425px" src="mts_export.aspx"></iframe>
        </asp:View>

    </asp:MultiView>
           
</body>
</html>
