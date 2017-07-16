<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="NormalUserAccessUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.NormalUserAccessUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <div class="row" style="padding-bottom: 20px;padding-top: 20px">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2>Normal User Table</h2>
            </div>
            <div class="col-sm-4"></div>
        </div>
        
        <div class="row" runat="server" ID="paddingControl1">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <asp:Label ID="msgNormalLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-4"></div>           
        </div>
        
        <div class="row" runat="server" ID="paddingControl">
            <asp:GridView ID="normalUserGridView" AutoGenerateColumns="False" CssClass="manageDataTable" OnRowDataBound="normalUserGridView_RowCommand" runat="server">
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
                            <asp:DropDownList ID="normalUserDropDownList" AutoPostBack="True" OnSelectedIndexChanged="normalUserDropDownList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
