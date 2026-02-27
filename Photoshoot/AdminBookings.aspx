<%@ Page Title="View Bookings" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminBookings.aspx.cs" Inherits="ViewBookings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" type="text/css" href="AdminBookings.css" />
    <div class="header">
        <h2>View Bookings</h2>
        <p>Here you can view and delete customer bookings.</p>
    </div>

    <asp:Label ID="lblMessage" runat="server" CssClass="message" EnableViewState="false" />

    <asp:GridView ID="GridViewBookings" runat="server" AutoGenerateColumns="False" CssClass="grid-view"
        DataKeyNames="BookingID"
        OnRowDeleting="GridViewBookings_RowDeleting">
        <Columns>
            <asp:BoundField DataField="BookingID" HeaderText="Booking ID" ReadOnly="True" />
            <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
            <asp:BoundField DataField="ShootType" HeaderText="Shoot Type" />
            <asp:BoundField DataField="PreferredDate" HeaderText="Preferred Date" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="AdditionalNotes" HeaderText="Additional Notes" />
            <asp:CommandField ShowDeleteButton="True" HeaderText="Action" />
        </Columns>
    </asp:GridView>
</asp:Content>
