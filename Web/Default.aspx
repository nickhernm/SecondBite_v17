<%@ Page Title="Main" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link href="Default.css" rel="stylesheet" />

    <div class="OptionContainer">
        <div class="OptionElement">
            <a href="Restaurantes">
                <img src="/Images/restaurantesPlaceHolder.jpg" alt="Restaurante">
            </a>
        </div>
        <div class="OptionElement">
            <a href="Platos">
                <img src="/Images/platosPlaceHolder.jpg" alt="Plato">
            </a>
        </div>
        <div class="OptionElement">
            <a href="Recomendaciones">
                <img src="/Images/recoPlaceHolder.jpg" alt="Recomendado">
            </a>
        </div>
    </div>

</asp:Content>