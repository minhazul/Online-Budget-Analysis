<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="MonthWiseReportUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.MonthWiseReportUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
    <div class="row">
            <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                    <h2>Gross Monthly Depiction Policy</h2>
                </div>
            <div class="col-sm-4"></div>
        </div>
        
        <div class="row" style="text-align: center; padding-bottom: 50px;">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h3>Prepared by </h3>
                <asp:Label ID="msgFullName" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-4"></div>
        </div>
        
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-1">
                
            </div>
            <div class="col-sm-4">
                <label style="padding-right: 2px"><b>Select Month</b></label>
                <asp:DropDownList ID="monthDropDownList" Width="200px" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
            <div class="col-sm-5">
                <label style="padding-right: 2px"><b>Select Year</b></label>
                <asp:DropDownList ID="yearDropDownList" Width="200px" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>
        </div>
        
        <div class="row" style="text-align: center; padding-top: 20px;padding-bottom: 50px">
            <asp:Button ID="btnGenerate" CssClass="btn btn-success" runat="server" Text="Generate" OnClick="btnGenerate_Click" />
        </div>
        
        <div class="row">
            <asp:GridView ID="MonthWiseReportGridView" CssClass="manageDataTable" AutoGenerateColumns="False" runat="server">
                <Columns>
                        <asp:TemplateField HeaderText="Date">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Date") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Project Name">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ProjectName") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="SKU">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Sku") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Name") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sold">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Sold") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price/ unit">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Prices") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Total") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Unit Cost">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("UnitCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Packaging Cost">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("PackagingCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shipping Cost">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("ActualShippingCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>                       
                        <asp:TemplateField HeaderText="Market Fee">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("MarketFee") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="VAT">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Vat") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Production Cost/unit">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("TotalProdustionCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Produstion Cost">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("TotalCost") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Earning">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("TotalEarning") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
