<%@ Page Title="CONTACTO" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Contacto</h1>
    <div class="contact-info">
        <h2>Información de Contacto</h2>
        <p>Nombre de la Empresa: SecondBite</p>
        <p>Teléfono: 678-456-329</p>
        <p>Email: <a href="mailto:secondbiteweb@gmail.com">secondbiteweb@gmail.com</a></p>
        <p>Dirección: Av. Hada, 12, Alicante, España</p>
    </div>
    <asp:Panel ID="contactPanel" runat="server" DefaultButton="btnEnviar">
        <div class="contact-form">
            <h2>Envíanos un mensaje</h2>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico:"></asp:Label>
            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="El correo electrónico es obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="El correo electrónico no es válido." ForeColor="Red" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"></asp:RegularExpressionValidator>
            <br />
            <asp:Label ID="lblMensaje" runat="server" Text="Mensaje:"></asp:Label>
            <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvMensaje" runat="server" ControlToValidate="txtMensaje" ErrorMessage="El mensaje es obligatorio." ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <asp:Button ID="btnEnviar" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
            <br />
            <asp:Label ID="lblConfirmacion" runat="server" ForeColor="Green" Visible="false" Text="¡Mensaje enviado correctamente!"></asp:Label>
        </div>
    </asp:Panel>
</asp:Content>
