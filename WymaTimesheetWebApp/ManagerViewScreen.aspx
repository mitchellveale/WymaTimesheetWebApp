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
                   <div id="TopData" class="border" >
                       <div style="text-align:center; margin-bottom:25px;">
                            <div id="TD_Info" >
                                <p>
                                    <label class="Text">Manager Name:</label>
                                    <label runat="server" id="ManagerName" class="Text"></label>
                                </p>
                                <p>
                                    <asp:label runat="server" ID="NameViewLabel" Visible="false" CssClass="Text" Text="Employee Name:"></asp:label>
                                </p>

                                <p>
                                    <asp:label runat="server" ID="DateViewLabel" Visible="false" CssClass="Text" Text="Date Submited:"></asp:label>
                                </p>

                                <p>
                                    <asp:label runat="server" ID="TotalHoursLabel" Visible="false" CssClass="Text" Text="Total Hours Worked:"></asp:label>
                                </p>

                            </div>
                    </div>
                    
                </div>
                    <br/>
                    <div id="FileList">
                        <asp:GridView ID="ManagerView" runat="server" OnRowCommand="viewTimeSheet_RowCommand" CssClass="Text" HeaderStyle-BorderWidth="2px" >
                            <Columns>
                                <asp:TemplateField HeaderText="View Timesheet">
                                    <ItemTemplate>
                                        <asp:Button runat="server" ID="viewBtn" Text="View" CommandName="ViewTimeSheet" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                            
                    </div>
                </div>
        </div>
        <div id="FooterRap">
            <div id="Footer1">

                    <button runat="server" id="btnUpdateMV" class="btnsubmit" visible="false"  onserverclick="BtnUpdateMVClick">Accept</button>
            </div>
            <div id="Footer2">

                    <button runat="server" id="btnAcceptMV" class="btnsubmit" visible="false" onserverclick="BtnAcceptMVClick">Update</button>

            </div>
            <div id="Footer3">

                <button runat="server" id="btnCancelMV" class="btncancel"  onserverclick="btnMVBack">Back</button>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
