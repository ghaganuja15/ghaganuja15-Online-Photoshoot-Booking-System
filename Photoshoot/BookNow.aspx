<%@ Page Title="Book Your Photoshoot" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BookNow.aspx.cs" Inherits="BookNow" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" href="BookNow.css" />
    <h2>Book Your Photoshoot</h2>
    <asp:Label ID="lblMessage" runat="server" Text="Book Your Photoshoot" ForeColor="Green"></asp:Label>

    <!-- Customer Information Form -->
    <div>
        <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name:"></asp:Label>
        <asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone Number:"></asp:Label>
        <asp:TextBox ID="txtPhoneNumber" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblServiceName" runat="server" Text="Service Name:"></asp:Label>
        <asp:Label ID="lblDisplayServiceName" runat="server" Text="" CssClass="service-info"></asp:Label>    </div>
    <div>
        <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
        <asp:Label ID="lblDisplayPrice" runat="server" Text="" CssClass="service-info"></asp:Label>
    </div>
    <div>
        <asp:Label ID="lblPreferredDate" runat="server" Text="Preferred Date:"></asp:Label>
        <asp:TextBox ID="txtPreferredDate" runat="server" TextMode="Date"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblAdditionalNotes" runat="server" Text="Additional Notes:"></asp:Label>
        <br/>
        <asp:TextBox ID="txtAdditionalNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
    </div>

    <asp:Label ID="lblAdvanceAmount" runat="server" Text="Advance Amount (25% of Total Price):"></asp:Label>
<asp:TextBox ID="txtAdvanceAmount" runat="server" ReadOnly="true"></asp:TextBox>

    <!-- Payment Option -->
    <div>
        <asp:Label ID="paymentOption" runat="server" Text="Payment Option:"></asp:Label>
        <br />
        <asp:RadioButton ID="RadioButton1" runat="server" Text="Pay Online" Checked="true" GroupName="PaymentOption" />
       
    </div>

    <!-- Calendar to Show Booked Dates -->
    <div>
        <h3>Booked Dates</h3>
        <asp:Calendar ID="calBookedDates" runat="server" OnDayRender="calBookedDates_DayRender" CssClass="calendar-style"></asp:Calendar>
    </div>

    <!-- Submit Button -->
    <div>
        <asp:Button ID="btnPayment" runat="server" Text="Confirm Booking" OnClick="btnPayment_Click" />
    </div>
</asp:Content>