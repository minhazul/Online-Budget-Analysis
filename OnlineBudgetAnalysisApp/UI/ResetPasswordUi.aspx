<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPasswordUi.aspx.cs" UnobtrusiveValidationMode="none" Inherits="OnlineBudgetAnalysisApp.ResetPasswordUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8"/>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <title>Reset Password</title>
    
    <style>
        label.error {
            color: red;
            font-weight: lighter;
            font-style: italic
        }
    </style>
</head>
<body style="background: url(../pictures/background.gif)">
<div class="container">
            <div class="page-header" style="color: white">
                <h2 style="text-align: center">Online Budget Analysis System</h2>
            </div>
        </div>
<div class="container">
    <div id="PasswordResetBox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
        <div class="panel panel-info">
            <div class="panel-heading">
               <div class="panel-title">&nbsp;&nbsp;&nbsp;Reset Password</div>
            </div>

            <form id="form1" class="form-horizontal" style="padding: 20px" runat="server">
                <div class="form-group">
                    <div class="col-sm-10">                       
                        <input type="password" class="form-control" id="txtPassword" name="txtPassword" placeholder="Enter new password" runat="server"/>
                    </div>
                  </div>             
                  <div class="form-group">
                    <div class="col-sm-10">
                        <input type="password" class="form-control" id="txtConfirmPassword" name="txtConfirmPassword" placeholder="Confirm password" runat="server"/>
                        <%--<asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="txtConfirmPassword"
                        CssClass="ValidationError"
                        ControlToCompare="txtPassword"
                        ErrorMessage="Password must be the same" 
                        ToolTip="Password must be the same" Display="Dynamic" ForeColor="red"/>--%>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-10">
                        <div class="col-sm-3">
                            <asp:Button ID="btnResetPass" runat="server" CssClass="btn btn-danger" Text="Reset" OnClick="btnResetPass_Click"/>
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
    <script src="../Scripts/jquery.validate.min.js"></script>
    <script>
        $(Document).ready(function() {
            $("#form1").validate({
                rules: {
                    
                    txtPassword: {
                        required: true,
                        minlength: 6
                    },
                    txtConfirmPassword: {
                        required: true,
                        minlength: 6,
                        equalTo: "#txtPassword"
                    }
                    
                },
                messages: {
                    
                    txtPassword: {
                        required: "Please enter a new password",
                        minlength: "Your password must be at least 6 characters long"
                    },
                    txtConfirmPassword: {
                        required: "Please confirm password",
                        minlength: "Your password must be at least 6 characters long",
                        equalTo: "Please enter the same password as above"
                    }
                    
                }
            });
        });
    </script>
</body>
</html>
