<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WymaTimesheetWebApp.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Das Index Page</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="TitleLabel" Font-Size="20px" Font-Bold="true" Text="What is your name?" runat="server" />
            <br/>
            <asp:TextBox ID="InputField" runat="server" />
            <asp:Button ID="MainButton" Text="Submit" OnClick="MainButton_Click" runat="server"/>
            <br />
            <br />
            <asp:Label ID="GreetingLabel" Text="This shouldn't be visible..." Visible="false" runat="server" />
        </div>
    </form>
</body>
</html>
