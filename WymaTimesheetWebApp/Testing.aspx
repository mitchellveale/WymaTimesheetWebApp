<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="WymaTimesheetWebApp.Testing" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test Page</title>
    <link rel="icon" type="image/png" href="Images/favicon.png"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="LabelBoi" runat="server" Text="Pressa da button boi"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br/>
            <asp:Button ID="AddButton" runat="server" Text="Add" OnClick="AddButton_Click" />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <br/>
            <asp:ScriptManager ID="Scriptmanager1" runat="server"/>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <ajaxToolkit:AutoCompleteExtender runat="server" ID="AutoCompleteExtender" TargetControlID="TextBox4" MinimumPrefixLength="1" EnableCaching="true" CompletionInterval="10" CompletionSetCount="3" ServiceMethod="GetValues"></ajaxToolkit:AutoCompleteExtender>
        </div>
    </form>
</body>
</html>

