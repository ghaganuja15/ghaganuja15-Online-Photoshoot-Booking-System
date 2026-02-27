<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
     <link rel="stylesheet" type="text/css" href="Feedback.css" />
    <h2>Feedback Form</h2>
    <div class="feedback-form">
        <asp:Label ID="lblName" runat="server" Text="Name:" AssociatedControlID="txtName"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblEmail" runat="server" Text="Email:" AssociatedControlID="txtEmail"></asp:Label>
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />

        <asp:Label ID="lblMessage" runat="server" Text="Message:" AssociatedControlID="txtMessage"></asp:Label>
        <asp:TextBox ID="txtMessage" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
        <br /> <asp:Label ID="lblRating" runat="server" Text="Rating (1-5):" AssociatedControlID="ddlRating"></asp:Label>
        <asp:DropDownList ID="ddlRating" runat="server">
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
            <asp:ListItem Text="5" Value="5"></asp:ListItem>
        </asp:DropDownList>
        <br />

        <asp:Button ID="btnSubmit" runat="server" Text="Submit Feedback" OnClick="btnSubmit_Click" />
        <asp:Label ID="lblMessageStatus" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>

