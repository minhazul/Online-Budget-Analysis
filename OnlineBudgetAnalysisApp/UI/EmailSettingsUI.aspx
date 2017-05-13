<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="EmailSettingsUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.EmailSettingsUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="padding-top: 10px;padding-bottom: 20px">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2>Email Section</h2>
            </div>
            <div class="col-sm-4"></div>
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-12">
                <label><b>Application Current Email: </b></label>
                <asp:Label ID="msgCurrentEmail" runat="server" Text=""></asp:Label>
            </div>                    
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-12">
                <label><b>Current Password: </b></label>
                <asp:Label ID="msgCurrentPassword" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <div class="row" style="padding: 10px">
            <hr/>
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-3">
                <span class="label label-warning">Change Password</span>
            </div>
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-6">
                <label style="padding-right: 2px"><b>Enter new Password</b></label>
                <asp:TextBox ID="txtChangeApplicationEmailPassword" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-6">
                <label style="padding-right: 15px"><b>Confirm Password</b></label>
                <asp:TextBox ID="txtConfirmChangeApplicationEmailPassword" runat="server"></asp:TextBox>               
            </div>           
        </div>    
        
        <div class="row" style="padding-left: 5px;padding-top: 5px">
            <div class="col-sm-8">
                <asp:Button ID="btnCHangedPasswordSubmit" CssClass="btn btn-danger" runat="server" Text="Submit" OnClick="btnCHangedPasswordSubmit_Click" />&nbsp;&nbsp;
                <asp:Label ID="chngPasswordLabel" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <div class="row" style="padding: 0px">
            <hr/>
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-12">
                <span class="label label-warning">Change Application Email</span>
            </div>
        </div>                  
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-6">
                <label style="padding-right: 25px"><b>Enter New Email</b></label>
                <asp:TextBox ID="txtNewEmail" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-6">
                <label style="padding-right: 31px"><b>Enter Password</b></label>
                <asp:TextBox ID="txtNewEmailPassword" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-6">
                <label style="padding-right:11px"><b>Confirm Password</b></label>
                <asp:TextBox ID="txtConfirmNewEmailPassword" runat="server"></asp:TextBox>
            </div>
        </div>
        
        <div class="row" style="padding: 5px">
            <div class="col-sm-8">
                <asp:Button ID="btnNewEmailAndPassword" CssClass="btn btn-danger" runat="server" Text="Submit" OnClick="btnNewEmailAndPassword_Click" />&nbsp;&nbsp;
                <asp:Label ID="msgchngEmailLabel" runat="server" Text=""></asp:Label>
            </div>
        </div>
        
        <div class="row" style="padding: 0px">
            <hr/>
        </div>

        <div class="row" style="padding: 5px;text-align: center">
           <span class="label label-info">Application Email Lists</span>           
        </div>        
        
        <div class="row" style="text-align: center;padding: 5px">
            <asp:Label ID="msgGridEmailListsLabel" runat="server" Text=""></asp:Label>
        </div>
        
        <div class="row" style="padding-top: 20px">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <asp:GridView ID="ApplicationEmailListsGridView" AutoGenerateColumns="False" CssClass="manageDataTable" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="SL#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:HiddenField ID="idHiddenField" Value='<%#Eval("Id") %>' runat="server"/>
                            <asp:Label runat="server" Text='<%#Eval("EmailName") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Password">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Password") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activation">
                        <ItemTemplate>
                            <asp:LinkButton ID="activateLinkButton" Text="Activate" OnClick="activateLinkButton_OnClick" runat="server"></asp:LinkButton>
                        </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm-2"></div>
        </div>
    </div>
</asp:Content>
