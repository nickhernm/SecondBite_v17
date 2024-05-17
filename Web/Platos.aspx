<%@ Page Title="Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.Platos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Información del Plato</h1>
        <asp:FormView ID="FormViewPlato" runat="server">
            <ItemTemplate>
                <h2><%# Eval("Nombre") %></h2>
                <p>Descripción: <%# Eval("Descripcion") %></p>
                <p>Precio: <%# Eval("Precio", "{0:C}") %></p>
                <p>Alérgenos: <%# Eval("Alergenos") %></p>
            </ItemTemplate>
        </asp:FormView>

        <h2>Comentarios y Valoraciones</h2>
        <asp:Repeater ID="RepeaterComentarios" runat="server">
            <ItemTemplate>
                <div class="comentario">
                    <p>Usuario: <%# Eval("NombreUsuario") %></p>
                    <p>Comentario: <%# Eval("Comentario") %></p>
                    <p>Puntuación: <%# Eval("Puntuacion") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <h3>Agregar Comentario y Valoración</h3>
        <div>
            <asp:Label ID="lblNombreUsuario" runat="server" Text="Nombre de Usuario:"></asp:Label>
            <asp:TextBox ID="txtNombreUsuario" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblComentario" runat="server" Text="Comentario:"></asp:Label>
            <asp:TextBox ID="txtComentario" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="lblPuntuacion" runat="server" Text="Puntuación:"></asp:Label>
            <asp:DropDownList ID="ddlPuntuacion" runat="server">
                <asp:ListItem Text="1" Value="1"></asp:ListItem>
                <asp:ListItem Text="2" Value="2"></asp:ListItem>
                <asp:ListItem Text="3" Value="3"></asp:ListItem>
                <asp:ListItem Text="4" Value="4"></asp:ListItem>
                <asp:ListItem Text="5" Value="5"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Button ID="btnAgregarComentario" runat="server" Text="Agregar Comentario" OnClick="btnAgregarComentario_Click" />
    </div>
</asp:Content>