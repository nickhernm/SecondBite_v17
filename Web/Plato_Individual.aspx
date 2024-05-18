<%@ Page Title="Plato_Individual" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Plato_Individual.aspx.cs" Inherits="Web.Plato_Individual" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Detalles del Plato</h2>
    
    <asp:FormView ID="fvPlato" runat="server">
        <ItemTemplate>
            <h3><%# Eval("Nombre") %></h3>
            <p>Alérgenos: <%# Eval("Alergenos") %></p>
            <p>Puntuación: <%# Eval("Puntuacion") %></p>
        </ItemTemplate>
    </asp:FormView>
    
    <h3>Valoraciones</h3>
    <asp:GridView ID="gvValoraciones" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
            <asp:BoundField DataField="Puntuacion" HeaderText="Puntuación" />
            <asp:BoundField DataField="Comentario" HeaderText="Comentario" />
        </Columns>
    </asp:GridView>
    
    <h3>Agregar Valoración</h3>
    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    
    <asp:Label ID="lblPuntuacion" runat="server" Text="Puntuación:"></asp:Label>
    <asp:DropDownList ID="ddlPuntuacion" runat="server">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
        <asp:ListItem Value="5">5</asp:ListItem>
    </asp:DropDownList>
    
    <asp:Label ID="lblComentario" runat="server" Text="Comentario:"></asp:Label>
    <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine"></asp:TextBox>
    
    <asp:Button ID="btnAgregarValoracion" runat="server" Text="Agregar Valoración" OnClick="btnAgregarValoracion_Click" />
</asp:Content>
