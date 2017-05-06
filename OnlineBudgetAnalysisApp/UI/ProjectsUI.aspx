<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="ProjectsUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.ProjectsUI" ValidateRequest="false"%>
<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.4.0, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>
<%@ Import Namespace="CKEditor.NET" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../Scripts/jquery-3.1.1.min.js"></script>
    <script src="../Scripts/ckeditor/ckeditor.js"></script>
    <script type="text/javascript">
        $(function () {
            CKEDITOR.replace('<%=CKEditorControl.ClientID %>', { filebrowserImageUploadUrl: '/Upload.ashx' });
        });
</script>
    <title></title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section>
        <div class="container" style="color: black">
            <h2><b>Create new project</b></h2>
            <hr/>
            <div class="row" style="padding: 3px">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                         <label>Project Name</label>
                    </div>
                    <div class="col-sm-3" style="padding-left: -5px">
                         <asp:TextBox ID="txtProjectName" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>               
            </div>
            
            <div class="row" style="padding: 3px">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label>Designation</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="dropDownDesignation" AutoPostBack="True" OnSelectedIndexChanged="dropDownDesignation_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            
            <div class="row" style="padding: 3px">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                        <label>Project Head</label>
                    </div>
                    <div class="col-sm-3">
                        <asp:DropDownList ID="dropDownProjectHead" runat="server"></asp:DropDownList>
                    </div>
                </div>
            </div>
            
            <div class="row" style="padding: 2px">
                <div class="col-sm-12">
                    <div class="col-sm-2">
                         <label>Description</label>
                    </div>                   
                </div>
            </div>

            <div class="row" style="padding: 2px">
                <div class="col-sm-12">
                    <!--ckeditor-->
                     <CKEditor:CKEditorControl ID="CKEditorControl" BasePath="~/ckeditor/" runat="server" Width="600px" Height="200px"></CKEditor:CKEditorControl>
                </div>
            </div>

            <div class="row" style="padding-top: 8px;padding-bottom: 15px">
                <div class="col-sm-12">
                    <div class="col-sm-1">
                        <asp:Button ID="btnCreate" CssClass="btn btn-success" runat="server" Text="Create" OnClick="btnCreate_Click" />
                    </div>
                    <div class="col-sm-11">
                        <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                    </div>
                </div>               
            </div>

        </div>
    </section>
    
</asp:Content>
