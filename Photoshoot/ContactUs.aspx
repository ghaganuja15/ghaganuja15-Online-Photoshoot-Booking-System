<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <link rel="stylesheet" href="ContactUs.css" />
    <div class="contact-container">
        <h2>Contact Us</h2>
        <p>For inquiries and bookings, please contact us:</p>
        <p>SG Photofilms</p>
        
        <div class="contact-details">
            <p>123 dervan fata, sawarde</p>
            <p><strong>Phone:</strong> 7038248518</p>
            <p><strong>Email:</strong> photoshootbooking@gmail.com</p>
        </div>

        <div class="social-media">
            <p><strong>Follow us on Instagram:</strong></p>
            <a href="https://www.instagram.com/on_cameraaaa/" target="_blank">
            <img src="images/instagram.jpg" style="width: 48px; margin-left: 0px;">
                <p>on_cameraaaa</p></a>
            <a href="https://www.instagram.com/drone_walaa/" target="_blank">
            <p>drone_walaa</p></a>
            
        </div>
    </div>

</asp:Content>

