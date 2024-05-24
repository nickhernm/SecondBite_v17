<%@ Page Title="Favoritos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="Web.Favoritos" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

     <asp:Repeater ID="Repeater1" runat="server">
     <ItemTemplate>
        <div class="card" style="position: relative">
            <div class="row" style="position: absolute; top: 0px; right: 10px; padding: 10px;">
                <asp:Button ID="Button2" runat="server" Text="Remove favorite" OnClick="Delete"></asp:Button>
            </div>
            <div style="position: absolute; bottom: 0px; right: 10px; padding: 10px;">
                <asp:Button ID="Button3" runat="server" Text="Buy" OnClick="Delete"></asp:Button>
            </div>
            <div class="card-header">
                <h2>Nombre: <%# DataBinder.Eval(Container.DataItem, "Nombre") %></h2>
            </div>
            <div class="card-body row">
                <div style="width: 300px;float: left; position: relative; height:100px">
                <p><asp:Label ID="txtContent" runat="server"></asp:Label></p>
                    <div style="position: absolute; bottom: 0px;">
                        <h3 >Alergenos: <%# DataBinder.Eval(Container.DataItem, "Alergenos") %></h3>
                        <h3 >Puntuacion: <%# DataBinder.Eval(Container.DataItem, "Puntuacion") %>/5</h3>
                    </div>
                </div>
             </div>
        </div>
             </ItemTemplate>
</asp:Repeater>

    <style>
        /* CSS styles for card */
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