﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" UnobtrusiveValidationMode="none" CodeBehind="ProjectWiseReportsUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ProjectWiseReportsUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        
        <div class="row" style="padding-top: 50px;padding-bottom: 20px">
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
                <h3>Project Wise report is calculated by <b>Product Information & Daily Inventory Data</b> of particular <b>project.</b> Sales 
                    report is generated by <b>openned</b> project only.
                </h3>
            </div>
            <div class="col-sm-3"></div>
        </div>

        <div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                    <h2><u>ProjectWise Report</u></h2>
                </div>
            <div class="col-sm-4"></div>
        </div>
        
        <div class="row" style="text-align: center;padding-bottom: 20px">
            <div class="col-sm-4"></div>
            <div class="col-sm-4" style="text-align: center">
                <h3>Prepared by </h3>
                <asp:Label ID="msgFullName" runat="server" Text=""></asp:Label>
            </div>
            <div class="col-sm-4"></div>
        </div>

        <div class="row" style="padding-bottom: 130px;padding-top: 20px" runat="server" ID="paddingControl1">
            <div class="col-sm-5"></div>
            <div class="col-sm-1" style="padding-left: 0px">
                <h5><b>Select Project</b></h5>
            </div>
            <div class="col-sm-3" style="padding-left: 0px;width: 200px">                
                <asp:DropDownList ID="dropDownProjectList" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="dropDownProjectList_SelectedIndexChanged" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator InitialValue="-1" 
                                            ID="validateDropdown" Display="Dynamic" 
                                            ControlToValidate="dropDownProjectList"
                                            runat="server"  Text="Please Select a Project" 
                                            ErrorMessage="Please Select a Project"
                                            ForeColor="Red" Font-Italic="True">
                                            </asp:RequiredFieldValidator>
            </div> 
            <div class="col-sm-3"></div>
        </div>
        
        <div class="row" style="text-align: center" runat="server" ID="paddingControl">
                <div class="col-sm-4"></div>
                <div class="col-sm-4" style="text-align: center">
                <asp:Label ID="msgLists" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-4"></div>
        </div>
        
        <div class="row" style="padding-bottom: 20px">
            <div class="col-sm-12">
                <asp:GridView ID="prjctWiseRepotGridView" CssClass="manageDataTable" AutoGenerateColumns="False" runat="server">
                    <Columns>
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
</asp:Content>
