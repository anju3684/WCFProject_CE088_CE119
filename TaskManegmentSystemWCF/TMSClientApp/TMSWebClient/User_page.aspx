<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_page.aspx.cs" Inherits="TMSWebClient.User_page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Task Management System</h1>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="login.aspx">Logout</asp:HyperLink>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <br />
            <asp:ListBox ID="ListBox1" runat="server" AutoPostBack="True" Height="156px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Width="279px"></asp:ListBox>
            <br />
            <br />
            <asp:Panel ID="Panel1" runat="server" Height="342px" Visible="False">
                &nbsp;<asp:Label ID="Label8" runat="server"></asp:Label>
                <br />
                <br />
                Subject:
                <asp:Label ID="Label2" runat="server" BorderColor="Black" Font-Size="Larger" ForeColor="Green"></asp:Label>
                <br />
                <br />
                Description:
                <asp:Label ID="Label3" runat="server"></asp:Label>
                <br />
                <br />
                LastDate:
                <asp:Label ID="Label4" runat="server"></asp:Label>
                &nbsp;<br />
                <br />
                Time :
                <asp:Label ID="Label5" runat="server"></asp:Label>
                <br />
                <br />
                Priority:
                <asp:Label ID="Label6" runat="server"></asp:Label>
                <br />
                <br />
                Status:&nbsp;<asp:Label ID="Label7" runat="server"></asp:Label>
                <br />
                &nbsp;<br /> Completed ?<br />
                <br />
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" Width="88px" />
            </asp:Panel>
        </div>
    </form>
</body>
</html>
