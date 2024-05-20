<%@ Page Title="Menu_Individual" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu_Individual.aspx.cs" Inherits="Web.Menu_Individual" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Menú del Restaurante</h2>
    
    <asp:GridView ID="gvPlatos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Alergenos" HeaderText="Alérgenos" />
            <asp:BoundField DataField="Puntuacion" HeaderText="Puntuación" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnAnadirCesta" runat="server" Text="Añadir a la cesta" CommandArgument='<%# Eval("Id") %>' OnClick="btnAnadirCesta_Click" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnVerDetalles" runat="server" Text="Ver detalles" CommandArgument='<%# Eval("Id") %>' OnClick="btnVerDetalles_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>