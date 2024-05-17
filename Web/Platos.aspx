<%@ Page Title="Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.Platos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Detalles del Plato</h2>
    
    <asp:FormView ID="fvPlato" runat="server">
        <ItemTemplate>
            <h3><%# Eval("Nombre") %></h3>
            <p>Alérgenos: <%# Eval("Alergenos") %></p>
            <p>Puntuación: <%# Eval("Puntuacion") %></p>
        </ItemTemplate>
    </asp:FormView>
    
    <h3>Opiniones</h3>
    <asp:Repeater ID="rptOpiniones" runat="server">
        <ItemTemplate>
            <div class="opinion">
                <p>Usuario: <%# Eval("Usuario") %></p>
                <p>Opinión: <%# Eval("Descripcion") %></p>
                <p>Valoración: <%# Eval("Valoracion") %></p>
            </div>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
    
    <h3>Agregar Comentario</h3>
    <asp:Label ID="lblUsuario" runat="server" Text="Usuario:"></asp:Label>
    <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
    
    <asp:Label ID="lblComentario" runat="server" Text="Comentario:"></asp:Label>
    <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine"></asp:TextBox>
    
    <asp:Label ID="lblPuntuacion" runat="server" Text="Puntuación:"></asp:Label>
    <asp:DropDownList ID="ddlPuntuacion" runat="server">
        <asp:ListItem Value="1">1</asp:ListItem>
        <asp:ListItem Value="2">2</asp:ListItem>
        <asp:ListItem Value="3">3</asp:ListItem>
        <asp:ListItem Value="4">4</asp:ListItem>
        <asp:ListItem Value="5">5</asp:ListItem>
    </asp:DropDownList>
    
    <asp:Button ID="btnAgregarComentario" runat="server" Text="Agregar Comentario" OnClick="btnAgregarComentario_Click" />
</asp:Content>