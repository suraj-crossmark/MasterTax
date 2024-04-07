<%@ Page Language="C#" AutoEventWireup="true" CodeFile="db_call_test.aspx.cs" Inherits="db_call_test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        <br />
        <br />
    </div>
     <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
         <Columns>
             <asp:HyperLinkField
             HeaderText="Test link"
              DataNavigateUrlFields="EMPLOYEE"
              DataNavigateUrlFormatString="./test?employee={0}"
              DataTextField="EMPLOYEE"
              Target="_self"               
             />     
             <asp:BoundField
              HeaderText="PROVINCE"
              DataField="PROVINCE" />         
         </Columns>     
    </asp:GridView>

    </form>
    

</body>
</html>

