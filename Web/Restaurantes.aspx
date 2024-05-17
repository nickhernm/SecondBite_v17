<%@ Page Title="RESTAURANTES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurantes.aspx.cs" Inherits="Web.Restaurantes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Restaurantes</h2>
    
    <div>
        <asp:Label ID="lblBuscar" runat="server" Text="Buscar:"></asp:Label>
        <asp:TextBox ID="txtBuscar" runat="server"></asp:TextBox>
        
        <asp:Label ID="lblComunidad" runat="server" Text="Comunidad:"></asp:Label>
        <asp:DropDownList ID="ddlComunidad" runat="server"></asp:DropDownList>
        
        <asp:Label ID="lblTipo" runat="server" Text="Tipo:"></asp:Label>
        <asp:DropDownList ID="ddlTipo" runat="server"></asp:DropDownList>
        
        <asp:Label ID="lblPuntuacion" runat="server" Text="Puntuación:"></asp:Label>
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
    
    <asp:GridView ID="gvRestaurantes" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
            <asp:BoundField DataField="Tipo" HeaderText="Tipo" />
            <asp:BoundField DataField="Puntuacion" HeaderText="Puntuación" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnVerDetalles" runat="server" Text="Ver Detalles" CommandArgument='<%# Eval("Id") %>' OnClick="btnVerDetalles_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>