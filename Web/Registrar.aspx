<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Web.Registrar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row" style="display: flex; justify-content: space-between; margin-top: 100px;">
        <div class="card" style="position: relative; width: 400px;">
            <div class="row" style="display: flex; justify-content: space-between;">
                <div class="purple-highlight">
                    <h2><%: Title %>.</h2>
                </div>
            </div>
            <div class="card-body" style="display: flex; flex-direction: column;">
                <div class="centerobject">
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="Email"></asp:TextBox>
                </div>
                <div class="centerobject">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Usuario"></asp:TextBox>
                </div>
                <div class="centerobject">
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Contraseña"></asp:TextBox>
                </div>
                <div class="centerobject">
                    <asp:Button ID="Button3" runat="server" Text="Create Account" OnClick="RegistroUsu"></asp:Button>
                </div>
                <div class="centerobject">Already have an account? <a runat="server" href="~/">Login</a> </div>

            </div>
        </div>
    </div>

</asp:Content>
