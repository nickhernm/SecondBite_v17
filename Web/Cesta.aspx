<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cesta.aspx.cs" Inherits="Web.Cesta" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cesta de Compra</title>
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

        <!-- Franja morada destacada -->
        <div class="purple-highlight">
            <h1>Cesta de Compra</h1>
        </div>

        <div class="container">
            <asp:GridView ID="gvCesta" runat="server" AutoGenerateColumns="False" CssClass="cesta-grid">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-eliminar" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnVaciarCesta" runat="server" Text="Vaciar Cesta" OnClick="btnVaciarCesta_Click" CssClass="btn-vaciar" />
        </div>
    </form>
</body>
</html>
