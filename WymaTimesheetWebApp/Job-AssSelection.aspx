<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job-AssSelection.aspx.cs" Inherits="WymaTimesheetWebApp.Job_AssSelection" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Job/Assembly Selction</title>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
</head>
<body>
    <form id="JA" runat="server">
    <div id="Outerrap">
        <!-- This Header contains the wyma logo -->
        <div id="HeaderRap">
            <div id="Header">
                <img id="WymaLogo" src="Images/wyma-logo.svg" style="height: 76px; width: 295px; margin-bottom: 0px; margin-top: 0px;"/>

                <div id="HeaderLabel" class="Text" >
                    <label  draggable="false">Hours Selection</label>
                </div>

            </div>
        </div>

         <div id="Main" >
                <div id="Data"> 
                   <div id="TD_Info">
                    <p>
                        <label id="DateView" class="Text">Date: </label>
                        <label id="DateView Data" class="Text">TEST</label>
                    </p>
                    <p>
                        <label id="TotalHoursView" class="Text">Total Hours Worked: </label>
                        <label id="TotalHoursData" class="Text">TEST</label>
                    </p>
                    <p>
                        <label id="TotalHoursAppView" class="Text">Total Hours Applied: </label>
                        <label id="TotalHoursAppData"class="Text">TEST</label>
                    </p>

                       
                   </div>
                   <div id="TableSheet">
                        <label class="Text">Select your Jobs and Assemblies</label>
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

                           
                        </asp:Table>
                        <label class="Text">Select your Non-Charge Hours</label>
                        <asp:Table ID="NonChargeTable" runat="server" CssClass="Text table " Width="100%">
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

                <button id="btnSubmit" class="btnsubmit" style="float:left;">Submit</button>

            </div>
            <div id="Footer2">

                <button id="btnCancel" class="btncancel" style=" float:right;">Cancel</button>


            </div>
        </div>
    </div>
    </form>

</body>
</html>