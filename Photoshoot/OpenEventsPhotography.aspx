<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="OpenEventsPhotography.aspx.cs" Inherits="OpenEventPhotography" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" type="text/css" href="PersonalPhotography.css" />
    <h2 class="auto-style2" style="margin-left: 600px">Open Events Photography</h2>
    <img src="images/event3.jpg" alt="Banner Image" style="height: 572px; width: 1430px; margin-top: 23px;">
        <h2 class="auto-style2" style="margin-left: 640px">What we are provide?</h2>
    <div class="services-container">
        <asp:Repeater ID="rptServices" runat="server">
            
            <ItemTemplate>
    <div class="service">
        <!-- Full Data Set 1 (Service Name, Description, Price, Book Now) -->
         <img src='<%# Eval("ImageURL") %>' alt='<%# Eval("ServiceName") %>' />
        <h3><%# Eval("ServiceName") %></h3>
        <p><%# Eval("Description") %></p>
        <div class="price">
            <strong>Price:</strong> <%# Eval("Price", "{0:C}") %>
        </div>
        <asp:HyperLink ID="HyperLinkBookNow" runat="server"
            NavigateUrl='<%# "~/BookNow.aspx?service=" + HttpUtility.UrlEncode(Eval("ServiceName").ToString()) + "&price=" + HttpUtility.UrlEncode(Eval("Price").ToString()) %>'
            Text="Book Now" CssClass="book-button">
        </asp:HyperLink>
    </div>
</ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Label ID="lblMessageStatus" runat="server" Text="" CssClass="error-message"></asp:Label>
</asp:Content>

