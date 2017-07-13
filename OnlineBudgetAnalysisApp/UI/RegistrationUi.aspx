<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationUi.aspx.cs" UnobtrusiveValidationMode="none" Inherits="OnlineBudgetAnalysisApp.RegistrationUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    
    <title>Registration</title>
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
       <div id="registerbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
           <div class="panel panel-info">
               <div class="panel-heading">
                    <div class="panel-title">&nbsp;&nbsp;&nbsp;Register here</div>
                    <div style="float:right; font-size: 80%; position: relative; top:-10px"><a href="LoginUI.aspx">Login</a></div>
               </div>
               
               <form id="form1" class="form-horizontal" style="padding: 20px" runat="server">
                   <div class="form-group">
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control" ID="userNameTextBox" pattern=".{4,10}" required="" title="username should be 4 to 10 characters long" Placeholder="Enter a username">
                        </asp:TextBox>
                    </div>
                  </div>
                   <div class="form-group">
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control" ID="txtFullName" pattern=".{6,15}" required="" title="username should be 6 to 15 characters long" Placeholder="Enter your full name">
                        </asp:TextBox>
                    </div>
                  </div>
                   <div class="form-group">
                    <div class="col-sm-10">
                        <div class="col-sm-5">
                            <asp:Label ID="Label1" runat="server" Text="Choose Designation"></asp:Label>
                        </div>
                        <div class="col-sm-5">
                            <asp:DropDownList ID="dropDownDesignation" CssClass="form-control" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" 
                            ID="validateDropdown" Display="Dynamic" 
                            ControlToValidate="dropDownDesignation"
                            runat="server"  Text="Please select a valid designation" 
                            ErrorMessage="Please Select the Product"
                            ForeColor="Red">
                            </asp:RequiredFieldValidator>                            
                        </div>
                    </div>
                  </div>
                  <div class="form-group">
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control" required="" TextMode="Email" ID="txtEmail" Placeholder="Enter your emailid">
                        </asp:TextBox>
                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ToolTip="" Display="Dynamic" ForeColor="red"></asp:RegularExpressionValidator>
                    </div>
                  </div>
                  <div class="form-group">             
                    <div class="col-sm-10">
                        <asp:TextBox ID="passTextBox" CssClass="form-control" TextMode="Password" pattern=".{6,}" required="" title="password should be at least 6 characters long" Placeholder="Please confirm your password" runat="server">                           
                        </asp:TextBox>
                    </div>
                  </div>
                   <div class="form-group">             
                    <div class="col-sm-10">
                        <asp:TextBox runat="server" CssClass="form-control" ID="confirmPassTextBox" pattern=".{6,}" required="" title="password should be at least 6 characters long" Placeholder="Please confirm your password" TextMode="Password"> 
                        </asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="confirmPassTextBox"
                        CssClass="ValidationError"
                        ControlToCompare="passTextBox"
                        ErrorMessage="Both password must be the same" 
                        ToolTip="Both password must be the same" Display="Dynamic" ForeColor="red"/>
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
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    
</body>
</html>
