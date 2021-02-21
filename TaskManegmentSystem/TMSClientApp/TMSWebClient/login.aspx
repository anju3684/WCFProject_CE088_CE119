<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="TMSWebClient.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <h1>Task Management System</h1>
    <form id="form1" runat="server">
        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        <br />
        Username : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="email" ControlToValidate="TextBox1" ForeColor="Red" runat="server" ErrorMessage="email is required"></asp:RequiredFieldValidator>
        <br />
        <br />
        Password :<asp:TextBox ID="TextBox2" TextMode="Password" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox2" ForeColor="Red" runat="server" ErrorMessage="password is required"></asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
    </form>
</body>
</html>
