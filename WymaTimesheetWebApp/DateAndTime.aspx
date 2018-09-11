<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateAndTime.aspx.cs" Inherits="WymaTimesheetWebApp.DateAndTime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Set Date and Time</title>
    <link rel="icon" type="image/png" href="Images/favicon.png"/>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
    <style type="text/css">
        #Select1 {
            width: 233px;
        }
    </style>
</head>
<body>
    <form id="DT" runat="server">
    <div id="Outerrap">
        <!-- This Header contains the wyma logo -->
        <div id="HeaderRap">
            <div id="Header">
                <img id="WymaLogo" src="Images/wyma-logo.svg" style="height: 76px; width: 295px; margin-bottom: 0px; margin-top: 0px;"/>

                <div id="HeaderLabel" class="Text" >
                    <label  draggable="false">Date and Time Settings</label>
                </div>

            </div>
        </div>

         <div id="Main" >
                <div id="Data"> 
                    <div id="Form">
                        <div style="width: auto; height: auto;" >


                            <asp:label runat="server" ID="NameLable" CssClass="Text" Text="Name: "/>
                            <asp:DropDownList ID="NamePicker" runat="server" Font-Size="X-Large" CssClass="Text labels"  AutoPostBack="true" OnSelectedIndexChanged="TextChanged" ></asp:DropDownList>
                            
                            <asp:label runat="server" ID="DateLabel" CssClass="Text" Text="Date:" /> <!-- Date/Time -->
                            <asp:TextBox runat="server" TextMode="Date" ID="DateBox" Font-Size="X-Large" CssClass="Text labels" width="200px" Height="75px"  OnTextChanged="TextChanged" ></asp:TextBox>

                            <asp:label runat="server" ID="StartLabel" CssClass="Text" Text="Start Time:"/>
                            <asp:textbox runat="server" TextMode="Time" ID="TimeStartINP" Font-Size="X-Large"  CssClass="Text labels" width="200px" Height="75px"  OnTextChanged="TextChanged" /> <!-- Date/Time -->

                            <asp:label runat="server" ID="LunchTLabel" CssClass="Text" Text="Lunch Break Length:"/>
                            <asp:DropDownList ID="SelMin" runat="server" CssClass="Text labels" Font-Size="X-Large" width="200px" Height="75px"  OnSelectedIndexChanged="TextChanged" ></asp:DropDownList> 

                            <asp:label runat="server" ID="EndLabel" CssClass="Text" Text="End Time:"/>
                            <asp:textbox runat="server" TextMode="Time" ID="TimeEndINP" Font-Size="X-Large" CssClass="Text labels" width="200px" Height="75px"  OnTextChanged="TextChanged" /> <!-- Date/Time -->


                        </div>

                        
                               
                    </div>
                    
                </div>
        </div>
        <div id="FooterRap">
            <div id="Footer1">

                <button runat="server" id="btnSubmitDT" class="btnsubmit" style="float:left;" onserverclick="BtnSubmitDTClick">Continue</button>

            </div>
            <div id="Footer2">

                <button runat="server" id="btnCancelDT" class="btncancel" style=" float:right;" onserverclick="BtnCancelDTClick">Cancel</button>


            </div>
        </div>
    </div>
    </form>

</body>
</html>
