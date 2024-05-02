<%@ Master Language="C#" AutoEventWireup="true" CodeBehind="Platos.Master.cs" Inherits="Web.Site2" %>

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
                <asp:HyperLink ID="lnkHome" runat="server" NavigateUrl="~/Default.aspx">Inicio</asp:HyperLink>
                <asp:HyperLink ID="lnkUsuario" runat="server" Visible="false" NavigateUrl="~/PerfilUsuario.aspx">Mi Perfil</asp:HyperLink>
                <asp:HyperLink ID="lnkCesta" runat="server" Visible="false" NavigateUrl="~/Cesta.aspx">Cesta</asp:HyperLink>
            </div>
            <div class="navbar-right">
                <asp:HyperLink ID="lnkLogin" runat="server" Visible="true" NavigateUrl="~/Login.aspx">Log In</asp:HyperLink>
                <asp:HyperLink ID="lnkRegister" runat="server" Visible="true" NavigateUrl="~/Register.aspx">Register</asp:HyperLink>
            </div>
        </div>

        <!-- Título del menú -->
        <div class="purple-highlight">
            <h1>Menú de <asp:Literal ID="litNombreRestaurante" runat="server"></asp:Literal></h1>
        </div>

        <!-- Lista de platos -->
        <div class="platos-list">
            <asp:Repeater ID="repeaterPlatos" runat="server">
                <ItemTemplate>
                    <div class="plato">
                        <asp:Image ID="imgPlato" runat="server" ImageUrl='<%# Eval("ImagenUrl") %>' AlternateText='<%# Eval("Nombre") %>' CssClass="plato-imagen" />
                        <h3><%# Eval("Nombre") %></h3>
                        <p>Precio: <%# Eval("Precio", "{0:C}") %></p>
                        <p>Alérgenos: <%# Eval("Alergenos") %></p>
                        <p>Puntuación: <%# Eval("Puntuacion") %></p>
                        <asp:Button ID="btnAnadirCesta" runat="server" Text="Añadir a cesta" OnClick="btnAnadirCesta_Click" CommandArgument='<%# Eval("PlatoId") %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>
