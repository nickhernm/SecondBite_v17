<%@ Page Title="RESTAURANTES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurantes.aspx.cs" Inherits="Web.Restaurantes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <!--<link rel="stylesheet" type="text/css" href="styles.css" />-->


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

</asp:Content>