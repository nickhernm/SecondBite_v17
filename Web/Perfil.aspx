<%@ Page Title="PERFIL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Web.Perfil" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Perfil.css" rel="stylesheet" />
    <div class="ProfileContainer">
        <div class="ProfileElement">
            <div class="ProfilePic">
                <a href="#">
                    <img src="/Images/perfilPlaceHolder.jpg" alt="Foto de perfil">
                </a>        
            </div>
        </div>
        <div class="ProfileElement">
            <div class="TextInfo">
                <h1><asp:Label ID="lblNombreUsuario" runat="server" /></h1>
                <p>Correo electrónico: <asp:Label ID="lblCorreo" runat="server" /></p>

                <%--<p>Dirección: <asp:Label ID="lblDireccion" runat="server" /></p>--%>
            </div>
        </div>
        <div class="ProfileElement">
            <div>
                <h3><a href="Cesta.aspx"> cesta</a></h3>
                <h3><a href="Favoritos.aspx"> favoritos</a></h3>
                <h3><a href="Pedidos.aspx"> pedidos</a></h3>
            </div>
        </div>
    </div>
    <hr />
    <h2>OPINIONES</h2>
    <div class="OpinionList">
        <h2 class="restaurante">Nombre restaurante</h2>
        <h3 class="titulo">Excelente servicio</h3>
        <p class="contenido">La comida estaba muy rica</p>
        <p class="valoracion">Valoración: 5/5 estrellas</p>
        <p class="fecha">Publicado el 01/05/2024</p>
    </div>
    
</asp:Content>