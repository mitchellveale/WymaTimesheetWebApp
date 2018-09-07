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
                                    <label id="NameView" class="Text">Name:</label>
                                    <asp:label runat="server" ID="NameViewLabel" CssClass="Text" Text="TEST"></asp:label>
                                </p>

                                <p>
                                    <label id="DateView" class="Text">Date: </label>
                                    <asp:label runat="server" ID="DateViewLabel" CssClass="Text" Text="TEST"></asp:label>
                                </p>

                                <p>
                                    <label id="TotalHoursView" class="Text">Total Hours Worked: </label>
                                    <asp:label runat="server" ID="TotalHoursLabel" CssClass="Text" Text="TEST"></asp:label>
                                </p>

                            </div>
                    </div>
                </div>
                    
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
       
            <div id="Footer2">

                <button runat="server" id="btnCancelDT" class="btncancel" style=" float:right;" onserverclick="btnMVBack">Back</button>

            </div>
        </div>
    </div>
    </form>
</body>
</html>
