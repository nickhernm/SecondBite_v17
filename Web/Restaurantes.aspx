<%@ Page Title="RESTAURANTES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurantes.aspx.cs" Inherits="Web.Restaurantes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Restaurantes.css" />
    <h2>Restaurantes</h2>

    <div class="filter-container">
        <asp:Label ID="lblBuscar" runat="server" Text="Buscar:" />
        <asp:TextBox ID="txtBuscar" runat="server" />
        
        <asp:Label ID="lblComunidad" runat="server" Text="Comunidad:" />
        <asp:DropDownList ID="ddlComunidad" runat="server" />
        
        <asp:Label ID="lblTipo" runat="server" Text="Tipo:" />
        <asp:DropDownList ID="ddlTipo" runat="server" />
        
        <asp:Label ID="lblPuntuacion" runat="server" Text="Puntuación:" />
        <asp:DropDownList ID="ddlPuntuacion" runat="server">
            <asp:ListItem Value="">Todas</asp:ListItem>
            <asp:ListItem Value="1">1 estrella</asp:ListItem>
            <asp:ListItem Value="2">2 estrellas</asp:ListItem>
            <asp:ListItem Value="3">3 estrellas</asp:ListItem>
            <asp:ListItem Value="4">4 estrellas</asp:ListItem>
            <asp:ListItem Value="5">5 estrellas</asp:ListItem>
        </asp:DropDownList>
        
        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
    </div>
    
    <div class="restaurant-grid">
        <asp:Repeater ID="RepeaterRestaurantes" runat="server">
            <ItemTemplate>
                <div class="restaurant-card">
                    <h3><%# Eval("Nombre") %></h3>
                    <p>Localidad: <%# Eval("Localidad") %></p>
                    <p>Tipo: <%# Eval("Tipo") %></p>
                    <p>Puntuación: <%# Eval("Puntuacion") %></p>
                    <asp:Button ID="btnMostrarMenu" runat="server" Text="Mostrar Menú" CommandArgument='<%# Eval("cod") %>' OnClick="btnMostrarMenu_Click" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>