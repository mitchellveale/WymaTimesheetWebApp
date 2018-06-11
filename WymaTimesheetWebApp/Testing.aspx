<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="WymaTimesheetWebApp.Testing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabelBoi" runat="server" Text="Pressa da button boi"></asp:Label>
            <br />
            <br />
            <asp:Button ID="ButtonBoi" runat="server" Text="Press me hard daddy!" OnClick="ButtonBoiClick" />
        </div>
    </form>
</body>
</html>

