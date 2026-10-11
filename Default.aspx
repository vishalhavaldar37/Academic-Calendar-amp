<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AcademicLeaveManagement._Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Academic Calendar and Leave Management</title>
</head>
<body>
<form id="form1" runat="server">
    <h1>Academic Calendar & Leave Management System</h1>

    <h2>Student Login</h2>
    Name: <asp:TextBox ID="txtName" runat="server" />
    <asp:Button ID="btnSession" runat="server" Text="Start Session" OnClick="btnSession_Click" />
    <asp:Button ID="btnCookie" runat="server" Text="Remember Name" OnClick="btnCookie_Click" />
    <asp:Label ID="lblWelcome" runat="server" />
    <hr />

    <h2>Academic Calendar</h2>
    <asp:Calendar ID="calDate" runat="server" OnSelectionChanged="calDate_SelectionChanged" />
    <asp:Label ID="lblDate" runat="server" Text="Select a date." />
    <hr />

    <h2>Apply for Leave</h2>
    Leave Type:
    <asp:DropDownList ID="ddlType" runat="server">
        <asp:ListItem>Medical Leave</asp:ListItem>
        <asp:ListItem>Personal Leave</asp:ListItem>
        <asp:ListItem>Emergency Leave</asp:ListItem>
    </asp:DropDownList>
    <br /><br />

    From Date: <asp:TextBox ID="txtFrom" runat="server" TextMode="Date" />
    <br /><br />
To Date: <asp:TextBox ID="txtTo" runat="server" TextMode="Date" />
    <br /><br />
    Reason: <asp:TextBox ID="txtReason" runat="server" />
    <br /><br />

    <asp:Button ID="btnApply" runat="server" Text="Submit Leave" OnClick="btnApply_Click" />
    <asp:Label ID="lblMessage" runat="server" />
    <hr />

    <h2>Leave Applications</h2>
    <asp:GridView ID="gvLeaves" runat="server" AutoGenerateColumns="true"
        EmptyDataText="No applications submitted." />
</form>
</body>
</html>
