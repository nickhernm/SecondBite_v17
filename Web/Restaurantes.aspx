<%@ Page Title="RESTAURANTES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurantes.aspx.cs" Inherits="Web.Restaurantes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!-- Franja morada destacada -->
    <div class="purple-highlight">
        <h1>Restaurantes</h1>
    </div>

    <!-- Barra de búsqueda y filtros -->
    <div class="search-bar">
        <asp:TextBox ID="TxtBuscarRestaurante" runat="server" Placeholder="Buscar restaurante..."></asp:TextBox>
        <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />

        <!-- Dropdown para Comunidades -->
        <label for="DdlComunidades">Comunidad:</label>
        <asp:DropDownList ID="DdlComunidades" runat="server">
            <asp:ListItem Text="Todas las comunidades" Value="" />
        </asp:DropDownList>

        <!-- Dropdown para Tipo -->
        <label for="DdlTipo">Tipo:</label>
        <asp:DropDownList ID="DdlTipo" runat="server">
            <asp:ListItem Text="Todos los tipos" Value="" />
            <asp:ListItem Text="Chino" Value="Chino" />
            <asp:ListItem Text="Indio" Value="Indio" />
        </asp:DropDownList>

        <!-- Dropdown para Puntuación -->
        <label for="DdlPuntuacion">Puntuación:</label>
        <asp:DropDownList ID="DdlPuntuacion" runat="server">
            <asp:ListItem Text="Todas las puntuaciones" Value="" />
            <asp:ListItem Text="1 estrella" Value="1" />
            <asp:ListItem Text="2 estrellas" Value="2" />
        </asp:DropDownList>

        <!-- Botón para limpiar filtros -->
        <asp:Button ID="BtnLimpiarFiltros" runat="server" Text="Limpiar filtros" OnClick="BtnLimpiarFiltros_Click" />
    </div>

    <!-- Lista de restaurantes -->
    <div class="restaurant-list">
        <asp:Repeater ID="RepeaterRestaurantes" runat="server">
            <ItemTemplate>
                <div>
            <p>
                Nombre: &nbsp;<asp:label ID="text_Nombre" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:label>
            </p>
            <p>
                Localidad: &nbsp;<asp:label ID="text_Punt" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:label>
            </p>
             <p>
                Tipo: &nbsp;<asp:label ID="text_tipo" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:label>
            </p>
            <p>
                Puntuación: &nbsp;<asp:label ID="text_puntuacion" runat="server" Height="20px" style="margin-top: 5px; margin-left: 25px;" Width="200px"></asp:label>
            </p>
        </div>
                <hr class="restaurante-separator" />
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>