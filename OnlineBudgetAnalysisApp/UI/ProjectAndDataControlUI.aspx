<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="ProjectAndDataControlUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ProjectAndDataControlUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="container">
        <div class="row" style="padding-bottom: 20px;padding-top: 20px">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h2>Project Control</h2>
            </div>
            <div class="col-sm-4"></div>
        </div>
        
        <div class="row" style="padding-bottom: 10px">
            <div class="col-sm-3"></div>
            <div class="col-sm-4" style="text-align: center">
                <asp:Label ID="msgPrjctLabel" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-5"></div>           
        </div>
        
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <asp:GridView ID="prjctCntrlGridView" AutoGenerateColumns="False" OnRowDataBound="prjctCntrlGridView_RowCommand" CssClass="manageDataTable"  runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="SL#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:HiddenField ID="idHiddenField" Value='<%#Eval("Id") %>' runat="server"/>
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
                        <asp:TemplateField HeaderText="Status">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Approve /Delete">
                        <ItemTemplate>
                            <asp:DropDownList ID="openOrCloseDropDownList" AutoPostBack="True" OnSelectedIndexChanged="openOrCloseDropDownList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm-2"></div>
        </div>
            
        <div class="row" style="padding: 5px">
             <hr/>
        </div> 
            
            <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4">
                    <h2>Data Control</h2>
                </div>
                <div class="col-sm-4"></div>
            </div> 
            
            <div class="row">
                <div class="col-sm-2">
                    <asp:Button ID="btnClearProductInfo" CssClass="btn btn-danger" runat="server" Text="ClearProduct Information Data" OnClick="btnClearProductInfo_Click" />
                </div>
                <div class="col-sm-10">
                    <asp:Label ID="msgClearProductInfoLabel" runat="server" Text=""></asp:Label>
                </div>
            </div>
                     
    </div>
    
</asp:Content>
