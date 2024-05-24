<%@ Page Title="Checkout" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Web.Checkout" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <h1>Checkout</h1>

        <div class="form-group">
            <label for="txtDireccion">Dirección de Envío</label>
            <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" placeholder="Dirección de Envío"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDireccion" runat="server" ControlToValidate="txtDireccion" ErrorMessage="La dirección de envío es obligatoria." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <label for="ddlMetodoPago">Método de Pago</label>
            <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlMetodoPago_SelectedIndexChanged">
                <asp:ListItem Value="Card" Text="Tarjeta" />
                <asp:ListItem Value="ApplePay" Text="Apple Pay" />
                <asp:ListItem Value="Cash" Text="Efectivo" />
            </asp:DropDownList>
        </div>

        <asp:Panel ID="pnlCardDetails" runat="server" Visible="false">
            <div class="form-group">
                <label for="txtNumeroTarjeta">Número de Tarjeta</label>
                <asp:TextBox ID="txtNumeroTarjeta" runat="server" CssClass="form-control" placeholder="Número de Tarjeta" ValidationGroup="CardGroup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNumeroTarjeta" runat="server" ControlToValidate="txtNumeroTarjeta" ErrorMessage="El número de tarjeta es obligatorio." CssClass="text-danger" Display="Dynamic" ValidationGroup="CardGroup"></asp:RequiredFieldValidator>
            </div>

            <div class="form-group">
                <label for="txtFechaVencimiento">Fecha de Vencimiento</label>
                <asp:TextBox ID="txtFechaVencimiento" runat="server" CssClass="form-control" placeholder="MM/AA" ValidationGroup="CardGroup"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvFechaVencimiento" runat="server" ControlToValidate="txtFechaVencimiento" ErrorMessage="La fecha de vencimiento es obligatoria." CssClass="text-danger" Display="Dynamic" ValidationGroup="CardGroup"></asp:RequiredFieldValidator>
            </div>
        </asp:Panel>

        <div>
            <h2>Precio Total</h2>
            <asp:Label ID="lblTotalCheckout" runat="server" Text=""></asp:Label>
        </div>

        <asp:Button ID="btnPagar" runat="server" Text="Pagar" CssClass="btn btn-primary" OnClick="btnPagar_Click" ValidationGroup="CardGroup" />
    </div>
</asp:Content>
