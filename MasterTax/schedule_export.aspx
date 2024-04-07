<%@ Page Language="C#" AutoEventWireup="true" CodeFile="schedule_export.aspx.cs" Inherits="schedule_export" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <!-- Checks to see if they users in the right group 
beginning snippets uncomment when in production -->
<xml ID="writersXML" SRC="/servlet/Profile"></xml>
<script src="/lawson/cmkNet/javascript/MyInfoProfile.js" type="text/javascript"></script>
<script type="text/javascript">
    function checkgroup() {
        try {

            var group = findLawsonGroup("writersXML", "Mastertax Users");

            if (group == undefined) {
                window.location = "http://myinfo.crossmark.internal.pvt";
            }
            else {
                getmyinfouser();
                dropdown_selection();
                
            }
        }
        catch (e) {
            window.location = "http://myinfo.crossmark.internal.pvt";
        }
    }
    
    function getmyinfouser() 
    {
        document.form1.MyInfoUser.value = findLawsonAttrValue("writersXML", "id"); 
    }
    
    function dropdown_selection() {
        var myindex = document.form1.filetype.selectedIndex;
        var SelValue = document.form1.filetype.options[myindex].text;

        switch (myindex)
        {    
        case 0:
        document.getElementById("Label2").style.display = '';
        document.getElementById("TextBox1").style.display = '';
        document.getElementById("Label3").style.display = '';
        document.getElementById("TextBox2").style.display = '';

        document.getElementById("Label1").style.display = 'none';
        document.getElementById("DropDownList4").style.display = 'none';
        document.getElementById("DropDownList5").style.display = 'none';
        document.getElementById("TextBox4").style.display = 'none';
        break;

        case 1:
        document.getElementById("Label2").style.display = 'none';
        document.getElementById("TextBox1").style.display = 'none';
        document.getElementById("Label3").style.display = 'none';
        document.getElementById("TextBox2").style.display = 'none';    
        
        document.getElementById("Label1").style.display = '';
        document.getElementById("DropDownList4").style.display = '';
        document.getElementById("DropDownList5").style.display = '';
        document.getElementById("TextBox4").style.display = '';
        break;

        default:
        hide_options();
        alert("Please select a file type");
        }

        document.form1.SelectedFileType.value = SelValue;
    }

    function hide_options() {
        document.getElementById("Label1").style.display = 'none';
        document.getElementById("DropDownList4").style.display = 'none';

        document.getElementById("Label2").style.display = 'none';
        document.getElementById("TextBox1").style.display = 'none';
        document.getElementById("Label3").style.display = 'none';
        document.getElementById("TextBox2").style.display = 'none';
    }


    window.onload = checkgroup;
    
</script>
    
    <style type="text/css">
        .style1
        {
            width: 89px;
        }
        .style2
        {
            width: 242px;
        }
        .style4
        {
            width: 42px;
        }
        .style5
        {
            width: 110px;
        }
        .style6
        {
            height: 36px;
        }
        .style7
        {
            width: 242px;
            height: 36px;
        }
        .style9
        {
            width: 42px;
            height: 36px;
        }
        .style10
        {
            width: 110px;
            height: 36px;
        }
        .style11
        {
            width: 109px;
        }
        .style12
        {
            width: 109px;
            height: 36px;
        }
        .style13
        {
            width: 65px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="SelectedFileType" runat="server" />
    <asp:HiddenField ID="MyInfoUser" runat="server" />  
    <div>
        <table style="width:900px; height: 96px;">
            <tr>
                <td class="style1">
                    <asp:Label ID="Label7" runat="server" Text="Type of File"></asp:Label></td>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Enter Year, Select Quarter and Reporting Process Level:"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Text="Enter Date Range (mm/dd/yyyy)"></asp:Label></td>
                <td class="style11"><asp:Label ID="Label4" runat="server" Text="Schedule Date"></asp:Label>&nbsp;(mm/dd/yyyy)</td>
                <td class="style4"><asp:Label ID="Label5" runat="server" Text="Hour"></asp:Label></td>
                <td class="style13"><asp:Label ID="Label6" runat="server" Text="Minutes"></asp:Label></td>
                <td ><asp:Label ID="Label8" runat="server" Text="AM/PM"></asp:Label></td>
            </tr>
            <tr>
                <td class="style1">
                <select name="filetype" onchange="dropdown_selection()">
                    <option>PTS</option>
                    
                </select>
                </td>
                <td class="style2">
                    <asp:TextBox ID="TextBox4" runat="server" Width="85px" MaxLength="4"></asp:TextBox>
                    <asp:DropDownList ID="DropDownList4" runat="server"></asp:DropDownList>
                    <asp:DropDownList ID="DropDownList5" runat="server"></asp:DropDownList>
                    <asp:TextBox ID="TextBox1" runat="server" Width="85px"></asp:TextBox>
                    <asp:Label ID="Label3" runat="server" Text=" to "></asp:Label>
                    <asp:TextBox ID="TextBox2" runat="server" Width="85px"></asp:TextBox>
        
                </td>

                <td class="style11">
                    <asp:TextBox ID="TextBox3" runat="server" Width="115px"></asp:TextBox>
                </td>
                <td class="style4">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                    </asp:DropDownList>
                </td>
                <td class="style13">
                    <asp:DropDownList ID="DropDownList3" runat="server">
                    </asp:DropDownList>
                </td>
                                <td class="style5">
                    <asp:DropDownList ID="DropDownList1" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style6"></td>
                <td class="style7"></td>
                <td class="style12"></td>
                <td class="style9"></td>
                <td class="style13" ></td>
                <td class="style10" ><asp:Button ID="Button1" runat="server" 
                        Text="Submit Scheduled Job" onclick="Button1_Click" /></td>    
            </tr>
        </table>
        
    </div>
    </form>
</body>
</html>
