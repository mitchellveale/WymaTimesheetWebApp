<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewScreen.aspx.cs" Inherits="WymaTimesheetWebApp.ViewScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Timesheet</title>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
</head>
<body>
    <<form id="VS" runat="server">
    <div id="Outerrap">
        <!-- This Header contains the wyma logo -->
        <div id="HeaderRap">
            <div id="Header">
                <img id="WymaLogo" src="Images/wyma-logo.svg" style="height: 76px; width: 295px; margin-bottom: 0px; margin-top: 0px;"/>

                <div id="HeaderLabel" class="Text" >
                    <label  draggable="false">Review Timesheet</label>
                </div>

            </div>
        </div>

         <div id="Main">
                <div id="Data"> 
                   <div id="TD_Info">
                    <p>
                        <label id="EmployeeName" class="Text">Employee Name: </label>
                        <label id="EmployeeNameData" class="Text">TEST</label>
                    </p>
                    <p>
                        <label id="TimeWorked" class="Text">Time Worked Between: </label>
                        <label id="TimeWorkedData" class="Text">TEST</label>
                    </p>
                    <p>
                        <label id="BreakTime" class="Text">Break Time: </label>
                        <label id="BreakTimeData"class="Text">TEST</label>
                    </p>
                        <p>
                        <label id="TotalTimeWorked" class="Text">Total Time Worked: </label>
                        <label id="TotalTimeWorkedData"class="Text">TEST</label>
                    </p>

                       
                   </div>
                   <div id="TableSheet">
                        <label class="Text">Jobs and Assemblies</label>
                        <asp:Table ID="JobsAssembliesViewTable" runat="server" CssClass="Text table " Width="100%">
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
                            
                           
                        </asp:Table>
                        <label class="Text">Non-Charge Hours</label>
                        <asp:Table ID="NonChargeViewTable" runat="server" CssClass="Text table " Width="100%">
                            <asp:TableHeaderRow CssClass="th">
                                <asp:TableHeaderCell>Non Charge</asp:TableHeaderCell>
                                <asp:TableHeaderCell>NC Code</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Not Appliciple</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Hours</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Non Charge Comment</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                        </asp:Table>
                   </div>     
                               
                </div>
        </div>
        <div id="FooterRap">
            <div id="Footer1">

                <button id="btnDone" class="btnsubmit" style="float:left;">Done</button>

            </div>
            <div id="Footer2">

                <button runat="server" id="btnBackVS" class="btncancel" style=" float:right;" onserverclick="btnBackVSClick">Back</button>


            </div>
        </div>
    </div>
    </form>
</body>
</html>
