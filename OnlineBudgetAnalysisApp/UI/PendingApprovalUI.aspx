<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="PendingApprovalUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.PendingApprovalUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="padding-bottom: 20px;padding-top: 20px">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2><u>Pending User Approval List</u></h2>
            </div>
            <div class="col-sm-4"></div>
        </div>
        
        <div class="row" style="padding-bottom: 345px;padding-top: 20px" runat="server" ID="paddingControl">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-4"></div>           
        </div>
        
        <div class="row" style="width: 1000px;padding-bottom: 20px" runat="server" ID="paddingControl1">
            <div class="col-sm-1"></div>
            
            <div class="col-sm-11">
                <asp:GridView ID="pendingApprovalGridView" AutoGenerateColumns="False" OnRowDataBound="pendingApprovalGridView_RowCommand" CssClass="manageDataTable" runat="server">
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
              <div class="col-sm-0"></div>             
        </div>
    </div>
</asp:Content>
