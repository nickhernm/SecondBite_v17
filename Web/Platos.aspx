<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.WebForm1" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Menú del Restaurante</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <!-- Navbar superior -->
         <div class="top-navbar">
            <div class="navbar-left">
                <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Default.aspx" Text="Inicio"></asp:HyperLink>
                <asp:HyperLink ID="lnkUsuario" runat="server" Visible="false" NavigateUrl="~/PerfilUsuario.aspx" Text="Mi Perfil"></asp:HyperLink>
                <asp:HyperLink ID="lnkCesta" runat="server" Visible="false" NavigateUrl="~/Cesta.aspx" Text="Cesta"></asp:HyperLink>
            </div>
            <div class="navbar-right">
                <asp:HyperLink ID="lnkLogin" runat="server" Visible="true" NavigateUrl="~/Login.aspx" Text="Log In"></asp:HyperLink>
                <asp:HyperLink ID="lnkRegister" runat="server" Visible="true" NavigateUrl="~/Register.aspx" Text="Register"></asp:HyperLink>
                <asp:HyperLink ID="HyperLink1" runat="server" Visible="false" NavigateUrl="~/Cesta.aspx" Text="Cesta"></asp:HyperLink>
            </div>
        </div>

        <!-- Título del menú -->
        <div class="purple-highlight">
            <h1>Menú de <asp:Literal ID="Restaurante" runat="server"></asp:Literal></h1>
        </div>

        <!-- Lista de platos -->
        <div class="platos-list">
            <asp:Repeater ID="repeaterPlatos" runat="server">
                <ItemTemplate>
                    <div class="plato">
                        <asp:Image ID="imgPlato" runat="server" ImageUrl='<%# Eval("ImagenUrl") %>' AlternateText='<%# Eval("Nombre") %>' CssClass="plato-imagen" />
                        <h3><%# Eval("Nombre") %></h3>
                        <p>Precio: <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("Precio", "{0:C}") %>'></asp:Label></p>
                        <p>Alérgenos: <asp:Label ID="lblAlergenos" runat="server" Text='<%# Eval("Alergenos") %>'></asp:Label></p>
                        <p>Puntuación: <asp:Label ID="lblPuntuacion" runat="server" Text='<%# Eval("Puntuacion") %>'></asp:Label></p>
                        <asp:Button ID="btnAnadirCesta" runat="server" Text="Añadir a cesta" OnClick="btnAnadirCesta_Click" CommandArgument='<%# Eval("PlatoId") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
