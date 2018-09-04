<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportTest.aspx.cs" Inherits="WymaTimesheetWebApp.ExportTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Title" runat="server" Text="Enter the index of the file that you want to view"></asp:Label>
            <br />
            <asp:DropDownList ID="Dropdown" runat="server">
            </asp:DropDownList>
            <asp:Label ID="Name" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="Date" runat="server" Text="Label" Visible="false"></asp:Label>
            <asp:Label ID="Manager" runat="server" Text="Label" Visible="false"></asp:Label>
            <br />
            <asp:Button ID="ButtonBoi" runat="server" Text="View" onclick="ButtonBoi_Click"/>


        </div>
    </form>
</body>
</html>
