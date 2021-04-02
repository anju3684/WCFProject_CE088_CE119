<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_Task.aspx.cs" Inherits="TMSWebClient.add_Task" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 69px;
            width: 281px;
        }
        #Reset1 {
            width: 109px;
        }
    </style>
</head>
<body>
    <h1>Task Management System</h1>
    <form id="form1" runat="server">
        <div>
&nbsp;<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="Register.aspx">Add User</asp:HyperLink>
            &nbsp;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="all_Task.aspx">Manage Task</asp:HyperLink>
            &nbsp;<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="login.aspx">Logout</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            User:
            <asp:DropDownList ID="DropDownList1" runat="server" Height="25px" Width="316px">
            </asp:DropDownList>
            <br />
            <br />
            Subject:
            <asp:TextBox ID="TextBox1" runat="server" Width="298px" Height="25px"></asp:TextBox>
            <br />
            <br />
            Priority: <asp:DropDownList ID="DropDownList2" runat="server" Height="26px" Width="301px">
                <asp:ListItem>Urgent</asp:ListItem>
                <asp:ListItem>High</asp:ListItem>
                <asp:ListItem>Medium</asp:ListItem>
                <asp:ListItem>Low</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            LastDate: <asp:TextBox ID="TextBox2" TextMode="Date" runat="server" Width="284px" Height="25px"></asp:TextBox>
            <br />
            <br />
            Time: <asp:TextBox ID="TextBox3" TextMode="Time" runat="server" Width="319px" Height="24px"></asp:TextBox>
            <br />
            <br />
            Description:
            <asp:TextBox ID="TextBox4" TextMode="MultiLine" Height="100" runat="server" Width="275px"></asp:TextBox>
            <br />
            <br />
            <br />
            Status : <asp:DropDownList ID="DropDownList3" runat="server" Width="189px" Height="22px">
                <asp:ListItem>Pending</asp:ListItem>
                <asp:ListItem>InProgress</asp:ListItem>
                <asp:ListItem>Completed</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Add" Width="94px" />
&nbsp;
            <input id="Reset1" type="reset" value="reset" /></div>
    </form>
    <p>
        &nbsp;</p>
</body>
</html>
