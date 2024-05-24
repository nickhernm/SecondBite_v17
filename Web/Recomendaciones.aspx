<%@ Page Title="RECOMENDACIONES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recomendaciones.aspx.cs" Inherits="Web.Recomendaciones" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="stylesheet" type="text/css" href="Recomendaciones.css" />
    <h1>RECOMENDACIONES</h1>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <h2>Restaurantes Recomendados</h2>
                <asp:Repeater ID="rptRestaurantes" runat="server">
                    <ItemTemplate>
                        <div class="card">
                            <div class="card-body">
                                <h3><%# Eval("Nombre") %></h3>
                                <p>Localidad: <%# Eval("Localidad") %></p>
                                <p>Tipo: <%# Eval("Tipo") %></p>
                                <p>Puntuación: <%# Eval("Puntuacion") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="col-md-6">
                <h2>Platos Recomendados</h2>
                <asp:Repeater ID="rptPlatos" runat="server">
                    <ItemTemplate>
                        <div class="card">
                            <div class="card-body">
                                <h3><%# Eval("Nombre") %></h3>
                                <p>Alérgenos: <%# Eval("Alergenos") %></p>
                                <p>Puntuación: <%# Eval("Puntuacion") %></p>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
