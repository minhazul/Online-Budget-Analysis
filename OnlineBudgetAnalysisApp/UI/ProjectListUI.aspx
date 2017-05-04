<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="ProjectListUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ProjectListUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">       
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container">
            <div class="row">
                <div class="col-sm-5"></div>
                <div class="col-sm-6">
                    <h2><b>Project Lists</b></h2>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <hr style="color: black"/>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <asp:GridView ID="prjctListsGridView" CssClass="dataTablePrjctList" runat="server" AutoGenerateColumns="False">
                        <Columns>
                            <asp:TemplateField HeaderText="Project Name">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("ProjectName") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Project Head">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("ProjectHead") %>'></asp:Label>
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
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="col-sm-2"></div>
            </div>
        </div>
    </section>  
    
</asp:Content>


