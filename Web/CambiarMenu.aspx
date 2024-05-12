<%@ Page Title="Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.Platos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

        <!-- Contenido principal -->
        <div class="container">
            <h1>Cambiar Menú</h1>
            
            <!-- Menú Actual -->
            <div class="menu-section">
                <h2>Menú Actual</h2>
                <asp:GridView ID="gridMenuActual" runat="server" CssClass="grid-view">
                    <!-- Columnas de la tabla -->
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre del Plato" />
                        <asp:BoundField DataField="Alergenos" HeaderText="Alergenos" />
                        <asp:BoundField DataField="Puntuacion" HeaderText="Puntuacion" />
                    </Columns>
                </asp:GridView>
            </div>
            
            <!-- Modificar Menú -->
            <div class="menu-section">
                <h2>Modificar Menú</h2>
                <div class="form-group">
                    <asp:Label ID="lblNombrePlato" runat="server" AssociatedControlID="txtNombrePlato" Text="Nombre del Plato"></asp:Label>
                    <asp:TextBox ID="txtNombrePlato" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblAlergenos" runat="server" AssociatedControlID="ddlAlergenos" Text="Alergenos"></asp:Label>
                    <asp:DropDownList ID="ddlAlergenos" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Masricos" Value="Masricos"></asp:ListItem>
                        <asp:ListItem Text="Pescado" Value="Pescado"></asp:ListItem>
                        <asp:ListItem Text="Soja" Value="Soja"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <asp:Label ID="lblPuntuacion" runat="server" AssociatedControlID="txtPuntuacion" Text="Puntuacion"></asp:Label>
                    <asp:TextBox ID="txtPuntuacion" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <asp:Button ID="btnAgregarPlato" runat="server" Text="Agregar Plato" OnClick="btnAgregarPlato_Click" CssClass="btn btn-primary" />
            </div>
        </div>
</asp:Content>

