<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job-AssSelection.aspx.cs" Inherits="WymaTimesheetWebApp.Job_AssSelection" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Job/Assembly Selction</title>
    <link rel="icon" type="image/png" href="Images/favicon.png"/>
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
                                <asp:DropDownList runat="server" ID="JobNumberData" CssClass="Text Dropdown" AutoPostBack="true" OnSelectedIndexChanged="OrderNumberUpdate" ></asp:DropDownList>
                            </div>

                            <div class="ezydisplay" >
                                <label id="Step/Task" class="Text">Step/Task:</label>
                                <asp:DropDownList runat="server" ID="StepTaskData" CssClass="Text Dropdown" Enabled="False" ></asp:DropDownList>
                            </div>
                            <div class="ezydisplay">
                                <label id="CHHours:Mins" class="Text">Hours & Mins:</label>
                                <asp:DropDownList runat="server" ID="CHHoursHSelection" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">h</label><asp:DropDownList runat="server" ID="CHHoursMSelection" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">m</label>
                            </div>
                           </div>
                       
                           <div>
          
                            <asp:Label runat="server" ID="JobAssyData" Visible="false" CssClass="Text"></asp:Label>
                       
                            <asp:Label runat="server" ID="WyEUrefData" Visible="false" CssClass="Text"></asp:Label>
                            
                            <asp:Label runat="server" ID="EUStepData" Visible="false" CssClass="Text"></asp:Label>
                            
                            <asp:Label runat="server" ID="EUCustData" Visible="false" CssClass="Text"></asp:Label>

                            <label id="Customer" class="Text">Customer:</label>
                            <asp:Label runat="server" ID="CustData" CssClass="Text"></asp:Label>
                           </div>
                           <div style="text-align:center">
                               <button runat="server" id="CHTableAdd"  class="btn3" style="margin:25px"  onserverclick="BtnCHTableADDClick">ADD</button>
                           </div>
                       
                       </div>
                </div>
                   
                    
                    
                   <div id="BottomData2" style="margin: 25px;">
                       <div style="display:table; width:100%; height:auto;" >
                            <div style="display:table-cell; vertical-align:middle; width:100%; height:100%;">
                                <asp:GridView ID="DataCHView" OnRowCommand="DataCHView_RowCommand" runat="server" CssClass="Text" HeaderStyle-BorderWidth="2px">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Remove Row">
                                            <ItemTemplate>
                                                <asp:Button ID="CHRemoveBtn" Text="Remove" runat="server"  CommandName="RemoveRow" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                       </div>
                   </div>     
                       

                        
                        
                        
                       
                    <div id="BottomData" style="text-align:center">
                        <div id="NCSelection" class="border">
                           <p style="text-align:center"> <label class="Text" >Select your Non-Charge Hours</label> </p>
                           <div>

                            <div class="ezydisplay">
                                <label id="NCCode" class="Text">NC Code:</label>
                                <asp:DropDownList runat="server" ID="NCCodeData" CssClass="Text Dropdown" ></asp:DropDownList>
                            </div>

                            <div class="ezydisplay">
                                <label id="NCHours:Mins" class="Text">Hours & Mins:</label>
                                <asp:DropDownList runat="server" ID="NCHoursHSelection" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">h</label><asp:DropDownList runat="server" ID="NCHoursMSelection" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">m</label>
                            </div>
                            <div>
                                <label id="NCComment" class="Text">Non-Charge Comment</label>
                                <div>
                                    <asp:TextBox runat="server" TextMode="MultiLine"  ID="NCCommentBox" CssClass="Text commentbox"></asp:TextBox>
                                </div>
                            </div>
                           </div>
                       
                           <div style="text-align:center">
                               <button runat="server" id="NCTableADD" class="btn3" style="margin:25px" onserverclick="BtnNCTableADDClick">ADD</button>
                           </div>
                       
                       </div>

                       <div id="TopData2" style="margin: 25px">
                            <div style="display:table; width:100%; height:auto" >
                                <div style="display: table-cell; vertical-align:middle; width:100%; height:100%">
                                    <asp:GridView ID="DataNCView" OnRowCommand="DataNCView_RowCommand" runat="server" CssClass="Text" >
                                         <Columns>
                                            <asp:TemplateField HeaderText="Remove Row">
                                                <ItemTemplate>
                                                    <asp:Button ID="NHRemoveBtn" Text="Remove" runat="server"  CommandName="RemoveRow" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
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
                               
    </div>
     
    <div id="FooterRap">
        <div id="Footer1">

            <button runat="server" id="btnSubmitHS" class="btnsubmit" style="float:left;" onserverclick="BtnSubmitHSClick" >Submit</button>

        </div>
        <div id="Footer2">

            <button runat="server" id="btnBackHS" class="btncancel" style=" float:right;" onserverclick="BtnBackHSClick">Back</button>


        </div>
    </div>
</form>

</body>
</html>