<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="AllUsersInfoUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.AllUsersInfoUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="padding-bottom: 20px;padding-top: 20px">
            <div class="col-sm-3"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2>All User's Information</h2>
            </div>
            <div class="col-sm-5"></div>
        </div>
        
        <div class="row">
            <asp:GridView ID="allUsersInfoGridView" AutoGenerateColumns="False" CssClass="manageDataTable" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="SL#">
                         <ItemTemplate>
                              <%#Container.DataItemIndex+1 %>
                         </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Full Name">
                        <ItemTemplate>                   
                            <asp:Label runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Name">
                        <ItemTemplate>                           
                            <asp:Label runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>                           
                            <asp:Label runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>                           
                            <asp:Label runat="server" Text='<%#Eval("Designation") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Role">
                        <ItemTemplate>                           
                            <asp:Label runat="server" Text='<%#Eval("Role") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Login Date">
                        <ItemTemplate>                           
                            <asp:Label runat="server" Text='<%#Eval("LastLoginDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Registration Date">
                        <ItemTemplate>                           
                            <asp:Label runat="server" Text='<%#Eval("RegistrationDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    
</asp:Content>
