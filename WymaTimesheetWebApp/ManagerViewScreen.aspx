<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerViewScreen.aspx.cs" Inherits="WymaTimesheetWebApp.ManagerViewScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Managers View</title>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
</head>
<body>
     <form id="MVS" runat="server">
    <div id="Outerrap">
        <!-- This Header contains the wyma logo -->
        <div id="HeaderRap">
            <div id="Header">
                <img id="WymaLogo" src="Images/wyma-logo.svg" style="height: 76px; width: 295px; margin-bottom: 0px; margin-top: 0px;"/>

                <div id="HeaderLabel" class="Text" >
                    <label  draggable="false">Managers View Screen</label>
                </div>

            </div>
        </div>

         <div id="Main" >
                <div id="Data"> 
                    <div id="Form">
                        <label class="Text">Name:</label>
                        <label id="ManagerName" class="Text">TEST</label>
                        <asp:Table ID="TimeSheetsTable" runat="server" CssClass="Text table" Width="60%">
                            <asp:TableHeaderRow CssClass="th">
                                <asp:TableHeaderCell>Accept</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Decline</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Employees Name</asp:TableHeaderCell>
                                <asp:TableHeaderCell>View Timesheet</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>

                        
                               
                    </div>
                    
                </div>
        </div>
        <div id="FooterRap">
            <div id="Footer1">

                <button id="btnSubmitDT" class="btnsubmit" style="float:left;">Submit</button>

            </div>
            <div id="Footer2">

                <button id="btnCancelDT" class="btncancel" style=" float:right;">Cancel</button>


            </div>
        </div>
    </div>
    </form>
</body>
</html>
