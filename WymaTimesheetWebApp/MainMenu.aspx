<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="WymaTimesheetWebApp.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
    <link rel="stylesheet" type="text/css" href="CSS/Wyma_Webapp_SS.css" />
</head>
<body id="Body">
    <div id="Outerrap">
        <!-- This Header contains the wyma logo -->
        <div id="HeaderRap">
            <div id="Header">
                <img id="WymaLogo" src="Images/wyma-logo.svg" style="height: 76px; width: 295px; margin-bottom: 0px; margin-top: 0px;"/>

                <div id="HeaderLabel" class="Text" >
                    <label  draggable="false">Wyma Timesheet Program</label>
                </div>

            </div>
        </div>
        
            <!-- This contains two buttons. One for Employees and One for Managers -->
            <form runat="server" id="Main" >
                <div id="Data"> 
                    <div id="Buttons" style=" padding: 100px; margin: inherit; position: center; width: 147px;">
<<<<<<< HEAD
                        <button runat="server" id="Button_Employee" onclick="Button_Employee_Click" class="btn3">Employees</button>
                        <br /> 
                        <br />
                        <button id="Button_Manager" onclick="Button_Manager_Click" class="btn3">Managers</button>
=======
                        <button runat="server" id="ButtonEmployee" class="btn3" onserverclick="ButtonEmployeeClick" >Employees</button>
                        <br /> 
                        <br />
                        <button runat="server" id="ButtonManager" class="btn3" onserverclick="ButtonManagerClick" >Managers</button>
>>>>>>> Main-Menu
                    </div>
                </div>
            </form>
            
    </div>
        

  
</body>
</html>
