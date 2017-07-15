<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="ProductListUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ProductListUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        
        <div class="row" style="padding-top: 50px;padding-bottom: 20px">
            <div class="col-sm-2"></div>
            <div class="col-sm-8">
                <h3>Products are identified by their <b>SKU (Sales Keeping Unit)</b>. Every product is categorized. 
                    Total production cost of every product consists of <b>Unit cost, Packaging cost, Shipping cost, Market Fee and VAT (Value Added Tax).</b>
                </h3>
            </div>
            <div class="col-sm-2"></div>
        </div>

           <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                    <h2><u>List of Products</u></h2>
                </div>
            <div class="col-sm-4"></div>
        </div>
        
        <<%--div class="row" style="text-align: center; padding-bottom: 50px;">
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
                <asp:GridView ID="prdctListGridview" CssClass="manageDataTable" AutoGenerateColumns="False" runat="server">
                    <Columns>
                        <asp:TemplateField HeaderText="SL#">
                            <ItemTemplate>
                                <%#Container.DataItemIndex+1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SKU">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Sku") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField><asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField><asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField><asp:TemplateField HeaderText="Unit Cost">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("UnitCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField><asp:TemplateField HeaderText="Packaging Cost">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("PackagingCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField><asp:TemplateField HeaderText="Shipping Cost">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ActualShippingCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField><asp:TemplateField HeaderText="Market Fee">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("MarketFee") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField><asp:TemplateField HeaderText="VAT(%)">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Vat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-sm-1"></div>
        </div>
    </div>
</asp:Content>
