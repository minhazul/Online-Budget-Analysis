<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.RegistrationUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <title>Registration</title>
</head>
<body style="background: url(images/background.gif)">

   <div class="container">
       <div id="registerbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
           <div class="panel panel-info">
               <div class="panel-heading">
                    <div class="panel-title">&nbsp;&nbsp;&nbsp;Register</div>
                    <div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="LoginUI.aspx">Login</a></div>
               </div>
               
               <form id="form1" class="form-horizontal" style="padding: 20px">
                   <div class="form-group">
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="txtUsername" placeholder="Enter a username" runat="server"/>
                    </div>
                  </div>
                   <div class="form-group">
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="txtFullName" placeholder="Enter your full name" runat="server"/>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-10">
                        <input type="text" class="form-control" id="txtEmail" placeholder="Enter your email" runat="server"/>
                    </div>
                  </div>
                  <div class="form-group">             
                    <div class="col-sm-10">
                        <input type="password" class="form-control" id="txtPassword" placeholder="Enter a password" runat="server"/>
                    </div>
                  </div>
                   <div class="form-group">             
                    <div class="col-sm-10">
                        <input type="password" class="form-control" id="txtConfirmPassword" placeholder="Confirm your password" runat="server"/>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-10">
                      <button type="submit" id="btnRegister" class="btn btn-success">Register</button>
                    </div>
                  </div>
                </form>

           </div>
       </div>
   </div> 

</body>
</html>
