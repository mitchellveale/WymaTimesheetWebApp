<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerUpdate.aspx.cs" Inherits="WymaTimesheetWebApp.ManagerUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Timesheet Update</title>
    <link rel="icon" type="image/png" href="Images/favicon.png"/>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
    <script src="https://cdn.jsdelivr.net/npm/signature_pad@2.3.2/dist/signature_pad.min.js"></script>
    
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
                   <div>
                       <div style="text-align:center; margin-bottom:25px; " class="border">
                            <div id="TD_Info" >
                                <p>
                                    <label class="Text">Manager Name: </label>
                                    <label runat="server" id="ManagerName" class="Text"></label>
                                </p>
                                <p>
                                    <asp:label runat="server" ID="NameViewLabel" CssClass="Text" Text="Employee Name:"></asp:label>
                                </p>

                                <p>
                                    <asp:label runat="server" ID="DateViewLabel"  CssClass="Text" Text="Date Submited:"></asp:label>
                                </p>

                                <p>
                                    <asp:label runat="server" ID="TotalHoursLabel"  CssClass="Text" Text="Total Hours Worked:"></asp:label>
                                </p>
                                <p>
                                    <asp:label runat="server" ID="TotalAppLabel"  CssClass="Text" Text="Total Hours Applied:"></asp:label>
                                </p>

                            </div>
                    </div>
                    
                </div>
                    <div runat="server" id="UpdateSelection" visible="false">
                           <p style="text-align:center"> <label class="Text" >Edit Jobs and Assemblies</label> </p>
                          

                            <div class="ezydisplay">
                                <label id="Number" class="Text">Number: </label>
                                <asp:DropDownList Font-Size="X-Large" runat="server" width="250px" Height="75px" ID="JobNumberData" CssClass="Text Dropdown" AutoPostBack="true" OnSelectedIndexChanged="OrderNumberUpdate"></asp:DropDownList>
                            </div>

                            <div class="ezydisplay" >
                                <label id="Step/Task" class="Text">Step/Task:</label>
                                <asp:DropDownList runat="server" Font-Size="X-Large" width="250px" Height="75px" ID="StepTaskData" CssClass="Text Dropdown"></asp:DropDownList>
                            </div>
                           
                       
                           <div>
                            <p></p>
                            <asp:Label runat="server" ID="JobAssyData" Visible="false" CssClass="Text"></asp:Label>
                       
                            <asp:Label runat="server" ID="WyEUrefData" Visible="false" CssClass="Text"></asp:Label>
                            
                            <asp:Label runat="server" ID="EUStepData" Visible="false" CssClass="Text"></asp:Label>
                            
                            <asp:Label runat="server" ID="EUCustData" Visible="false" CssClass="Text"></asp:Label>

                            <label id="Customer" class="Text">Customer:</label>
                            <asp:Label runat="server" ID="CustData" CssClass="Text"></asp:Label>
                           </div>
                           <div style="text-align:center">
                               <button runat="server" id="EditTable"  class="btn3" style="margin:25px" onserverclick="BtnEdit">Make Changes</button>
                           </div>
                       
                       </div>
                    <br/>
                    <div id="FileList">
                        <asp:GridView ID="UpdateView" runat="server" OnRowCommand="EditRow_RowCommand" CssClass="Text" HeaderStyle-BorderWidth="2px" >
                            <Columns>
                                <asp:TemplateField HeaderText="Edit Row">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="viewBtn" Text="Edit" CssClass="Text" Font-Size="X-Large" Height="100px" Width="200px" CommandName="EditTimeSheet" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            
                    </div>
                    <div id="SignPad">
                        <asp:Label runat="server" ID="signLabel" Visible="false" CssClass="Text" Text="Sign Here:"></asp:Label>
                        <br />
                        <input runat="server" type="hidden" name="hiddenfield" id="hiddenfield" value="" />

                        <canvas runat="server" visible="false" id="sigPad" style="border: thin solid #000000; max-height: inherit; max-width: inherit;"></canvas>
                        <script src="js/sig-pad.js"></script>

                        <br />
                        <button runat="server" visible="false" id="clearBtn" onclick="clearSig();">Clear</button>
                        <script src="js/sig-pad.js"></script>
                    </div>
                </div>
        </div>
            
        <div id="FooterRap">
            <div id="Footer1">

                    <button runat="server" id="btnAcceptMU" class="btnsubmit" visible="false" onserverclick="BtnAcceptMU">Done</button>
            </div>
            <div id="Footer2">

                <button runat="server" id="btnBackMU" class="btncancel"  onserverclick="BtnBackMU">Cancel</button>

            </div>
        </div>
    </div>
    </form>
</body>
</html>