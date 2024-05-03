<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Restaurantes.aspx.cs" Inherits="Web.Restaurantes" %>

<!DOCTYPE html>

<html>

<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Restaurantes</title>
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
                <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="~/Login.aspx">Log In</asp:HyperLink>
                <asp:HyperLink ID="lnkRegister" runat="server" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
            </div>
        </div>

        <!-- Franja morada destacada -->
        <div class="purple-highlight">
            <h1>Restaurantes</h1>
        </div>

        <!-- Buscador -->
        <div class="search-bar">
            <asp:TextBox ID="txtBuscarRestaurante" runat="server" Placeholder="Buscar restaurante..."></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>

        <div class="restaurant-list">
            <asp:Repeater ID="repeaterRestaurantes" runat="server">
                <ItemTemplate>
                    <div class="restaurante">
                        <h3><%# Eval("Nombre") %></h3>
                        <p>Localidad: <%# Eval("Localidad") %></p>
                        <p>Tipo: <%# Eval("Tipo") %></p>
                        <p>Puntuación: <%# Eval("Puntuacion") %></p>
                        <p><%# Eval("Descripcion") %></p>
                        <asp:HyperLink ID="lnkPlatos" runat="server" NavigateUrl='<%# "~/MenuRestaurante.aspx?id=" + Eval("RestauranteId") %>'>Ver Menú</asp:HyperLink>
                    </div>
                    <hr class="restaurante-separator" />
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>

</html>
