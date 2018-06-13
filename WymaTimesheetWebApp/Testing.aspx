<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Testing.aspx.cs" Inherits="WymaTimesheetWebApp.Testing" %>

<!DOCTYPE html>

<link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            
            <asp:Table ID="JobsAssembliesTable" runat="server" CssClass="Text table " Width="100%">
                            <asp:TableHeaderRow CssClass="th">
                                <asp:TableHeaderCell>Job/Assy</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Number</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Step/Task</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Hours</asp:TableHeaderCell>
                                <asp:TableHeaderCell>WyEU REF</asp:TableHeaderCell>
                                <asp:TableHeaderCell>EU Step/Task</asp:TableHeaderCell>
                                <asp:TableHeaderCell>EU Cust</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Customer</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                            <asp:TableRow>
                                <asp:TableHeaderCell> <asp:Label runat="server" ID="JobAssyData" CssClass="Text"></asp:Label> </asp:TableHeaderCell>
                                <asp:TableHeaderCell> <asp:DropDownList runat="server" ID="NumberData" CssClass="Text" ></asp:DropDownList> </asp:TableHeaderCell>
                                <asp:TableHeaderCell> <asp:DropDownList runat="server" ID="StepTaskData" CssClass="Text" ></asp:DropDownList> </asp:TableHeaderCell>
                                <asp:TableHeaderCell> <asp:TextBox runat="server" ID="HoursData" CssClass="Text" ></asp:TextBox> </asp:TableHeaderCell>
                                <asp:TableHeaderCell> <asp:Label runat="server" ID="WyEUrefData" CssClass="Text"></asp:Label> </asp:TableHeaderCell>
                                <asp:TableHeaderCell> <asp:Label runat="server" ID="EUStepData" CssClass="Text"></asp:Label> </asp:TableHeaderCell>
                                <asp:TableHeaderCell> <asp:Label runat="server" ID="EUCustData" CssClass="Text"></asp:Label> </asp:TableHeaderCell>
                                <asp:TableHeaderCell> <asp:Label runat="server" ID="CustData" CssClass="Text"></asp:Label> </asp:TableHeaderCell>

                            </asp:TableRow>
                            <asp:TableRow>
                               <asp:TableCell ColumnSpan="8"><button runat="server" id="JATableADD"  class="btn3" style="margin:25px"  onserverclick="BtnJATableClick">ADD</button></asp:TableCell>
                           </asp:TableRow>

                        </asp:Table>


            <asp:GridView ID="DataJAView" runat="server" CssClass="Text gridview" ></asp:GridView>  
            
        </div>
    </form>
</body>
</html>

