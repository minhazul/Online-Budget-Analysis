<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProjectListUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ProjectListUI" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/font-awesome.min.css" rel="stylesheet" />
    <link href="../Content/responsive.css" rel="stylesheet" />
    
    <title>Project Lists</title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <asp:Button ID="btnBack" runat="server" CssClass="btn btn-danger" Text="Back to Home" OnClick="btnBack_Click" />
            </div>
            <div class="col-sm-4" style="text-align: center">
                <h2>List of Projects</h2>
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
            <div class="col-sm-8">
                <asp:GridView ID="prjctListGridview" CssClass="dataTablePrjctList" runat="server" AutoGenerateColumns="False">
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
                                <asp:Label runat="server" Text='<%#Eval("ProjectHeadId") %>'></asp:Label>
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
            <div class="col-sm-2"></div>
        </div>
    </div>
    </form>
    
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <script src="../Scripts/respond.min.js"></script>
    <script src="../Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script>
        $(document).ready(function () {
            $('.dataTablePrjctList').prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            
        });
    </script>
</body>
</html>
