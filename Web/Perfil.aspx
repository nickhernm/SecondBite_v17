<%@ Page Title="PERFIL" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="Web.Perfil" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Perfil.css" rel="stylesheet" />
    <div class="ProfileContainer">
        <div class="ProfileElement ProfilePic">
            <a href="#">
                <img src="/Images/kawaii.png" alt="Foto de perfil">
            </a>
        </div>
        <div class="ProfileElement TextInfo">
            <h1><asp:Label ID="lblNombreUsuario" runat="server" Text="Maria Fads" /></h1>
            <p class="correo">Correo: <%# Eval("Correo") %> </p>         
            <p class="nombre">Nombre: <%# Eval("Nombre") %> </p>
            <p class="telefono">Telefono: <%# Eval("Telefono") %> </p>
        </div>
        <div class="ProfileElement ProfileActions">
            <a href="Cesta.aspx" class="btn">Cesta</a>
            <a href="Favoritos.aspx" class="btn">Favoritos</a>
            <a href="Pedidos.aspx" class="btn">Pedidos</a>
        </div>
    </div>
    <hr />
    <h2>OPINIONES</h2>
    <asp:Label ID="lblMensajeOpiniones" runat="server" Text="" Visible="False" />
    <asp:Repeater ID="rptOpiniones" runat="server">
        <ItemTemplate>
            <div class="OpinionList">
                <h3 class="titulo"><%# Eval("Descripcion") %></h3>
                <p class="valoracion">Valoración: <%# Eval("Valoracion") %>/5 estrellas</p>
            </div>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>