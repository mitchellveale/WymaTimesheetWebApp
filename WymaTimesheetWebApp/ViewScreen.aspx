<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewScreen.aspx.cs" Inherits="WymaTimesheetWebApp.ViewScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>View Timesheet</title>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
    <script src="https://cdn.jsdelivr.net/npm/signature_pad@2.3.2/dist/signature_pad.min.js"></script>
    
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
                        <asp:label runat="server" ID="viewJALabel" CssClass="Text" Text="Jobs and Assemblies:"/>
                        <asp:GridView runat="server" ID="JobsAssembliesViewGrid" CssClass="Text" HeaderStyle-BorderWidth="2px"></asp:GridView>

                       <asp:label runat="server" id="viewNCLabel" CssClass="Text" Text="Non-Charge Hours:"/>
                       <asp:GridView runat="server" ID="NonChargeViewGrid" CssClass="Text" HeaderStyle-BorderWidth="2px"></asp:GridView>
                        
                   </div>  
                    <br/>
                   <div id="Sign-ManagerSelection">
                       <label class="Text">Select Manager For Review:</label>
                       <asp:DropDownList runat="server" ></asp:DropDownList>
                       <br/>
                       <label class="Text">Sign Here:</label>
                       <br/>
                       <input runat="server" type="hidden" name="hiddenfield" id="hiddenfield" value="" />
   
                       <canvas runat="server" id="sigPad" style="border: thin solid #000000; max-height:inherit; max-width:inherit;" ></canvas>
                       <script src="js/sig-pad.js"></script>
                       
                           </div>
                               
            
                    <div id="FooterRap">
                        <div id="Footer1">

                            <button runat="server" id="btnDone" class="btnsubmit" style="float:left;" onclick="saveSig(); return"  onserverclick="btnDoneVSClick">Done</button>
                            <script src="js/sig-pad.js"></script>
                        </div>
                        <div id="Footer2">

                            <button runat="server" id="btnBackVS" class="btncancel" style=" float:right;" onserverclick="btnBackVSClick">Back</button>

                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
