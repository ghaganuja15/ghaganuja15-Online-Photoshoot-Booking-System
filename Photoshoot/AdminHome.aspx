<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminHome.aspx.cs" Inherits="AdminHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="stylesheet" type="text/css" href="adminhome.css" />
    <h2>Welcome, Admin!</h2>
    <p>Manage your PhotoShoots from here.</p>

    <!-- Add New PhotoShoot Form -->
    <h3>Add New PhotoShoot</h3>
    <div class="form-group">
        <label for="txtTitle">Title:</label>
        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtDescription">Description:</label>
        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtImagePath">Image Path:</label>
        <asp:TextBox ID="txtImagePath" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnAdd" runat="server" Text="Add PhotoShoot" OnClick="btnAdd_Click" />
    </div>

    <!-- Display Existing PhotoShoots --><h3>Existing PhotoShoots</h3>
    <asp:GridView ID="GridViewPhotoShoots" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowDeleting="GridViewPhotoShoots_RowDeleting" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" />
            <asp:ImageField DataImageUrlField="ImagePath" HeaderText="Image" ControlStyle-Width="100" />
            <asp:CommandField ShowDeleteButton="true" HeaderText="Action" />
        </Columns>
    </asp:GridView>
</asp:Content>

