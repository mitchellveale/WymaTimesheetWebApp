<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewScreen.aspx.cs" Inherits="WymaTimesheetWebApp.ViewScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Timesheet</title>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
</head>
<body>
    <form id="VS" runat="server">
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
                   <div style="text-align:center">
                   <div id="TD_Info">
                    <p>
                        <label id="EmployeeName" class="Text">Employee Name</label>
                    </p>
                        <asp:label runat="server" ID="EmployeeNameData" CssClass="Text" Text="TEST"></asp:label>
                    
                    <p>
                        <label id="TimeWorked" class="Text">Time Worked Between</label>
                    </p>
                        <asp:label runat="server" ID="TimeWorkedData" CssClass="Text" Text="TEST"></asp:label>
                   
                    <p>
                        <label id="BreakTime" class="Text">Break Time: </label>
                        <asp:label runat="server" ID="BreakTimeData" CssClass="Text" Text="TEST"></asp:label>
                    </p>
                    <p>
                        <label id="TotalTimeWorked" class="Text">Total Time Worked: </label>
                        <asp:label runat="server" ID="TotalTimeWorkedData" CssClass="Text" Text="TEST"></asp:label>
                    </p>
                   </div>
                       
                   </div>
                   <div id="TableSheet">
                        <label class="Text">Jobs and Assemblies:</label>
                        <asp:GridView runat="server" ID="JobsAssembliesViewGrid" CssClass="Text" HeaderStyle-BorderWidth="2px"></asp:GridView>

                       <label class="Text">Non-Charge Hours:</label>
                       <asp:GridView runat="server" ID="NonChargeViewGrid" CssClass="Text" HeaderStyle-BorderWidth="2px"></asp:GridView>
                        
                   </div>     
                               
                </div>
        </div>
        <div id="FooterRap">
            <div id="Footer1">

                <button runat="server" id="btnDone" class="btnsubmit" style="float:left;" onserverclick="btnDoneVSClick">Done</button>

            </div>
            <div id="Footer2">

                <button runat="server" id="btnBackVS" class="btncancel" style=" float:right;" onserverclick="btnBackVSClick">Back</button>


            </div>
        </div>
    </div>
    </form>
</body>
</html>
