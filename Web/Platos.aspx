<%@ Page Title="Lista de Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.Platos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Platos.css" />
    <h2>Lista de Platos</h2>
    
    <div>
        <asp:Label ID="lblMensaje" runat="server" Text="" Visible="False" ForeColor="Red"></asp:Label>
    </div>
    
    <div class="filter-container">
        <asp:Label ID="lblFiltroAlergenos" runat="server" Text="Alérgenos: "></asp:Label>
        <asp:DropDownList ID="ddlAlergenos" runat="server">
            <asp:ListItem Value="" Text="Todos" />
            <asp:ListItem Value="soja" Text="Soja" />
            <asp:ListItem Value="pescado" Text="Pescado" />
        </asp:DropDownList>

        <asp:Label ID="lblFiltroPuntuacion" runat="server" Text="Puntuación: "></asp:Label>
        <asp:DropDownList ID="ddlPuntuacion" runat="server">
            <asp:ListItem Value="" Text="Todas" />
            <asp:ListItem Value="5" Text="5" />
            <asp:ListItem Value="4" Text="4" />
            <asp:ListItem Value="3" Text="3" />
            <asp:ListItem Value="2" Text="2" />
            <asp:ListItem Value="1" Text="1" />
        </asp:DropDownList>

        <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" />
    </div>

    <div class="dish-grid">
        <asp:Repeater ID="rptPlatos" runat="server">
            <ItemTemplate>
                <div class="dish-card">
                    <h3><%# Eval("Nombre") %></h3>
                    <p>Alérgenos: <%# Eval("Alergenos") %></p>
                    <p>Puntuación: <%# Eval("Puntuacion") %></p>
                    <asp:Button ID="btnVerDetalles" runat="server" Text="Ver Detalles" CommandArgument='<%# Eval("Id") %>' OnClick="btnVerDetalles_Click" />
                </div>
                <hr />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>