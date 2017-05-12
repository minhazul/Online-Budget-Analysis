<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="UserAccessControl.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.UserAccessControl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="padding-top: 20px;padding-bottom: 70px">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2>User Information & Access Control</h2>
            </div>
            <div class="col-sm-4"></div>
        </div>
        
        <div class="row" style="padding-bottom: 10px">
            <div class="col-sm-2">
                <label><b>No of Total users</b></label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtNoTotalUser" ReadOnly="True" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <label><b>No of Co-Admin's</b></label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtNoCoAdmin" ReadOnly="True" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <div class="row" style="padding-bottom: 10px">
            <div class="col-sm-2">
                <label><b>No of Normal users</b></label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtNoNormal" ReadOnly="True" runat="server"></asp:TextBox>
            </div>
            <div class="col-sm-2">
                <label><b>No of pending user approvals</b></label>
            </div>
            <div class="col-sm-4">
                <asp:TextBox ID="txtNoPendingUsers" ReadOnly="True" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <div class="row" style="padding: 5px">
            <asp:Button ID="btnPendingUsers" runat="server" CssClass="btn btn-info" Text="Pending Approvals" OnClick="btnPendingUsers_Click" />
        </div>
        
        <div class="row" style="padding: 5px">
            <asp:Button ID="btnAllUsers" runat="server" CssClass="btn btn-info" Text="All Users" OnClick="btnAllUsers_Click" />
        </div>
        
        <div class="row" style="padding: 5px">
            <asp:Button ID="btnChangeUserAccess" CssClass="btn btn-warning" runat="server" Text="Change User Access" OnClick="btnChangeUserAccess_Click" />
        </div>
        
        <div class="row" style="padding: 5px">
            <asp:Button ID="btnBlockedUsers" CssClass="btn btn-danger" runat="server" Text="Blocked Users" />
        </div>
        
        <div class="row" style="padding: 5px">
            <asp:Button ID="btnUserActivity" CssClass="btn btn-primary" runat="server" Text="User Activity" />
        </div>
    </div>
</asp:Content>
