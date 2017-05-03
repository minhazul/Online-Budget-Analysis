<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="UploadUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.UploadUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container-fluid" style="background: url(../pictures/background.gif)">
            <div class="container">
            <div class="page-header">
                <h2 style="text-align: center;color: white">Upload File</h2>
            </div>
                
            <div class="container">
                    <div id="Uploadbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                        <div class="panel panel-info">
                            <div class="panel-heading">
                                <div class="panel-title">&nbsp;&nbsp;&nbsp;Upload file here(xlsx,xls or xla)</div>
                            </div>
                            
                            <div class="form-horizontal" style="padding: 20px">
                                
                                    <div class="form-group">
                                    <div class="col-sm-10">
                                        <div class="col-sm-1"></div>
                                        <div class="col-sm-9">
                                            <h3><b>Upload Product Information file here</b></h3>
                                        </div>        
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="col-sm-3" style="color: black;padding-left: 6px">
                                            <asp:Label ID="Label1" runat="server" Text=""><b>Choose file</b></asp:Label>
                                        </div>
                                        <div class="col-sm-6">                    
                                            <input id="prdctInfoUpload" type="file" name="Browse" runat="server"/>
                                        </div>                        
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="col-sm-3" style="color: black;padding: 0px"></div>
                                        <div class="col-sm-2" style="padding-top: 3px;padding-left: 16px">
                                            <asp:Button ID="btnPrdctInfoUpload" CssClass="btn btn-success" runat="server" Text="Upload" OnClick="btnPrdctInfoUpload_Click" />
                                        </div>
                                        <div class="col-sm-5">
                                            
                                        </div>
                                    </div>
                                    <div class="col-sm-10">
                                        <asp:Label ID="msgPrdctInfoLabel" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                              
                                <hr style="color: blue"/>
                                
                                <div class="form-group">
                                    <div class="col-sm-10">
                                        <div class="col-sm-1"></div>
                                        <div class="col-sm-9">
                                            <h3><b>Upload Daily Inventory file here</b></h3>
                                        </div>        
                                    </div>
                                    <div class="col-sm-10" style="padding-bottom: 4px">
                                        <div class="col-sm-4" style="color: black;padding-left: 6px">
                                            <asp:Label ID="Label3" runat="server" Text=""><b>Select Project</b></asp:Label>
                                        </div>
                                        <div class="col-sm-6">
                                            <asp:DropDownList ID="ddlpjcts" runat="server" CssClass="dropdown"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="col-sm-4" style="color: black;padding-left: 6px">
                                            <asp:Label ID="Label2" runat="server" Text=""><b>Choose file</b></asp:Label>
                                        </div>
                                        <div class="col-sm-6">                    
                                            <input id="dailyInventoryUpload" type="file" name="Browse" runat="server"/>
                                        </div>                        
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="col-sm-4" style="color: black;padding: 0px"></div>
                                        <div class="col-sm-2" style="padding-top: 3px;padding-left: 16px">
                                            <asp:Button ID="btnDailyInventoryUpload" CssClass="btn btn-success" runat="server" Text="Upload" OnClick="btnDailyInventoryUpload_Click" />
                                        </div>
                                        <div class="col-sm-5">
                                            
                                        </div>
                                    </div>
                                     <div class="col-sm-10">
                                          <asp:Label ID="msgDailyInventoryUpload" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
