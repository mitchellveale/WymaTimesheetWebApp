<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManagerLogin.aspx.cs" Inherits="WymaTimesheetWebApp.ManagerLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manager Login</title>
    <link rel="icon" type="image/png" href="Images/favicon.png"/>
     <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
</head>
<body>
    <form runat="server">
        <div id="Outerrap">
            <!-- This Header contains the wyma logo -->
            <div id="HeaderRap">
                <div id="Header">
                    <img id="WymaLogo" src="Images/wyma-logo.svg" style="height: 76px; width: 295px; margin-bottom: 0px; margin-top: 0px;"/>

                    <div id="HeaderLabel" class="Text" >
                        <label  draggable="false">Manager Login</label>
                    </div>

                </div>
            </div>
        
                <!-- This contains two buttons. One for Employees and One for Managers -->
                <div id="Main" >
                    <div id="Data"> 
                        <label class="Text">Please input your four digit code:</label>
                        <input  runat="server" id="ManagerInput" type="number" class="labels Text" />
                    </div>
                </div>
            
        </div>
        <div id="FooterRap">
                <div id="Footer1">

                    <button runat="server" id="btnSubmitML" class="btnsubmit" style="float:left;" onserverclick="BtnSubmitMLClick">Submit</button>

                </div>
                <div id="Footer2">

                    <button runat="server" id="btnBackML" class="btncancel" style=" float:right;" onserverclick="BtnBackMLClick">Back</button>


                </div>
        </div>
    </form>
        

</body>
</html>
