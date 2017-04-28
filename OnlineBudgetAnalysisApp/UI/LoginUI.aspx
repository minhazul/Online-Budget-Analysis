<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.LoginUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <title>Login | Register here</title>
</head>
<body style="background: url(../images/background.gif)">
    <form id="loginform" class="form-horizontal" role="form" runat="server">
        <div class="container">
            <div class="page-header" style="color: white">
                <h2 style="text-align: center">Online Budget Analysis System</h2>
            </div>
        </div>
   <div class="container">
       <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
           <div class="panel panel-info">
               <div class="panel-heading">
                    <div class="panel-title">Sign In</div>
                    <div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="#">Forgot password?</a></div>
               </div>
               
               <div style="padding-top:30px" class="panel-body">
                   <div style="display:none" id="login-alert" class="alert alert-danger col-sm-12"></div>
                   
                   <div style="margin-bottom: 25px" class="input-group">
                   <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                       <input id="txtUsername" type="text" class="form-control" name="username" value="" placeholder="username" runat="server"/>                                        
                   </div>
                   
                   <div style="margin-bottom: 25px" class="input-group">
                   <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                       <input id="txtPassword" type="password" class="form-control" name="password" placeholder="password" runat="server"/>
                   </div>
                   
                   <div class="input-group">
                   <div class="checkbox">
                         <label>
                             <input id="chkRemember" type="checkbox" name="remember" value="1" runat="server"/> Remember me
                         </label>
                   </div>
                   </div>
                   
                   <div style="margin-top:10px" class="form-group">
                     <!-- Button -->

                     <div class="col-sm-12">
                         <div class="col-sm-3 controls">
                             <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-success" OnClick="btnLogin_Click" Text="Login" />
                         </div>
                         <div class="col-sm-9 controls" style="color: red">
                             <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                         </div>
                         
                      </div>
                    </div>
                                    
                   
                   <div class="form-group">
                        <div class="col-md-12 control">
                            <div style="border-top: 1px solid#888; padding-top:15px; font-size:85%" >
                                   Don't have an account! 
                            <a href="RegistrationUI.aspx">
                                Register Here
                            </a>
                         </div>
                     </div>
                  </div> 
               </div>
           </div>
       </div>
   </div>
    </form>
</body>
</html>
