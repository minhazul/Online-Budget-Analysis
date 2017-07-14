<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="ChangePasswordUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ChangePasswordUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid" style="background: url(../pictures/background.gif)">
        <div class="container">
            <div class="page-header">
                <h2 style="text-align: center;color: white">Change Password</h2>
            </div>
        </div>
        <div class="container" style="color: white">
            <div id="ChangePasswordBox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">&nbsp;&nbsp;&nbsp;Change Password here</div>
                    </div>
                    
                    <div class="form-horizontal" style="padding: 20px">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <input class="form-control" type="password" id="txtOldPass" pattern=".{6,25}" required="" title="password should be 6 to 25 characters long" placeholder="Enter old password" runat="server"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <input class="form-control" type="password" id="txtNewPassword" pattern=".{6,25}" required="" title="password should be 6 to 25 characters long" placeholder="Enter new password" runat="server"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <input class="form-control" type="password" id="txtConfirmPassword" pattern=".{6,25}" required="" title="password should be 6 to 25 characters long" placeholder="Confirm password" runat="server"/>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                ControlToValidate="txtConfirmPassword"
                                CssClass="ValidationError"
                                ControlToCompare="txtNewPassword"
                                ErrorMessage="Both password must be the same" 
                                ToolTip="Both password must be the same" Display="Dynamic" ForeColor="red" Font-Italic="True"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="col-sm-3" style="padding: 2px">
                                    <asp:Button ID="btnChangePass" runat="server" CssClass="btn btn-success" Text="Change" OnClick="btnChangePass_Click"/>
                                </div>
                                <div class="col-sm-7" style="padding: 2px">
                                    <asp:Button ID="btnCancelPass" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancelPass_Click"/>
                                </div>                 
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-sm-10" style="color: black">
                                <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
