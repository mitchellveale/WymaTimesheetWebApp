<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Job-AssSelection.aspx.cs" Inherits="WymaTimesheetWebApp.Job_AssSelection" %>


<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Job/Assembly Selction</title>
    <link rel="icon" type="image/png" href="Images/favicon.png"/>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
    <link rel="stylesheet" href="CSS/jquery-ui.min.css" type="text/css" />
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/jquery-ui.min.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        $(function () {
            $('#<%= OrderNumberInput.ClientID %>').autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "OrderNumService.asmx/GetOrderNumbers",
                        data: "{ \"inputData\": \"" + request.term + "\" }",
                        type: "POST",
                        dataType: "json",
                        contentType: "application/json;charset=utf-8",
                        success: function (result) {
                            response(result.d);
                        },
                        error: function (result) {
                            alert('An error has occured with the database, please try again later. If this probalem persists, please contact your network administrator');
                        }
                    });
                },
                minLength: 0
            });
        });
    </script>
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
                          

                            <div class="ezydisplay">
                                <label id="Number" class="Text">Number: </label>
                                <asp:TextBox ID="OrderNumberInput" CssClass="Text" OnTextChanged="OrderNumberUpdate" AutoPostBack="true" runat="server" Font-Size="X-Large" width="250px" Height="75px"></asp:TextBox>
                            </div>

                            <div class="ezydisplay" >
                                <label id="Step/Task" class="Text">Step/Task:</label>
                                <asp:DropDownList runat="server" Font-Size="X-Large" width="250px" Height="75px" ID="StepTaskData" CssClass="Text Dropdown" Enabled="False" ></asp:DropDownList>
                            </div>
                            <p></p>
                            <div class="ezydisplay">
                                <label id="CHHours:Mins" class="Text">Hours & Mins:</label>
                                <asp:DropDownList runat="server" Font-Size="X-Large" width="250px" Height="75px" ID="CHHoursHSelection" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">h</label><asp:DropDownList runat="server" ID="CHHoursMSelection" Font-Size="X-Large"  width="250px" Height="75px" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">m</label>
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
                               <button runat="server" id="CHTableAdd"  class="btn3" style="margin:25px"  onserverclick="BtnCHTableADDClick">ADD</button>
                           </div>
                       
                       </div>
                </div>                    
                    
                <div id="TopData2" style="margin: 25px;">
                    <div style="display:table; width:100%; height:auto;" >
                        <div style="display:table-cell; vertical-align:middle; width:100%; height:100%;">
                            <asp:GridView ID="DataCHView" OnRowCommand="DataCHView_RowCommand" runat="server" CssClass="Text" HeaderStyle-BorderWidth="2px">
                                <Columns>
                                    <asp:TemplateField HeaderText="Remove Row">
                                        <ItemTemplate>
                                            <asp:Button ID="CHRemoveBtn" Text="Remove" runat="server" CssClass="Text" Font-Size="X-Large" Height="100px" Width="200px"  CommandName="RemoveRow" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>     


                    <div id="BottomData" style="text-align:center" class="border">
                        <div id="NCSelection" style="text-align:center" >
                           <p style="text-align:center"> <label class="Text" >Select your Non-Charge Hours</label> </p>
                          
                                
                            <div class="ezydisplay">
                                <label id="NCCode" class="Text">NC Code:</label>
                                <asp:DropDownList runat="server" Font-Size="X-Large"  width="250px" Height="75px" ID="NCCodeData" CssClass="Text Dropdown" ></asp:DropDownList>
                            </div>
                               <p></p>
                            <div class="ezydisplay">
                                <label id="NCHours:Mins" class="Text">Hours & Mins:</label>
                                <asp:DropDownList runat="server" Font-Size="X-Large"  width="250px" Height="75px" ID="NCHoursHSelection" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">h</label><asp:DropDownList runat="server" ID="NCHoursMSelection"  Font-Size="X-Large" width="250px" Height="75px" CssClass="Text Dropdown"></asp:DropDownList><label class="Text">m</label>
                            </div>
                            <div>
                                <p></p>
                                <label id="NCComment" class="Text">Non-Charge Comment</label>
                                <div>
                                    <asp:TextBox runat="server" Font-Size="Large"  TextMode="MultiLine"  ID="NCCommentBox" CssClass="Text commentbox"></asp:TextBox>
                                </div>
                            </div>
                      
                       
                           <div style="text-align:center">
                               <button runat="server" id="NCTableADD" class="btn3" style="margin:25px" onserverclick="BtnNCTableADDClick">ADD</button>
                           </div>
                       
                       </div>
                    </div>

                    <div id="BottomData2" style="margin: 25px">
                        <div style="display:table; width:100%; height:auto" >
                            <div style="display: table-cell; vertical-align:middle; width:100%; height:100%">
                                <asp:GridView ID="DataNCView" OnRowCommand="DataNCView_RowCommand" runat="server" CssClass="Text" >
                                        <Columns>
                                        <asp:TemplateField HeaderText="Remove Row">
                                            <ItemTemplate>
                                                <asp:Button ID="NHRemoveBtn" Text="Remove" runat="server" CssClass="Text" Font-Size="X-Large" Height="100px" Width="200px" CommandName="RemoveRow" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />
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

            <button runat="server" id="btnSubmitHS" class="btnsubmit" style="float:left;" onserverclick="BtnSubmitHSClick" >Submit</button>

        </div>
        <div id="Footer2">

            <button runat="server" id="btnBackHS" class="btncancel" style=" float:right;" onserverclick="BtnBackHSClick">Back</button>


        </div>
    </div>
</form>

</body>
</html>