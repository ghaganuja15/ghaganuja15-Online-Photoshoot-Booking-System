<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
      <link rel="stylesheet" href="Home.css" />
    <div class="banner">
        <img src="images/image2.jpg" alt="Banner Image" style="height: 572px; width: 1500px; margin-top: 23px;">
        <div class="banner-text" style="left: 42%; top: 25700%; margin-top: 1px">
            <h1>Photographer</h1>
        </div>
    </div>
    <div class="container">
        <h2>Our Offerings</h2>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
&nbsp;<asp:Repeater ID="rptPhotoshoots" runat="server" OnItemCommand="rptPhotoshoots_ItemCommand">
            <ItemTemplate>
                <div class="card">
                    <img src='<%# Eval("ImagePath") %>' alt='<%# Eval("Title") %>'>
                    <h3><%# Eval("Title") %></h3>
                    <p>
                        <%# Eval("Description") %>
                    </p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

