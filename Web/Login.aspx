<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="display: flex; justify-content: space-between; margin-top: 100px;">
        <div class="card" style="position: relative; width: 400px;">
            <div class="row" style="display: flex; justify-content: space-between;">
                <h2><%: Title %></h2>
            </div>
            <div class="card-body" style="display: flex; flex-direction: column;">
                <div class="centerobject">
                    <asp:TextBox ID="txtUsuario" runat="server" placeholder="Usuario"></asp:TextBox>
                </div>
                <div class="centerobject">
                    <asp:TextBox ID="txtContrasena" runat="server" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                    <asp:CheckBox ID="cbxMostrarContrasena" runat="server" Text="Mostrar contraseña" AutoPostBack="True" OnCheckedChanged="cbxMostrarContrasena_CheckedChanged" />
                </div>
                <div class="centerobject">
                    <asp:Label ID="lblFuerzaContrasena" runat="server" Text=""></asp:Label>
                </div>
                <div class="centerobject">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="LoginUsu"></asp:Button>
                </div>
                <div class="centerobject">
                    <asp:Label ID="lblMessage" runat="server" Text="" Style="color: red;"></asp:Label>
                </div>
                <div class="centerobject">
                    ¿No tienes una cuenta? <a runat="server" href="~/Registrar">Registrar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>