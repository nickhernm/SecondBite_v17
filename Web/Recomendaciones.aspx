<%@ Page Title="RECOMENDACIONES" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Recomendaciones.aspx.cs" Inherits="Web.Recomendaciones" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1> RECOMENDACIONES</h1>
    <div class="card row">
        <div style="width: 300px;float: left; position: relative; height:200px">
            <p><asp:Label ID="txtContent" runat="server"></asp:Label></p>
            <div style="position: absolute; bottom: 0px;">
                <h3 ><asp:Label ID="txtPrice" runat="server"></asp:Label> </h3>
            </div>
        </div>
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/sandwich.jpg"  AlternateText="Image" Width="200px" Height="200px" style="float: right;"></asp:Image>
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