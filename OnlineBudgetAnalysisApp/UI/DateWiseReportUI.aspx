<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="DateWiseReportUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.DateWiseReportUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap-datepicker.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var dp = $("#<%=StartTextBox.ClientID%>");
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "yyyy-mm-dd",
                autoclose: true,
                todayHighlight: true
            });

            var ds = $("#<%=EndTextBox.ClientID%>");
            ds.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "yyyy-mm-dd",
                autoclose: true,
                todayHighlight: true
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        
        <div class="row" style="padding-top: 50px;padding-bottom: 20px">
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
                <h3>Standard Deviation of Sales Data report is calculated by <b>Product Information & Daily Inventory Data</b> from <b>one day to another day.</b></h3>
            </div>
            <div class="col-sm-3"></div>
        </div>

        <div class="row">
            <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                    <h2><u>Standard Deviations of Sales Data</u></h2>
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
            <div class="col-sm-12">
                <div class="col-sm-2"></div>
                <div class="col-sm-1" style="padding: 2px;padding-right: 1px">
                    <label><b>Start Date</b></label>
                </div>
                <div class="col-sm-4" style="padding: 2px">                   
                    <asp:TextBox ID="StartTextBox" runat="server" required="" CssClass="m-wrap span12 date form_datetime"></asp:TextBox>
                </div>
                <div class="col-sm-1" style="padding: 2px;padding-right: 3px">
                    <label><b>End Date</b></label>
                </div>
                <div class="col-sm-4" style="padding: 2px">              
                    <asp:TextBox ID="EndTextBox" runat="server" required="" CssClass="m-wrap span12 date form_datetime"></asp:TextBox>
                </div>
            </div>
        </div>
        
        <div class="row" style="text-align: center; padding-top: 20px;padding-bottom: 50px" runat="server" ID="paddingControl">
            <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-success" Text="Generate" OnClick="btnGenerate_Click" />&nbsp;&nbsp;
            <asp:Label ID="msgError" runat="server" Text=""></asp:Label>
        </div>
        
        <div class="row" style="text-align: center; padding-bottom: 50px;">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                <asp:Label ID="msgLists" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-4"></div>
        </div>
        
        <div class="row">
            <asp:GridView ID="DateWiseReportGridView" AutoGenerateColumns="False" CssClass="manageDataTable" runat="server">
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
