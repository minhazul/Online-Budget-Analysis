<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="ProjectListUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ProjectListUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <div class="row" style="padding-top: 50px;padding-bottom: 20px">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Projects are for organizing daily <b>inventory data</b>. Projects are controlled by <b>SuperAdmin</b>. 
                    Every project has a specific description. Every project is assigned to a <b>Project Head</b>. </h3>
            </div>
            <div class="col-sm-2"></div>
        </div>

        <div class="row">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2><u>List of Projects</u></h2>
            </div>
            <div class="col-sm-4"></div>
        </div>
        <%--<div class="row" style="text-align: center; padding-bottom: 50px;">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h3>Prepared by </h3>
                <asp:Label ID="msgFullName" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-4"></div>
        </div>--%>
        
        <div class="row" style="text-align: center" runat="server" ID="paddingControl">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                <asp:Label ID="msgLists" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-4"></div>
        </div>

        <div class="row" runat="server" ID="paddingControl1">
            <div class="col-sm-1"></div>
            <div class="col-sm-10">
                <asp:GridView ID="prjctListGridview" CssClass="manageDataTable" runat="server" AutoGenerateColumns="False">
                    <columns>
                        <asp:TemplateField HeaderText="SL#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Name">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ProjectName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Head">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ProjectHeadName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Description">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Description") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                        
                    </columns>
                </asp:GridView>
            </div>
            <div class="col-sm-1"></div>
        </div>
    </div>
</asp:Content>
