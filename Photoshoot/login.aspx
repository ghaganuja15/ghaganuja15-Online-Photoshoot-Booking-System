<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="login.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Login</h2>
                <!-- Email Field -->
    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter Email"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
        ErrorMessage="Email is required" CssClass="error" />
    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
        ValidationExpression="^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$" ErrorMessage="Invalid email format"
        CssClass="error" />

    <!-- Password Field -->
    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"
        Placeholder="Enter Password"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
        ErrorMessage="Password is required" CssClass="error" />

    <!-- Submit Button -->
    <asp:Button ID="BtnRegister" runat="server" CssClass="button" Text="Login" OnClick="BtnRegister_Click" />

    <!-- Login Link -->
    <a href="signup.aspx" class="link">Don't have an account? signup here</a>
</div>
    </form>
</body>
</html>