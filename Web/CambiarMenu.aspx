<%@ Page Title="Cambiar Menú" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarMenu.aspx.cs" Inherits="Web.CambiarMenu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Cambiar Menú</h2>
    
    <link rel="stylesheet" type="text/css" href="Menu.css" />
    <asp:GridView ID="gvPlatos" runat="server" AutoGenerateColumns="False" OnRowCommand="gvPlatos_RowCommand" CssClass="gvPlatos" DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Alergenos" HeaderText="Alérgenos" />
            <asp:TemplateField>
                <ItemTemplate>
                    <div class="btn-cell">
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    
    <h3>Agregar/Editar Plato</h3>
    <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
    
    <asp:Label ID="lblAlergenos" runat="server" Text="Alérgenos:"></asp:Label>
    <asp:TextBox ID="txtAlergenos" runat="server"></asp:TextBox>
 
    
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
</asp:Content>