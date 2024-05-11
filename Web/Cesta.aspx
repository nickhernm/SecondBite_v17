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
                <asp:BoundField DataField="Precio" HeaderText="Precio" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                <asp:TemplateField HeaderText="Eliminar">
                    <ItemTemplate>
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn-eliminar" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnVaciarCesta" runat="server" Text="Vaciar Cesta" OnClick="btnVaciarCesta_Click" CssClass="btn-vaciar" />
    </div>
</asp:Content>
