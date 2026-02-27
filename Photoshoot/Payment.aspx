<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Payment.aspx.cs" Inherits="Payment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <style>
        /* General Styles */
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        /* Page Title */
        h2 {
            text-align: center;
            margin-top: 20px;
            color: #333;
        }

        /* Form Container */
        div {
            margin: 10px auto;
            padding: 10px;
            max-width: 400px;
            background-color: #fff;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
            border-radius: 5px;
        }

        label {
            font-weight: bold;
            display: block;
            margin-bottom: 5px;
            color: #333;
        }

        input[type="text"] {
            width: 100%;
            padding: 10px;
            margin-bottom: 10px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 16px;
        }

        input[type="text"]:focus {
            border-color: #007bff;
            outline: none;
        }

        /* Read-Only Input */
        input[readonly] {
            background-color: #f9f9f9;
        }

        /* Button Styles */
        button, input[type="button"], input[type="submit"] {
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            width: 100%;
        }

        button:hover, input[type="button"]:hover, input[type="submit"]:hover {
            background-color: #0056b3;
        }

        /* Error Message */
        .error-message {
            display: block;
            margin-top: 10px;
            color: red;
            font-size: 14px;
        }

        /* Responsive Design */
        @media (max-width: 600px) {
            div {
                max-width: 90%;
                padding: 20px;
            }

            input[type="text"] {
                font-size: 14px;
            }

            button, input[type="button"], input[type="submit"] {
                font-size: 14px;
            }
        }
    </style>
    <h2>Online Payment</h2>
    <div>
        <asp:Label ID="lblAdvanceAmount" runat="server" Text="Advance Amount:"></asp:Label>
        <asp:TextBox ID="txtAdvanceAmount" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblRemainingAmount" runat="server" Text="Remaining Amount:"></asp:Label>
        <asp:TextBox ID="txtRemainingAmount" runat="server" ReadOnly="true"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblCardNumber" runat="server" Text="Card Number:"></asp:Label>
        <asp:TextBox ID="txtCardNumber" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblExpiryDate" runat="server" Text="Expiry Date:"></asp:Label>
        <asp:TextBox ID="txtExpiryDate" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Label ID="lblCVV" runat="server" Text="CVV:"></asp:Label>
        <asp:TextBox ID="txtCVV" runat="server"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="btnPayNow" runat="server" Text="Pay Now" OnClick="btnPayNow_Click" />
    </div>
    <asp:Label ID="lblMessage" runat="server" Text="" CssClass="error-message"></asp:Label>
   </asp:Content>