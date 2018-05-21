﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateAndTime.aspx.cs" Inherits="WymaTimesheetWebApp.DateAndTime" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Set Date and Time</title>
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

                            <label class="Text">Name:</label>
                            <asp:DropDownList ID="NamePicker" runat="server" CssClass="Text labels" width="125px"></asp:DropDownList>

                            <label class="Text">Date:</label>
                            <input type="date" id="DateBox" class="Text labels" /> 

                            <label class="Text">Start Time:</label>
                            <input type="time" id="TimeStartINP" class="Text labels" />

                            <label class="Text">Lunch Break:</label>
                            <!-- <input type="time" id="LunchTimeINP" class="Text labels" /> -->
                            <!-- Time slection code by Dave Baldwin URL: https://www.experts-exchange.com/questions/28935729/HTML-input-field-to-enter-time-with-hours-minutes-and-am-pm.html -->
                            <asp:DropDownList ID="selMin" runat="server" CssClass="Text labels" width="125px"></asp:DropDownList>

                            <label class="Text">End Time:</label>
                            <input type="time" id="TimeEndINP" class="Text labels" />

                            <label class="Text">Total Hours Worked:</label>
                            <label class="Text"></label></div>

                        
                               
                    </div>
                    
                </div>
        </div>
        <div id="FooterRap">
            <div id="Footer1">

                <button runat="server" id="btnSubmitDT" class="btnsubmit" style="float:left;" onserverclick="BtnSubmitDTClick">Submit</button>

            </div>
            <div id="Footer2">

                <button runat="server" id="btnCancelDT" class="btncancel" style=" float:right;" onserverclick="BtnCancelDTClick">Cancel</button>


            </div>
        </div>
    </div>
    </form>

</body>
</html>