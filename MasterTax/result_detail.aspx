<%@ Page Language="C#" AutoEventWireup="true" CodeFile="result_detail.aspx.cs" Inherits="result_detail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    
    
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
        }
        catch (e) {
            window.location = "http://myinfo.crossmark.internal.pvt";
        }
    }
    window.onload = checkgroup;
</script>
beginning snippets  -->
<!-- end snippets -->

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            OnRowDataBound="RowDataBound">
    <Columns>
            <asp:BoundField
              HeaderText="JOBID"
              DataField="JOBID" />   
            <asp:TemplateField HeaderText="FILENAME">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Visible="false"
                        NavigateUrl='<%# Eval("FILENAME", "\\\\plnpvapp0078\\shared$\\PTS_Exports\\{0}") %>' 
                        Text='<%# Eval("FILENAME") %>'></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink2" runat="server" Visible="false"
                        NavigateUrl='<%# Eval("FILENAME", "\\\\plnpvapp0078\\shared$\\RTS_Exports\\{0}") %>' 
                        Text='<%# Eval("FILENAME") %>'></asp:HyperLink>
                    <asp:HyperLink ID="HyperLink3" runat="server" Visible="false"
                        NavigateUrl='<%# Eval("FILENAME", "\\\\plnpvapp0078\\shared$\\MTS_Exports\\{0}") %>' 
                        Text='<%# Eval("FILENAME") %>'></asp:HyperLink> 
                </ItemTemplate>                
            </asp:TemplateField>
            <asp:BoundField
              HeaderText="CREATION DATE"
              DataField="CREATION DATE" />  
    </Columns>
    
    </asp:GridView>
    </div>
    </form>
</body>
</html>
