<%@ Page Title="CONTACTO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--<link rel="stylesheet" type="text/css" href="styles.css" />-->
    <!-- Título de la página -->
    <div class="purple-highlight">
        <h1>Contacto - SecondBite</h1>
    </div>

    <!-- Información de contacto -->
    <div class="contact-info">
        <h2>Información de Contacto</h2>
        <p>Nombre de la Empresa: SecondBite</p>
        <p>Teléfono: 678-456-329</p>
        <p>Email: <a href="mailto:SecondBite@gmail.com">SecondBite@gmail.com</a></p>
        <p>Dirección: Av. Hada, 12, Alicante, España</p>
    </div>

    <!-- Formulario de contacto -->
    <div class="contact-form">
        <h2>Envíanos un mensaje</h2>
        <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
        <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:"></asp:Label>
        <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblMensaje" runat="server" Text="Mensaje:"></asp:Label>
        <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
        <br />
        <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
    </div>

    <!-- Redes Sociales -->
    <div class="social-media">
        <h2>Síguenos en redes sociales</h2>
            <ul>
            <li><a href="https://www.instagram.com/Second_Bite" target="_blank">Instagram: Second_Bite</a></li>
            <li><a href="https://twitter.com/SecondBite" target="_blank">Twitter: SecondBite</a></li>
            <li><a href="https://www.facebook.com/SecondBite" target="_blank">Facebook: SecondBite</a></li>
        </ul>
    </div>
</asp:Content>