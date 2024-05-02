<<<<<<< HEAD
﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>Your contact page.</h3>
    <address>
        One Microsoft Way<br />
        Redmond, WA 98052-6399<br />
        <abbr title="Phone">P:</abbr>
        425.555.0100
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:Support@example.com">Support@example.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:Marketing@example.com">Marketing@example.com</a>
    </address>
</asp:Content>
=======
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Contacto - SecondBite</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar superior -->
        <div class="top-navbar">
            <div class="navbar-left">
                <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Default.aspx">Inicio</asp:HyperLink>
                <asp:HyperLink ID="lnkUsuario" runat="server" Visible="false" NavigateUrl="~/PerfilUsuario.aspx">Mi Perfil</asp:HyperLink>
                <asp:HyperLink ID="lnkCesta" runat="server" Visible="false" NavigateUrl="~/Cesta.aspx">Cesta</asp:HyperLink>
            </div>
            <div class="navbar-right">
                <asp:HyperLink ID="lnkLogin" runat="server" Visible="true" NavigateUrl="~/Login.aspx">Log In</asp:HyperLink>
                <asp:HyperLink ID="lnkRegister" runat="server" Visible="true" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
            </div>
        </div>

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
    </form>
</body>
</html>
>>>>>>> BK5734575
