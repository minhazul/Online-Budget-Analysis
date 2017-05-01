<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="HomeUI.aspx.cs" Inherits="OnlineBudgetAnalysisApp.UI.HomeUI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="feature">
        <div class="container">
           <div class="center wow fadeInDown">
                <h2 style="margin-top: 50px">Features</h2>
                <p class="lead">Online Budget Analysis System is a online based web application designed <br/> to ease the analysis and help to make decisions on production and sales cost</p>
            </div>

            <div class="row">
                <div class="features">
                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">                           
                            <i class="fa fa-link"></i>
                            <h2>Completly Online</h2>
                            <h3>Online application makes it portable</h3>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-file-excel-o"></i>
                            <h2>Excel file parcing</h2>
                            <h3>Support excel file parcing contating numerous data</h3>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-file"></i>
                            <h2>Generate reports</h2>
                            <h3>The application generate reports based on user choice</h3>
                        </div>
                    </div><!--/.col-md-4-->
                
                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-shield"></i>
                            <h2>Security</h2>
                            <h3>The application is fully secure based on user role</h3>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-cogs"></i>
                            <h2>Dashboard</h2>
                            <h3>The application has a dashboard to control all user access</h3>
                        </div>
                    </div><!--/.col-md-4-->

                    <div class="col-md-4 col-sm-6 wow fadeInDown" data-wow-duration="1000ms" data-wow-delay="600ms">
                        <div class="feature-wrap">
                            <i class="fa fa-tablet"></i>
                            <h2>Device Independent</h2>
                            <h3>It is device independent accessible from any device having internet access</h3>
                        </div>
                    </div><!--/.col-md-4-->
                </div><!--/.services-->
            </div><!--/.row-->    
        </div><!--/.container-->
    </section>
</asp:Content>
