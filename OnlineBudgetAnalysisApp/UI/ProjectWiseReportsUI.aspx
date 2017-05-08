﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectWiseReportsUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ProjectWiseReportsUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    
    
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />

    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../Content/responsive.css" rel="stylesheet" />

    <title>ProjectWise Report</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
                <div class="col-sm-4">
                    <asp:Button ID="btnBack" runat="server" CssClass="btn btn-danger" Text="Back to Home" OnClick="btnBack_Click"/>
                </div>
                <div class="col-sm-4" style="text-align: center">
                    <h2>ProjectWise Report</h2>
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

        <div class="row" style="padding-bottom: 50px">
            <div class="col-sm-4"></div> 
            <div class="col-sm-1">
                <label><b>Select Project</b></label>
            </div>
            <div class="col-sm-4">
                <asp:DropDownList ID="dropDownProjectList" AutoPostBack="True" OnSelectedIndexChanged="dropDownProjectList_SelectedIndexChanged" runat="server"></asp:DropDownList>
            </div> 
            <div class="col-sm-3"></div>
        </div>
        
        <div class="row">
            <div class="col-sm-12">
                <asp:GridView ID="prjctWiseRepotGridView" CssClass="prjctWiseDatatable" AutoGenerateColumns="False" runat="server">
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
                        <asp:TemplateField HeaderText="SKU">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Sku") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Category">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%#Eval("Category") %>'></asp:Label>
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
    </div>
    </form>
    
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/respond.min.js"></script>
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.prjctWiseDatatable').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();

        });
    </script>
</body>
</html>