<%@ Page Title="Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.Platos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Lista de Platos</h2>
    <asp:Repeater ID="rptPlatos" runat="server">
        <ItemTemplate>
            <div class="plato-item">
                <h3><%# Eval("Nombre") %></h3>
                <p>Alérgenos: <%# Eval("Alergenos") %></p>
                <p>Puntuación: <%# Eval("Puntuacion") %></p>
                <asp:Button ID="btnVerDetalles" runat="server" Text="Ver Detalles" CommandName="VerDetalles" CommandArgument='<%# Eval("Id") %>' />
            </div>
            <hr />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>