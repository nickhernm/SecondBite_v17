<%@ Page Title="Menu_Individual" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_Individual.aspx.cs" Inherits="Web.Menu_Individual" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form id="form1" runat="server">
        <div class="container">
            <h1>Menú del Restaurante @RestauranteNombre</h1>
            <asp:Repeater ID="RepeaterPlatos" runat="server">
                <HeaderTemplate>
                    <ul class="menu-list">
                </HeaderTemplate>
                <ItemTemplate>
                    <li class="menu-item">
                        <div class="menu-item-header">
                            <h3><%# Eval("Nombre") %></h3>
                            <span class="menu-item-price"><%# Eval("Precio", "{0:C}") %></span>
                        </div>
                        <p class="menu-item-description"><%# Eval("Descripcion") %></p>
                        <p class="menu-item-alergenos">Alérgenos: <%# Eval("Alergenos") %></p>
                        <asp:Button ID="BtnAnadirCesta" runat="server" Text="Añadir a cesta" CommandArgument='<%# Eval("PlatoId") %>' OnClick="BtnAnadirCesta_Click" CssClass="btn-add-cart" />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </form>
</asp:Content>
