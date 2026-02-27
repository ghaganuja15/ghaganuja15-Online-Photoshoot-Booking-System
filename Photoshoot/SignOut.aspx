<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SignOut.aspx.cs" Inherits="SignOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <style>
    .admin-form {
        max-width: 400px;
        margin: 50px auto;
        padding: 20px;
        border: 1px solid #ccc;
        border-radius: 5px;
        background-color: #f9f9f9;
    }
    .admin-form h2 {
        margin-bottom: 20px;
        text-align: center;
    }
    .form-group {
        margin-bottom: 15px;
    }
    .form-group label {
        display: block;
        margin-bottom: 5px;
    }
    .form-group input {
        width: 100%;
        padding: 8px;box-sizing: border-box;
    }
    .btn-submit, .btn-signout {
        padding: 10px 20px;
        border: none;
        border-radius: 5px;
        cursor: pointer;        width: 100%;
        margin-top: 10px;
    }
    .btn-submit {
        background-color: #28a745;
        color: white;
    }
    .btn-submit:hover {
        background-color: #218838;
    }
    .btn-signout {
        background-color: #dc3545;
        color: white;
    }
    .btn-signout:hover {
        background-color: #c82333;}
</style>
    <div class="admin-form">
        <h2>&nbsp;SignOut</h2>
    <div class="form-group">
        <label for="txtEmail">Email:</label>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtPassword">Password:</label>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter your password"></asp:TextBox>
    </div>
    <asp:Button ID="Button1" runat="server" Text="Sign Out" CssClass="btn-signout" OnClick="btnSignOut_Click" />
    <!-- Message Label -->
    <asp:Label ID="lblMessage" runat="server" CssClass="message-label"></asp:Label>
</div>
</asp:Content>
