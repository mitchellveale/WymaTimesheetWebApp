<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DateAndTime.aspx.cs" Inherits="WymaTimesheetWebApp.DateAndTime" %>

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

                            <label class="Text">Date:</label>
                            <input type="date" id="DateBox" class="Text labels" /> 

                            <label class="Text">Start Time:</label>
                            <input type="time" id="TimeStartINP" class="Text labels" />

                            <label class="Text">Lunch Break:</label>
                            <!-- <input type="time" id="LunchTimeINP" class="Text labels" /> -->
                            <!-- Time slection code by Dave Baldwin URL: https://www.experts-exchange.com/questions/28935729/HTML-input-field-to-enter-time-with-hours-minutes-and-am-pm.html -->
                            <select name="selMin" class="Text labels">
                                <option selected="selected" value="">Select Time</option>
                                <option value="00">00 mins</option>
                                <option value="01">01 min</option>
                                <option value="02">02 mins</option>
                                <option value="03">03 mins</option>
                                <option value="04">04 mins</option>
                                <option value="05">05 mins</option>
                                <option value="06">06 mins</option>
                                <option value="07">07 mins</option>
                                <option value="08">08 mins</option>
                                <option value="09">09 mins</option>
                                <option value="10">10 mins</option>
                                <option value="11">11 mins</option>
                                <option value="12">12 mins</option>
                                <option value="13">13 mins</option>
                                <option value="14">14 mins</option>
                                <option value="15">15 mins</option>
                                <option value="16">16 mins</option>
                                <option value="17">17 mins</option>
                                <option value="18">18 mins</option>
                                <option value="19">19 mins</option>
                                <option value="20">20 mins</option>
                                <option value="21">21 mins</option>
                                <option value="22">22 mins</option>
                                <option value="23">23 mins</option>
                                <option value="24">24 mins</option>
                                <option value="25">25 mins</option>
                                <option value="26">26 mins</option>
                                <option value="27">27 mins</option>
                                <option value="28">28 mins</option>
                                <option value="29">29 mins</option>
                                <option value="30">30 mins</option>
                                <option value="31">31 mins</option>
                                <option value="32">32 mins</option>
                                <option value="33">33 mins</option>
                                <option value="34">34 mins</option>
                                <option value="35">35 mins</option>
                                <option value="36">36 mins</option>
                                <option value="37">37 mins</option>
                                <option value="38">38 mins</option>
                                <option value="39">39 mins</option>
                                <option value="40">40 mins</option>
                                <option value="41">41 mins</option>
                                <option value="42">42 mins</option>
                                <option value="43">43 mins</option>
                                <option value="44">44 mins</option>
                                <option value="45">45 mins</option>
                                <option value="46">46 mins</option>
                                <option value="47">47 mins</option>
                                <option value="48">48 mins</option>
                                <option value="49">49 mins</option>
                                <option value="50">50 mins</option>
                                <option value="51">51 mins</option>
                                <option value="52">52 mins</option>
                                <option value="53">53 mins</option>
                                <option value="54">54 mins</option>
                                <option value="55">55 mins</option>
                                <option value="56">56 mins</option>
                                <option value="57">57 mins</option>
                                <option value="58">58 mins</option>
                                <option value="59">59 mins</option>
                            </select>

                            <label class="Text">End Time:</label>
                            <input type="time" id="TimeEndINP" class="Text labels" />

                            <label class="Text">Total Hours Worked:</label>
                            <label class="Text"></label></div>

                        
                               
                    </div>
                    
                </div>
        </div>
        <div id="FooterRap">
            <div id="Footer1">

                <button id="btnSubmit" class="btnsubmit" style="float:left;">Submit</button>

            </div>
            <div id="Footer2">

                <button id="btnCancel" class="btncancel" style=" float:right;">Cancel</button>


            </div>
        </div>
    </div>
    </form>

</body>
</html>
