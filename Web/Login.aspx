<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="display: flex; justify-content: center; margin-top: 100px;">
        <div class="card" style="width: 400px; padding: 20px;">
            <h2>Login</h2>
            <div>
                <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary" OnClick="LoginUsu" />
            </div>
            <div class="form-group">
                <a runat="server" href="~/Registrar">¿No tienes una cuenta? Registrar</a>
            </div>
        </div>
    </div>
</asp:Content>