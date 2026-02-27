<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminOpenEventsPhotography.aspx.cs" Inherits="AdminOpenEventsPhotography" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <link rel="stylesheet" type="text/css" href="AdminOpenEventsPhotography.css" />
<h2>Manage Open Event Photography Services</h2>

<!-- Add New Photography Service Form -->
<h3>Add New Photography Service</h3>
<div class="form-group">
    <label for="txtServiceName">Service Name:</label>
    <asp:TextBox ID="txtServiceName" runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtDescription">Description:</label>
    <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
</div>
<div class="form-group">
    <label for="txtImageURL">Image URL:</label>
    <asp:TextBox ID="txtImageURL" runat="server"></asp:TextBox></div>
<div class="form-group">
    <label for="txtPrice">Price:</label>
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
</div>
<div class="form-group">
    <asp:Button ID="btnAddService" runat="server" Text="Add Photography Service" OnClick="btnAddService_Click" />
</div>

<!-- Display Existing Photography Services -->
<h3>Existing Photography Services</h3>
<asp:GridView ID="GridViewServices" runat="server" AutoGenerateColumns="false" DataKeyNames="ServiceID" OnRowDeleting="GridViewServices_RowDeleting" CssClass="grid-view">
    <Columns>
        <asp:BoundField DataField="ServiceID" HeaderText="ID" ReadOnly="true" />
        <asp:BoundField DataField="ServiceName" HeaderText="Service Name" />
        <asp:BoundField DataField="Description" HeaderText="Description" /> 
        <asp:ImageField DataImageUrlField="ImageURL" HeaderText="Image" ControlStyle-Width="100" />
        <asp:BoundField DataField="Price" HeaderText="Price" />
        <asp:CommandField ShowDeleteButton="true" HeaderText="Action" />
    </Columns>
</asp:GridView>
</asp:Content>

