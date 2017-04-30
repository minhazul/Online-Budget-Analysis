<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="AccountInfoUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.AccountInfoUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="container-fluid" style="background: url(../images/background.gif)">
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
                                    <asp:TextBox ID="txtUserName" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="col-sm-2" style="color: black;padding: 0px">
                                    <asp:Label ID="Label2" runat="server" Text="Full Name"></asp:Label>
                                </div>
                                <div class="col-sm-7">                    
                                    <asp:TextBox ID="txtFullName" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <div class="col-sm-10">
                                <div class="col-sm-2" style="color: black;padding: 0px">
                                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                                </div>
                                <div class="col-sm-7">                    
                                    <asp:TextBox ID="txtEmail" CssClass="form-control" ReadOnly="True" runat="server"></asp:TextBox>
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
                                    <asp:TextBox ID="txtPassword" Visible="False" CssClass="form-control" runat="server"></asp:TextBox>
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
                                <div class="col-sm-4" style="padding: 2px">
                                    <asp:Button ID="btnCancelPass" Visible="False" runat="server" CssClass="btn btn-danger" Text="Cancel" OnClick="btnCancelPass_Click"/>
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
