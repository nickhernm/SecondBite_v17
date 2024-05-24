<%@ Page Title="Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Web.Pedidos" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
    <div class="card" >
        <div class="card-header row" style="display: flex; justify-content: space-between;">
            <h2 style="flex: 1;">Num_ped:<%# DataBinder.Eval(Container.DataItem, "numPedido") %></h2>
            <h2 style="flex: 1;"><%# DataBinder.Eval(Container.DataItem, "emailPedido") %></h2>
            <h2 style="flex: 1; text-align: right;"><%# DataBinder.Eval(Container.DataItem, "fechaPedido") %></h2>
        </div>
        
    <div class="card-body row">
        <asp:Repeater ID="Repeater2" datasource='<%# DataBinder.Eval(Container.DataItem, "lineasPedido") %>' runat="server">
    <ItemTemplate>
                
        <div class="card" style="position: relative">
            <div class="row" style="position: absolute; top: 0px; right: 10px; padding: 10px;">
                <asp:Button ID="Button2" runat="server" Text="Add favorite" OnClick="Delete"></asp:Button>
            </div>
            <div style="position: absolute; bottom: 0px; right: 10px; padding: 10px;">
                <asp:Button ID="Button3" runat="server" Text="Buy" OnClick="Delete"></asp:Button>
            </div>
            <div class="card-header">
                <h2>Linea: <%# DataBinder.Eval(Container.DataItem, "linea") %></h2>
                <h2>Pedido: <%# DataBinder.Eval(Container.DataItem, "pedido") %></h2>
                <h2>Importe: <%# DataBinder.Eval(Container.DataItem, "importe") %></h2>
                <h2>Cantidad: <%# DataBinder.Eval(Container.DataItem, "cantidad") %></h2>

            </div>
            <div class="card-body row">
                <div style="width: 300px;float: left; position: relative; height:200px">
                <p><asp:Label ID="txtContent" runat="server"></asp:Label></p>
                    <div style="position: absolute; bottom: 0px;">
                        <h2>Id: <%# DataBinder.Eval(Container.DataItem, "plato.Id") %></h2>
                        <h2>Nombre: <%# DataBinder.Eval(Container.DataItem, "plato.Nombre") %></h2>
                        <h2>Alergenos: <%# DataBinder.Eval(Container.DataItem, "plato.Alergenos") %></h2>
                        <h2>Puntuacion: <%# DataBinder.Eval(Container.DataItem, "plato.Puntuacion") %>/5</h2>
                            
                      
                    </div>
                </div>
                </div>
        </div>
        </ItemTemplate>
    </asp:Repeater>

    </div>
    <div class="card-header row" style="display: flex; justify-content: space-between;">
        <h2>Enviado</h2>
    </div>
    </div>
            </ItemTemplate>
    </asp:Repeater>

    <style>
        .card {
            border: 1px solid #ddd;
            border-radius: 8px;
            overflow: hidden;
            margin-bottom: 20px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            background-color: #fff;
        }

        .card-header {
            padding: 20px;
            background-color: #f3f4f6;
            border-bottom: 1px solid #ddd;
        }

        .card-header h2 {
            margin: 0;
            color: #333;
        }

        .card-body {
            padding: 20px;
        }

        .card-body p {
            margin: 0;
            color: #666;
        }
    </style>
</asp:Content>