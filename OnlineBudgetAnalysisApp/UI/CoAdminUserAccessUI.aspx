<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="CoAdminUserAccessUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.CoAdminUserAccessUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="padding-bottom: 20px;padding-top: 20px">
            <div class="col-sm-3"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2>Co-Admin Table</h2>
            </div>
            <div class="col-sm-5"></div>
        </div>
        
        <div class="row" style="padding-bottom: 10px">
            <div class="col-sm-3"></div>
            <div class="col-sm-4" style="text-align: center">
                <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-5"></div>           
        </div>
        
        <div class="row">
            <asp:GridView ID="CoAdminTableGridView" AutoGenerateColumns="False" CssClass="manageDataTable" OnRowDataBound="CoAdminTableGridView_RowCommand" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="SL#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Full Name">
                        <ItemTemplate>
                            <asp:HiddenField ID="idHiddenField" Value='<%#Eval("Id") %>' runat="server"/>
                            <asp:Label runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="UserName">
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
                    <asp:TemplateField HeaderText="Registration Date">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("RegistrationDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Login Date">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("LastLoginDate") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Change Access">
                        <ItemTemplate>
                            <asp:DropDownList ID="CoAdminTableDropDownList" AutoPostBack="True" OnSelectedIndexChanged="CoAdminTableDropDownList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        
    </div>
</asp:Content>
