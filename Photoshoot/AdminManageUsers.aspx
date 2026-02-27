<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminManageUsers.aspx.cs" Inherits="AdminManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="adminhome.css" />
    <h2>Manage Users</h2>
    <p>Here you can manage all the users registered in the system.</p>

    <!-- Display Existing Users -->
    <h3>Existing Users</h3>
    <asp:GridView ID="GridViewUsers" runat="server" AutoGenerateColumns="false" DataKeyNames="UserId" OnRowDeleting="GridViewUsers_RowDeleting" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="UserId" HeaderText="User ID" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Address" HeaderText="Address" />
            <asp:BoundField DataField="Contact" HeaderText="Contact" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:CommandField ShowDeleteButton="true" HeaderText="Action" />
        </Columns>
    </asp:GridView>
</asp:Content>

