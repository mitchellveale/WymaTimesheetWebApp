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

         <div id="Main">
                <div id="Data"> 
                   <div id="TD_Info">
                    <p>
                        <label id="DateView" class="Text">Date: </label>
                        <asp:label runat="server" ID="DateViewLabel" CssClass="Text" Text="TEST"></asp:label>
                    </p>
                    <p>
                        <label id="TotalHoursView" class="Text">Total Hours Worked: </label>
                        <asp:label runat="server" ID="TotalHoursLabel" CssClass="Text" Text="TEST"></asp:label>
                    </p>
                    <p>
                        <label id="TotalHoursAppView" class="Text">Total Hours Applied: </label>
                        <asp:label runat="server" ID="TotalHoursAppLabel" CssClass="Text" Text="TEST"></asp:label>
                    </p>

                       
                   </div>
                   <asp:ScriptManager EnablePartialRendering="true" ID="ScriptManagerForTables" runat="server"></asp:ScriptManager>
                   <div id="TableSheet">
                        <label class="Text">Select your Jobs and Assemblies</label>
                        <asp:UpdatePanel ID="JAUpdate" runat="server">
                        <ContentTemplate>

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
                               <asp:TableCell ColumnSpan="8"><button runat="server" id="JATableADD"  class="btn3" style="margin:25px"  onserverclick="BtnJATableClick">ADD</button></asp:TableCell>
                           </asp:TableRow>
                        </asp:Table>

                        </ContentTemplate>
                        </asp:UpdatePanel>
                       
                        <label class="Text">Select your Non-Charge Hours</label>

                        <asp:UpdatePanel ID="NCUpdate" runat="server">
                        <ContentTemplate>

                        <asp:Table ID="NonChargeTable" runat="server" CssClass="Text table " Width="100%">
                            <asp:TableHeaderRow CssClass="th">
                                <asp:TableHeaderCell>Non Charge</asp:TableHeaderCell>
                                <asp:TableHeaderCell>NC Code</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Not Appliciple</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Hours</asp:TableHeaderCell>
                                <asp:TableHeaderCell>Non Charge Comment</asp:TableHeaderCell>
                            </asp:TableHeaderRow>
                           <asp:TableRow>
                               <asp:TableCell ColumnSpan="5"><button id="NCTableADD" class="btn3" style="margin:25px">ADD</button></asp:TableCell>
                           </asp:TableRow>
                        </asp:Table>

                        </ContentTemplate>
                        </asp:UpdatePanel>

                   </div>     
                               
                </div>
        </div>
        <div id="FooterRap">
            <div id="Footer1">

                <button runat="server" id="btnSubmitHS" class="btnsubmit" style="float:left;" onserverclick="BtnSubmitHSClick" >Submit</button>

            </div>
            <div id="Footer2">

                <button runat="server" id="btnBackHS" class="btncancel" style=" float:right;" onserverclick="BtnBackHSClick">Back</button>


            </div>
        </div>
    </div>
    </form>

</body>
</html>