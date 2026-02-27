<%@ Page Language="C#" AutoEventWireup="true" CodeFile="signup.aspx.cs" Inherits="signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="signup.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>SignUp</h2>

            <!-- Name Field -->
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter Name"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                ErrorMessage="Name is required" CssClass="error" />

            <!-- Address Field -->
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Placeholder="Enter Address"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                ErrorMessage="Address is required" CssClass="error" />

           <!-- Contact Field -->
           <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" Placeholder="Enter Contact"></asp:TextBox>

           <!-- Required Field Validator -->
            <asp:RequiredFieldValidator ID="rfvContact" runat="server" 
             ControlToValidate="txtContact"
             ErrorMessage="Contact is required" 
             CssClass="error" 
             Display="Dynamic" />

            <!-- Regular Expression Validator -->
            <asp:RegularExpressionValidator ID="revContact" runat="server" 
             ControlToValidate="txtContact"
             ValidationExpression="^[0-9]{10}$" 
             ErrorMessage="Invalid contact number. Please enter exactly 10 digits." 
             CssClass="error" 
             Display="Dynamic" />

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
            <asp:Button ID="BtnRegister" runat="server" CssClass="button" Text="SignUp" OnClick="BtnRegister_Click" />

            <!-- Login Link -->
            <a href="login.aspx" class="link">Already have an account? Login here</a>
        </div>
    </form>
</body>
</html>