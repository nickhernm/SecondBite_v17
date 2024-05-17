<%@ Page Title="Cambiar Menú" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambiarMenu.aspx.cs" Inherits="Web.CambiarMenu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h2>Cambiar Menú</h2>
        
        <asp:GridView ID="gvPlatos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped" OnRowCommand="gvPlatos_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" />
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="Precio" HeaderText="Precio" />
                <asp:BoundField DataField="Calorias" HeaderText="Calorías" />
                <asp:BoundField DataField="Categoria" HeaderText="Categoría" />
                <asp:BoundField DataField="Alergenos" HeaderText="Alérgenos" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnEditar" runat="server" Text="Editar" CommandName="Editar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary btn-sm" />
                        <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger btn-sm" OnClientClick="return confirm('¿Estás seguro de que deseas eliminar este plato?');" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        
        <hr />
        
        <h3><asp:Literal ID="ltlTituloAccion" runat="server" /></h3>
        
        <div class="form-group">
            <label for="txtNombrePlato">Nombre del Plato:</label>
            <asp:TextBox ID="txtNombrePlato" runat="server" CssClass="form-control" />
        </div>
        
        <div class="form-group">
            <label for="txtDescripcion">Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
        </div>
        
        <div class="form-group">
            <label for="txtPrecio">Precio:</label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" />
        </div>
        
        <div class="form-group">
            <label for="txtCalorias">Calorías:</label>
            <asp:TextBox ID="txtCalorias" runat="server" CssClass="form-control" />
        </div>
        
        <div class="form-group">
            <label for="ddlCategoria">Categoría:</label>
            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control">
                <asp:ListItem Text="Entradas" Value="Entradas" />
                <asp:ListItem Text="Platos Principales" Value="Platos Principales" />
                <asp:ListItem Text="Postres" Value="Postres" />
                <asp:ListItem Text="Bebidas" Value="Bebidas" />
            </asp:DropDownList>
        </div>
        
        <div class="form-group">
            <label for="cblAlergenos">Alérgenos:</label>
            <asp:CheckBoxList ID="cblAlergenos" runat="server" CssClass="form-control">
                <asp:ListItem Text="Gluten" Value="Gluten" />
                <asp:ListItem Text="Lácteos" Value="Lácteos" />
                <asp:ListItem Text="Mariscos" Value="Mariscos" />
                <asp:ListItem Text="Frutos Secos" Value="Frutos Secos" />
                <asp:ListItem Text="Huevos" Value="Huevos" />
            </asp:CheckBoxList>
        </div>
        
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-default" />
    </div>
</asp:Content>