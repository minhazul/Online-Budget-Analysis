<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="PendingApprovalUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.PendingApprovalUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="padding-bottom: 20px;padding-top: 20px">
            <div class="col-sm-3"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2>Pending User Approval List</h2>
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
        
        <div class="row" style="width: 1000px">
            
                <asp:GridView ID="pendingApprovalGridView" AutoGenerateColumns="False" OnRowDataBound="pendingApprovalGridView_RowCommand" CssClass="pendingUserDataTable" runat="server">
                <Columns>
                    <asp:TemplateField HeaderText="SL#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:HiddenField ID="idHiddenField" Value='<%#Eval("Id") %>' runat="server"/>
                            <asp:Label runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Designation">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("DesignationName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Email") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Registration Date">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%#Eval("Registration_Date") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Approve /Delete">
                        <ItemTemplate>
                            <asp:DropDownList ID="approveOrDeleteDropDownList" AutoPostBack="True" OnSelectedIndexChanged="approveOrDeleteDropDownList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
                           
        </div>
    </div>
</asp:Content>
