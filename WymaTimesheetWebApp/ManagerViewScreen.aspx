<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerViewScreen.aspx.cs" Inherits="WymaTimesheetWebApp.ManagerViewScreen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Managers View</title>
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
                                    <label class="Text">Manager Name:</label>
                                    <label runat="server" id="ManagerName" class="Text"></label>
                                </p>
                                <div runat="server" id="empinfo" visible="false">
                                    <p>
                                        <asp:Label runat="server" ID="NameViewLabel" CssClass="Text" Text="Employee Name:"></asp:Label>
                                    </p>

                                    <p>
                                        <asp:Label runat="server" ID="DateViewLabel"  CssClass="Text" Text="Date Submited:"></asp:Label>
                                    </p>

                                    <p>
                                        <asp:Label runat="server" ID="TotalHoursLabel"  CssClass="Text" Text="Total Hours Worked:"></asp:Label>
                                    </p>
                                </div>
                            </div>
                    </div>
                    
                </div>
                    <br/>
                    <div id="FileList">
                        <asp:GridView ID="ManagerView" runat="server" OnRowCommand="viewTimeSheet_RowCommand" CssClass="Text" HeaderStyle-BorderWidth="2px" >
                            <Columns>
                                <asp:TemplateField HeaderText="View Timesheet">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="viewBtn" Text="View" CssClass="Text" Font-Size="X-Large" Height="100px" Width="200px" CommandName="ViewTimeSheet" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            
                    </div>
                     <div id="SignPad">
                       <asp:label runat="server" ID="signLabel" Visible="false" CssClass="Text" Text="Sign Here:" ></asp:label>
                       <br/>
                       <input runat="server" type="hidden" name="hiddenfield" id="hiddenfield" value="" />
   
                       <canvas runat="server" visible="false" id="sigPad" style="border: thin solid #000000; max-height:inherit; max-width:inherit;"></canvas>
                       <script src="js/sig-pad.js"></script>
                         <!-- when this is used it will have a 'src' value applied to it -->
                       <img id="SigImg" src="" alt="Image Not Found" style="border: thin solid #000000; max-height:inherit; max-width:inherit;" runat="server" visible="false" />
                       <br/>
                       <button runat="server" visible="false" id="clearBtn" onclick="clearSig();" >Clear</button>
                       <script src="js/sig-pad.js"></script>
                       <asp:Button ID="imgbtn" runat="server" Text="Clear" Visible="false" OnClick="imgbtn_Click" />
                    </div>
        </div>
                </div>
            
        <div id="FooterRap">
            <div id="Footer1">

                    <button runat="server" id="btnAccept1MV" class="btnsubmit" visible="false"  onserverclick="BtnAcceptMVClick">Accept</button>
                    <button runat="server" id="btnAccept2MV" class="btnsubmit" visible="false" onclick="saveSig(); return"  onserverclick="BtnAcceptMVClick">Accept</button>
                    <script src="js/sig-pad.js"></script>
            </div>
            <div id="Footer2">

                    <button runat="server" id="btnUpdateMV" class="btnsubmit" visible="false"  onserverclick="BtnUpdateMVClick">Update</button>
                    
            </div>
            <div id="Footer3">

                <button runat="server" id="btnCancelMV" class="btncancel"  onserverclick="btnMVBack">Back</button>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
