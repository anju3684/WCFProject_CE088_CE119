<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="all_task.aspx.cs" Inherits="TMSWebClient.all_task" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Reset1 {
            width: 95px;
        }
    </style>
</head>
<body>
    <h1>Task Management System</h1>
    <form id="form1" runat="server">
        <div>
            &nbsp;<asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="Register.aspx">Add User</asp:HyperLink>
            &nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="add_Task.aspx">Add Task</asp:HyperLink>
&nbsp; <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="login.aspx">Logout</asp:HyperLink>
            &nbsp;<br />
            <br />
            Tasks...<br />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <br />
            TaskId :
            <asp:TextBox ID="TextBox1" runat="server" Height="25px" Width="211px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update" Width="88px" />
&nbsp;<asp:Button ID="Button3" runat="server" Text="Delete" Width="88px" OnClick="Button3_Click" />
            <br />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" Width="450px">
            </asp:GridView>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="525px" Visible="False">
                <asp:Label ID="Label1" runat="server"></asp:Label>
                <br />
                <br />
                Subject:
                <asp:TextBox ID="TextBox5" runat="server" Height="25px" Width="298px"></asp:TextBox>
                <br />
                <br />
                Priority:
                <asp:DropDownList ID="DropDownList2" runat="server" Height="26px" Width="301px">
                    <asp:ListItem>Urgent</asp:ListItem>
                    <asp:ListItem>High</asp:ListItem>
                    <asp:ListItem>Medium</asp:ListItem>
                    <asp:ListItem>Low</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                LastDate:
                <asp:TextBox ID="TextBox2" runat="server" Width="284px" Height="25px" TextMode="Date"></asp:TextBox>
                <br />
                <br />
                Time:
                <asp:TextBox ID="TextBox3" runat="server" Height="24px" TextMode="Time" Width="319px"></asp:TextBox>
                <br />
                <br />
                Description:
                <asp:TextBox ID="TextBox4" TextMode="MultiLine" runat="server" Width="275px" Height="100"></asp:TextBox>
                <br />
                <br />
                <br />
                Status :
                <asp:DropDownList ID="DropDownList3" runat="server" Height="22px" Width="189px">
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>InProgress</asp:ListItem>
                    <asp:ListItem>Completed</asp:ListItem>
                </asp:DropDownList>
                <br />
                <br />
                &nbsp;
                <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Update Task" Width="94px" />
                &nbsp;&nbsp;
                </asp:Panel>
            <br />
        </div>
    </form>
</body>
</html>
