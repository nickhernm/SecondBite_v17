<%@ Page Title="Main" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" type="text/css" href="Default.css" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="Default.js"></script>

    <div class="slideshow-container">
        <div class="mySlides">
            <a href="Restaurantes.aspx">
                <img src="Images/restaurantes.png" style="width:100%" alt="Restaurantes">
            </a>
        </div>

        <div class="mySlides">
            <a href="Platos.aspx">
                <img src="Images/platos.png" style="width:100%" alt="Platos">
            </a>
        </div>

        <div class="mySlides">
            <a href="Recomendaciones.aspx">
                <img src="Images/reco.png" style="width:100%" alt="Recomendaciones">
            </a>
        </div>
    </div>

</asp:Content>