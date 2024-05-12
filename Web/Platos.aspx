<%@ Page Title="Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.Platos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<link rel="stylesheet" type="text/css" href="styles.css" /> ARREGLAR STYLE.CSS-->

    <!-- Navbar superior -->

    <!-- Título del menú -->
    <div class="purple-highlight">
        <h1>Menú de <asp:Literal ID="LiteralRestaurante" runat="server"></asp:Literal></h1>
    </div>

    <!-- Barra de búsqueda y filtros -->
    <div class="search-bar">
        <asp:TextBox ID="TxtBuscarPlato" runat="server" Placeholder="Buscar plato..."></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />

        <!-- Dropdown para Alérgenos -->
        <label for="DdlAlergenos">Alérgenos:</label>
        <asp:DropDownList ID="DdlAlergenos" runat="server">
            <asp:ListItem Text="Todos los alérgenos" Value="" />
            <asp:ListItem Text="Mariscos" Value="masricos" />
            <asp:ListItem Text="Pescado" Value="pescado" />
            <asp:ListItem Text="Soja" Value="soja" />
        </asp:DropDownList>

        <!-- Dropdown para Puntuación -->
        <label for="DdlPuntuacion">Puntuación:</label>
        <asp:DropDownList ID="DdlPuntuacion" runat="server">
            <asp:ListItem Text="Todas las puntuaciones" Value="" />
            <asp:ListItem Text="1 estrella" Value="1" />
            <asp:ListItem Text="2 estrellas" Value="2" />
            <asp:ListItem Text="3 estrellas" Value="3" />
            <asp:ListItem Text="4 estrellas" Value="4" />
            <asp:ListItem Text="5 estrellas" Value="5" />
        </asp:DropDownList>

        <!-- Botón para limpiar filtros -->
        <asp:Button ID="BtnLimpiarFiltros" runat="server" Text="Limpiar filtros" OnClick="BtnLimpiarFiltros_Click" />
    </div>

    <!-- Lista de platos -->
    <div class="platos-list">
        <asp:Repeater ID="RepeaterPlatos" runat="server">
            <ItemTemplate>
                <div class="plato">
                    <h3><%# Eval("nombre") %></h3>
                    <p>Alérgenos: <%# Eval("alergenos") %></p>
                    <p>Puntuación: <%# Eval("puntuacion") %></p>
                    <asp:Button ID="BtnAnadirCesta" runat="server" Text="Añadir a cesta" OnClick="BtnAnadirCesta_Click" CommandArgument='<%# Eval("id") %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>