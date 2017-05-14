<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="UploadActivityUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.UploadActivityUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row" style="padding-top: 20px;padding-bottom: 40px">
            <div class="col-sm-4"></div>
            <div class="col-sm-6">
                <h2>User Upload Activity</h2>
            </div>
            <div class="col-sm-2"></div>            
        </div>
        
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-7">
                <asp:GridView ID="activityGridView" AutoGenerateColumns="False" CssClass="manageDataTable" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="SL#">
                         <ItemTemplate>
                              <%#Container.DataItemIndex+1 %>
                         </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Date">
                        <ItemTemplate>                   
                            <asp:Label runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="User">
                        <ItemTemplate>                   
                            <asp:Label runat="server" Text='<%#Eval("FullName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Activity">
                        <ItemTemplate>                   
                            <asp:Label runat="server" Text='<%#Eval("Activity") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm-3"></div>
        </div>
    </div>
</asp:Content>
