<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="TMSWebClient.Register" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Reset1 {
            width: 93px;
        }
    </style>
</head>
<body>
    <h1>Task Management System</h1>
    <form id="form1" runat="server">
        <div>
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="add_Task.aspx">Add Task</asp:HyperLink>
&nbsp;&nbsp;<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="all_Task.aspx">Manage Task</asp:HyperLink>
            &nbsp;<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="login.aspx">Logout</asp:HyperLink>
            &nbsp;<br />
            <br />
            <asp:Label ID="Label1" ForeColor="Green" runat="server"></asp:Label>
            <br />
            Role :
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="-1">Select Role</asp:ListItem>
                <asp:ListItem Value="Project Manager">Project Manager</asp:ListItem>
                <asp:ListItem Value="Student">Student</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ForeColor="Red" runat="server" ControlToValidate="DropDownList1" ErrorMessage="Select Role"></asp:RequiredFieldValidator>
            <br />
            <br />
            Name :
            <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="177px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="name" ControlToValidate="TextBox1" ErrorMessage="Name is Required" ForeColor="Red" runat="server">
            </asp:RequiredFieldValidator>
            <br />
            <br />
            Email :
            <asp:TextBox ID="TextBox2" runat="server" Height="16px" Width="177px"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" runat="server" ControlToValidate="TextBox2" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="invalid email"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="email" ControlToValidate="TextBox2" ForeColor="Red" runat="server" ErrorMessage="email is required"></asp:RequiredFieldValidator>
            <br />
            <br />
            Password:
            <asp:TextBox ID="TextBox3" runat="server" TextMode="Password" Height="16px" Width="177px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="TextBox3" ErrorMessage="Password is required"></asp:RequiredFieldValidator>            <br />
            <br />
            Confirm Password:
            <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" Height="16px" Width="177px"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ForeColor="Red" ControlToValidate="TextBox4" ErrorMessage="Confirm Password is required"></asp:RequiredFieldValidator>
            <asp:CompareValidator ForeColor="Red" ControlToValidate="TextBox3" ControlToCompare="TextBox4" ErrorMessage="Password Doesn't Match"
                runat="server"></asp:CompareValidator>
            <br />
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="ADD" OnClick="Button1_Click" Width="97px" />
            &nbsp;
            <input id="Reset1" type="reset" value="reset" /><br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>

