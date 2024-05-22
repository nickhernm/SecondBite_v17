<%@ Page Title="Cesta" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cesta.aspx.cs" Inherits="Web.Cesta" %>


    
   
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<link rel="stylesheet" type="text/css" href="styles.css" />-->
    <!-- Franja morada destacada -->
    <div class="purple-highlight">
        <h1>Cesta de Compra</h1>
    </div>

    <div class="container">
        <asp:GridView ID="gvCesta" runat="server" AutoGenerateColumns="False" CssClass="cesta-grid">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" HtmlEncode="false" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:TemplateField HeaderText="Cantidad">
        <ItemTemplate>
            <asp:Button ID="btnDisminuirCantidad" runat="server" Text="-" CommandName="DisminuirCantidad" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-disminuir" />
            <asp:Label ID="lblCantidad" runat="server" Text='<%# Eval("Cantidad") %>'></asp:Label>
            <asp:Button ID="btnAumentarCantidad" runat="server" Text="+" CommandName="AumentarCantidad" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-aumentar" />
        </ItemTemplate>
    </asp:TemplateField>
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="lblMensajeCestaVacia" runat="server" Visible="false" Text="La cesta está vacía." CssClass="mensaje-cesta-vacia"></asp:Label>

        <asp:Button ID="btnVaciarCesta" runat="server" Text="Vaciar Cesta" OnClick="btnVaciarCesta_Click" CssClass="btn-vaciar" />
            <h2>Precio Total</h2>
        <div>
            <asp:Label ID="lblTotalEuros" runat="server" Text=""></asp:Label>
        </div>
        <asp:Button ID="btnPasarAPagar" runat="server" Text="Pasar a Pagar" CssClass="btn-pasar-pagar" OnClick="btnPasarAPagar_Click" />
    </div>
</asp:Content>
