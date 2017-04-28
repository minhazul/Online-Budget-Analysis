﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecoverPasswordUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.RecoverPasswordUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <title>Recover Password</title>
</head>
<body style="background: url(../images/background.gif)">
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
                        <input type="text" class="form-control" id="txtUserName" placeholder="Enter your username" runat="server"/>
                    </div>
                  </div>             
                  <div class="form-group">
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="txtEmail" placeholder="Enter your email" runat="server"/>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-10">
                        <div class="col-sm-3">
                            <asp:Button ID="btnRecoverPass" runat="server" CssClass="btn btn-default" Text="Submit" OnClick="btnRecoverPass_Click" />
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
    
</body>
</html>
