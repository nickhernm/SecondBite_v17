<%@ Page Title="Pedidos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="Web.Pedidos" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>

    <div class="card" >
        <div class="card-header row" style="display: flex; justify-content: space-between;">
            <h2 style="flex: 1;"><asp:Label ID="txtOrder" runat="server"></asp:Label></h2>
            <h2 style="flex: 1; text-align: right;"><asp:Label ID="txtPriceTotal" runat="server"></asp:Label></h2>
        </div>
    <div class="card-body row">
        <div class="card" style="position: relative">
            <div class="row" style="position: absolute; top: 0px; right: 10px; padding: 10px;">
                <asp:Button ID="Button2" runat="server" Text="Add favorite" OnClick="Delete"></asp:Button>
            </div>
            <div style="position: absolute; bottom: 0px; right: 10px; padding: 10px;">
                <asp:Button ID="Button3" runat="server" Text="Buy" OnClick="Delete"></asp:Button>
            </div>
            <div class="card-header">
                <h2><asp:Label ID="txtTitle" runat="server"></asp:Label></h2>
            </div>
            <div class="card-body row">
                <div style="width: 300px;float: left; position: relative; height:200px">
                <p><asp:Label ID="txtContent" runat="server"></asp:Label></p>
                    <div style="position: absolute; bottom: 0px;">
                        <h3 ><asp:Label ID="txtPrice" runat="server"></asp:Label> </h3>
                        <div >Unidades: 2</div>
                    </div>
                </div>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/sandwich.jpg"  AlternateText="Image" Width="200px" Height="200px" style="float: right;"></asp:Image>
            </div>
        </div>
    </div>
    <div class="card-header row" style="display: flex; justify-content: space-between;">
        <h2>Enviado</h2>
    </div>
    </div>


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
