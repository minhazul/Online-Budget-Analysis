﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPasswordUI.aspx.cs" UnobtrusiveValidationMode="none" Inherits="OnlineBudgetAnalysisApp.RecoverPasswordUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    
    <title>Recover Password</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../Content/responsive.css" rel="stylesheet" />
</head>
<body style="background: url(../pictures/background.gif)">
        <div class="container">
            <div class="page-header" style="color: white">
                <h2 style="text-align: center">Online Budget Analysis System</h2>
            </div>
        </div>
<div class="container">
    <div id="PasswordRecoveryBox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
        <div class="panel panel-info">
            <div class="panel-heading">
                    <div class="panel-title">&nbsp;&nbsp;&nbsp;Recover Password</div>
               </div>
            
            <form id="form1" class="form-horizontal" style="padding: 20px" runat="server">
                   <div class="form-group">
                    <div class="col-sm-10">                       
                        <input type="text" class="form-control" id="txtUserName" pattern=".{4,15}" required="" title="username should be 4 to 15 characters long" placeholder="Enter your username" runat="server"/>
                    </div>
                  </div>             
                  <div class="form-group">
                    <div class="col-sm-10">
                        <input type="email" class="form-control" required="" id="txtEmail" placeholder="Enter your email" runat="server"/>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ToolTip="" Display="Dynamic" ForeColor="red"></asp:RegularExpressionValidator>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-10">
                        <div class="col-sm-3">
                            <asp:Button ID="btnRecoverPass" runat="server" CssClass="btn btn-success" Text="Submit" OnClick="btnRecoverPass_Click" />
                        </div>
                      <div class="col-sm-7">
                          <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                      </div>
                    </div>
                  </div>
                </form>
        </div>
    </div>
</div>
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
</body>
</html>
