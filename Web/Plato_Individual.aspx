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
</asp:Content>
