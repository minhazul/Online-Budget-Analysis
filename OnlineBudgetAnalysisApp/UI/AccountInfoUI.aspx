<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="AccountInfoUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.AccountInfoUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid" style="background: url(../pictures/background.gif)">
        <div class="container">
            <div class="page-header">
                <h2 style="text-align: center;color: white">Account Information</h2>
            </div>
        </div>
        <div class="container">
            <div id="AccountInfobox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <div class="panel-title">&nbsp;&nbsp;&nbsp;Account Info</div>
                    </div>
                    
                    <div class="form-horizontal" style="padding: 20px">
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="col-sm-2" style="color: black;padding: 0px">
                                    <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label>
                                </div>
                                <div class="col-sm-7">                    
                                    <asp:TextBox ID="txtUserName" CssClass="form-control" pattern=".{4,15}" ValidationGroup="update" required="" title="username should be 4 to 15 characters long" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="col-sm-2" style="color: black;padding: 0px">
                                    <asp:Label ID="Label2" runat="server" Text="Full Name"></asp:Label>
                                </div>
                                <div class="col-sm-7">                    
                                    <asp:TextBox ID="txtFullName" CssClass="form-control" ReadOnly="True" pattern=".{6,28}" ValidationGroup="update" required="" title="Full should be 6 to 28 characters long" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="col-sm-2" style="color: black;padding: 0px">
                                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                                </div>
                                <div class="col-sm-7">                    
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" ReadOnly="True" required="" ValidationGroup="update" TextMode="Email" runat="server"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Invalid Email Format" ToolTip="" Display="Dynamic" ForeColor="red" Font-Italic="True"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="col-sm-2" style="color: black;padding: 0px">
                                    <asp:Label ID="Label4" runat="server" Text="Last Login Date"></asp:Label>
                                </div>
                                <div class="col-sm-7">                    
                                    <asp:TextBox ID="txtLastLoginDate" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group" >
                            <div class="col-sm-10">
                                <div class="col-sm-2" style="color: black;padding: 0px">
                                    <asp:Label ID="passLabel" Visible="False" runat="server" Text="Enter Password"></asp:Label>
                                </div>
                                <div class="col-sm-7">                    
                                    <asp:TextBox ID="txtPassword" TextMode="Password" Visible="False" pattern=".{6,25}" required="" ValidationGroup="update" title="password should be 6 to 25 characters long" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="col-sm-3" style="padding: 2px">
                                    <asp:Button ID="btnEdit" runat="server" CssClass="btn btn-danger" Text="Edit" OnClick="btnEdit_Click"/>
                                </div>
                                <div class="col-sm-3" style="padding: 2px">
                                    <asp:Button ID="btnSave" Visible="False" runat="server" CssClass="btn btn-success" Text="Save" OnClick="btnSave_Click"/>
                                </div>
                                <%--<div class="col-sm-4" style="padding: 2px">
                                    <asp:Button ID="btnCancelPass" Visible="False" runat="server" ValidationGroup="cancel" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancelPass_Click"/>
                                </div>--%>                 
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
