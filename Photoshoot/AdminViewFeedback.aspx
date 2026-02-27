<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMasterPage.master" AutoEventWireup="true" CodeFile="AdminViewFeedback.aspx.cs" Inherits="AdminViewFeedback" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            margin-left: 360px;
        }
        .auto-style2 {
            margin-left: 440px;
        }
        .auto-style3 {
            margin-left: 480px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <link rel="stylesheet" type="text/css" href="AdminViewFeedback.css" />
    <h2 class="auto-style3">View Feedback</h2>
    <p class="auto-style1">Here you can view and manage feedback submitted by users.</p>

    <!-- Display Existing Feedback -->
    <h3 class="auto-style2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Existing Feedback</h3>
    <asp:GridView ID="GridViewFeedback" runat="server" AutoGenerateColumns="false" DataKeyNames="FeedbackID" OnRowDeleting="GridViewFeedback_RowDeleting" CssClass="grid-view">
        <Columns>
            <asp:BoundField DataField="FeedbackID" HeaderText="Feedback ID" ReadOnly="true" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
            <asp:BoundField DataField="Message" HeaderText="Message" />
            <asp:BoundField DataField="Rating" HeaderText="Rating" />
            <asp:BoundField DataField="SubmissionDate" HeaderText="Submission Date" DataFormatString="{0:MM/dd/yyyy HH:mm:ss}" />
            <asp:CommandField ShowDeleteButton="true" HeaderText="Action" />
        </Columns>
    </asp:GridView>
</asp:Content>

