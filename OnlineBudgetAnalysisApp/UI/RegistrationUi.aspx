﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationUi.aspx.cs" Inherits="OnlineBudgetAnalysisApp.RegistrationUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <title>Registration</title>
</head>
<body style="background: url(../images/background.gif)">
    <div class="container">
            <div class="page-header" style="color: white">
                <h2 style="text-align: center">Online Budget Analysis System</h2>
            </div>
        </div>
   <div class="container">
       <div id="registerbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
           <div class="panel panel-info">
               <div class="panel-heading">
                    <div class="panel-title">&nbsp;&nbsp;&nbsp;Register here</div>
                    <div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="LoginUI.aspx">Login</a></div>
               </div>
               
               <form id="form1" class="form-horizontal" style="padding: 20px" runat="server">
                   <div class="form-group">
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control" ID="userNameTextBox" Placeholder="Enter a username">
                        </asp:TextBox>
                    </div>
                  </div>
                   <div class="form-group">
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFullName" Placeholder="Enter your full name">
                        </asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" Placeholder="Enter your emailid">
                        </asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group">             
                    <div class="col-sm-10">
                        <asp:TextBox ID="passTextBox" CssClass="form-control" Placeholder="Enter a password" TextMode="Password" runat="server">                           
                        </asp:TextBox>
                    </div>
                  </div>
                   <div class="form-group">             
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control" ID="confirmPassTextBox" Placeholder="Please confirm your password" TextMode="Password">
                        </asp:TextBox>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-10">
                        <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-success" OnClick="btnRegistration_Click"/>
                    </div>
                  </div>
                   <div class="form-group">
                       <div class="col-sm-10">
                           <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                       </div>
                   </div>
                </form>

           </div>
       </div>
   </div> 

</body>
</html>