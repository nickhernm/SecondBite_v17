<%@ Page Title="Platos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Platos.aspx.cs" Inherits="Web.Platos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Menú</h2>
    <p>Aquí se muestran los 10 platos mejor valorados:</p>
    <asp:GridView ID="gvPlatosDestacados" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="Alergenos" HeaderText="Alérgenos" />
            <asp:BoundField DataField="Puntuacion" HeaderText="Puntuación" />
        </Columns>
    </asp:GridView>
</asp:Content>