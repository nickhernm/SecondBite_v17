<%@ Page Title="Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.Platos" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <!--<link rel="stylesheet" type="text/css" href="styles.css" /> ARREGLAR STYLE.CSS-->
    <!-- Navbar superior -->
         

    <!-- Título del menú -->
    <div class="purple-highlight">
        <h1>Menú de <asp:Literal ID="Restaurante" runat="server"></asp:Literal></h1>
    </div>

    <!-- Lista de platos -->
    <div class="platos-list">
        <asp:Repeater ID="repeaterPlatos" runat="server">
            <ItemTemplate>
                <div class="plato">
                    <asp:Image ID="imgPlato" runat="server" ImageUrl='<%# Eval("ImagenUrl") %>' AlternateText='<%# Eval("Nombre") %>' CssClass="plato-imagen" />
                    <h3><%# Eval("Nombre") %></h3>
                    <p>Precio: <asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("Precio", "{0:C}") %>'></asp:Label></p>
                    <p>Alérgenos: <asp:Label ID="lblAlergenos" runat="server" Text='<%# Eval("Alergenos") %>'></asp:Label></p>
                    <p>Puntuación: <asp:Label ID="lblPuntuacion" runat="server" Text='<%# Eval("Puntuacion") %>'></asp:Label></p>
                    <asp:Button ID="btnAnadirCesta" runat="server" Text="Añadir a cesta" OnClick="btnAnadirCesta_Click" CommandArgument='<%# Eval("PlatoId") %>' />
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

