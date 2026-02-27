<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <style>
        /* General styles */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        h2 {
            color: #333;
            text-align: center;
            margin-bottom: 20px;
        }

        .profile-container {
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
            background-color: #fff;
            border: 1px solid #ddd;
            border-radius: 5px;box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        }

        .profile-container p {
            margin: 10px 0;
        }

        .profile-container strong {
            display: inline-block;
            width: 120px;
            font-weight: bold;
        }

        .profile-container input[type="text"],
        .profile-container input[type="password"] {
            width: calc(100% - 130px);
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
.profile-container .btnSearch,
        .profile-container .btnUpdate {
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            border-radius: 4px;
            cursor: pointer;
            margin-top: 10px;
        }

        .profile-container .btnSearch:hover,
        .profile-container .btnUpdate:hover {
            background-color: #0056b3;
        }

        .profile-container .lblMessage {
            display: block;
            margin-top: 10px;
            color: #d9534f;
            font-weight: bold;
        }
    .auto-style4 {
        height: 119px;
    }
    </style>

<div class="profile-container">
       <h2>User Profile</h2>
     &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
     <img src="images/profile.jpg" class="auto-style4">
       <p>&nbsp;</p>
        <div>
            <p>
                <strong>Enter Username:</strong>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btnSearch" />
            </p>
            <p><strong>Name:</strong> <asp:TextBox ID="txtName" runat="server"></asp:TextBox></p>
            <p><strong>Address:</strong> <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></p>
            <p><strong>Contact:</strong> <asp:TextBox ID="txtContact" runat="server"></asp:TextBox></p>
            <p><strong>Email:</strong> <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></p>
            <p><strong>Old Password:</strong> <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox></p>
            <p><strong>New Password:</strong> <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox></p>
            <p>
                <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" CssClass="btnUpdate" /> 
                <asp:Label ID="lblMessage" runat="server" Text="" CssClass="lblMessage"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>

