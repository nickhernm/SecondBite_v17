<%@ Page Title="@nombre" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Restaurante_Individual.aspx.cs" Inherits="Web.Restaurante_Individual" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Información del Restaurante</h1>
            <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblLocalidad" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblTipo" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblPuntuacion" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label><br />
            <asp:Label ID="lblPlato" runat="server" Text=""></asp:Label><br />
        </div>
    </form>
</body>
</html>

