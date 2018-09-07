<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerFileUpdate.aspx.cs" Inherits="WymaTimesheetWebApp.ManagerFileUpdate" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Update File</title>
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
                    <label  draggable="false">Update File</label>
                </div>

            </div>
        </div>

            <div id="Main">
                <div id="Data"> 
                   <div id="TopData" class="border" >
                       <div style="text-align:center; margin-bottom:25px;">
                       <div id="TD_Info" >
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

                        <p>
                            <label id="TotalHoursAppView" class="Text">Total Hours Applied: </label>
                            <asp:label runat="server" ID="TotalHoursAppLabel" CssClass="Text" Text="TEST"></asp:label>
                        </p>

                       </div>
                       </div>
                       <div id="CHSelection">
                           <p style="text-align:center"> <label class="Text" >Select your Jobs and Assemblies</label> </p>
                           <div>

                            <div class="ezydisplay">
                                <label id="Number" class="Text">Number: </label>
                                <asp:DropDownList runat="server" ID="JobNumberData" Visible="false" CssClass="Text Dropdown" AutoPostBack="true" OnSelectedIndexChanged="OrderNumberUpdate" ></asp:DropDownList>
                            </div>

                            <div class="ezydisplay" >
                                <label id="Step/Task" class="Text">Step/Task:</label>
                                <asp:DropDownList runat="server" ID="StepTaskData" Visible="false" CssClass="Text Dropdown" Enabled="False" ></asp:DropDownList>
                            </div>
                            <div class="ezydisplay">
                                <label id="CHHours:Mins" class="Text">Hours & Mins:</label>
                                <asp:DropDownList runat="server" ID="UpdateHoursHSelection" Visible="false" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">h</label><asp:DropDownList runat="server" Visible="false" ID="UpdateHoursMSelection" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">m</label>
                            </div>
                           </div>
                       
                           <div style="text-align:center">
                               <button runat="server" id="TableUpdate"  class="btn3" style="margin:25px" onserverclick="BtnTableUpdateClick">Update</button>
                           </div>
                       
                       </div>
                </div>
                   
                    
                    
                   <div id="BottomData2" class="gridview">
                       <div style="display:table; width:100%; height:auto" >
                            <div style="display: table-cell; vertical-align:middle; width:100%; height:100%">
                                <asp:GridView ID="UpdateView" OnRowCommand="Update_RowCommand" runat="server" CssClass="Text" HeaderStyle-BorderWidth="2px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Edit Row">
                                            <ItemTemplate>
                                                <asp:Button ID="CHRemoveBtn" Text="Remove" runat="server"  CommandName="EditRow" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                       </div>
                   </div>     
                </div>
                </div>
       </div>
       
     
    <div id="FooterRap">
        <div id="Footer1">

            <button runat="server" id="btnSubmitMU" class="btnsubmit" style="float:left;" onserverclick="BtnDoneMUClick">Done</button>

        </div>
        <div id="Footer2">

            <button runat="server" id="btnBackMU" class="btncancel" style=" float:right;" onserverclick="BtnBackMUClick">Back</button>


        </div>
    </div>
</form>

</body>
</html>