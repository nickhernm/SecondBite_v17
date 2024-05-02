<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cesta.aspx.cs" Inherits="Web.Cesta" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Cesta de Compra</title>
    <link rel="stylesheet" type="text/css" href="styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Cesta de Compra</h1>
            <asp:GridView ID="gvCesta" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Precio" HeaderText="Precio" />
                    <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" />
                    <asp:TemplateField HeaderText="Eliminar">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Container.DataItemIndex %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnVaciarCesta" runat="server" Text="Vaciar Cesta" OnClick="btnVaciarCesta_Click" />
        </div>
    </form>
</body>
</html>
