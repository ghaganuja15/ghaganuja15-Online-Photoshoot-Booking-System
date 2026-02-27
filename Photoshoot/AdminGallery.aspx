<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminGallery.aspx.cs" Inherits="AdminGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link rel="stylesheet" type="text/css" href="AdminGallery.css" />
    <h2>Manage Gallery Images</h2>

    <!-- Add New Gallery Image Form -->
    <h3>Add New Gallery Image</h3>
    <div class="form-group">
        <label for="txtImagePath">Image Path:</label>
        <asp:TextBox ID="txtImagePath" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <label for="txtCategory">Category:</label>
        <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
    </div>
    <div class="form-group">
        <asp:Button ID="btnAddImage" runat="server" Text="Add Image" OnClick="btnAddImage_Click" />
    </div><!-- Display Existing Gallery Images -->
    <h3>Existing Gallery Images</h3>
    <asp:GridView ID="GridViewGallery" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" OnRowDeleting="GridViewGallery_RowDeleting" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
            <asp:BoundField DataField="ImagePath" HeaderText="Image Path" />
            <asp:BoundField DataField="Category" HeaderText="Category" />
            <asp:ImageField DataImageUrlField="ImagePath" HeaderText="Image" ControlStyle-Width="100" />
            <asp:CommandField ShowDeleteButton="true" HeaderText="Action" />
        </Columns>
    </asp:GridView>
</asp:Content>

