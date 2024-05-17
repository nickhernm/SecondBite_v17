
<%@ Page Title="Registrar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Web.Registrar" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row" style="display: flex; justify-content: space-between; margin-top: 100px;">
        <div class="card" style="position: relative; width: 400px;">
            <div class="row" style="display: flex; justify-content: space-between;">
                <h2><%: Title %>.</h2>
            </div>
        <div class="card-body" style="display: flex;flex-direction: column;">
            <div class="centerobject"><asp:TextBox ID="TextBox3" runat="server" placeholder="Email"></asp:TextBox> </div>
                    <div class="centerobject"><asp:TextBox ID="TextBox1" runat="server" placeholder="Usuario"></asp:TextBox> </div>
                    <div class="centerobject"><asp:TextBox ID="TextBox2" runat="server" placeholder="Contraseña"></asp:TextBox> </div>
                    <div class="centerobject"><asp:Button ID="Button3" runat="server" Text="Create Account" OnClick="RegistrarUsu"></asp:Button> </div>
                    <div class="centerobject"><asp:Label ID="lblMessage" runat="server" Text="" style="color:red;"></asp:Label> </div>
                    <div class="centerobject">Already have an account? <a runat = "server" href="~/Login">Login</a> </div>
                
        </div>
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
        .centerobject{
            display: flex;
              align-items: center;
              justify-content: center;
              margin-bottom:10px;
        }
    </style>
</asp:Content>