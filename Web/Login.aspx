<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <div class="card">
        <div class="card-header bg-primary text-white d-flex justify-content-between align-items-center">
            <h3 class="mb-0">Iniciar sesión</h3>
        </div>
        <div class="card-body">
            <div class="form-group">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
            </div>
            <div class="d-flex justify-content-between">
                <asp:Button ID="Button3" runat="server" CssClass="btn btn-primary" Text="Iniciar sesión" OnClick="LogUsu" />
                <a runat="server" href="~/Register" class="btn btn-link">¿No tienes una cuenta? Regístrate</a>
            </div>
        </div>
    </div>
</asp:Content>