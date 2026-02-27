<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Gallery.aspx.cs" Inherits="Gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
   <link rel="stylesheet" type="text/css" href="Gallery.css" />
    <div class="container">
        <h2>Photo Gallery</h2>

        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
            <asp:ListItem Text="All" Value="All" Selected="True"></asp:ListItem>
            <asp:ListItem Text="Engagement" Value="Engagement"></asp:ListItem>
            <asp:ListItem Text="Pre-Wedding" Value="Pre-Wedding"></asp:ListItem>
            <asp:ListItem Text="Wedding" Value="Wedding"></asp:ListItem>
        </asp:DropDownList>

        <div class="gallery">
            <asp:Repeater ID="rptGallery" runat="server">
                <ItemTemplate>
                    <div class="gallery-item">
                        <img src='<%# Eval("ImagePath") %>' alt="Gallery Image" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

