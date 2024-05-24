<%@ Page Title="Registrar" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="Web.Registrar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="display: flex; justify-content: space-between; margin-top: 100px;">
        <div class="card" style="position: relative; width: 400px;">
            <div class="row" style="display: flex; justify-content: space-between;">
                <h2><%: Title %></h2>
            </div>
            <div class="card-body" style="display: flex; flex-direction: column;">
                <div class="centerobject">
                    <asp:TextBox ID="TextBox1" runat="server" placeholder="Email"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="TextBox1" 
                        ErrorMessage="Correo electrónico no válido" 
                        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" 
                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <div class="centerobject">
                    <asp:TextBox ID="TextBox2" runat="server" placeholder="Usuario"></asp:TextBox>
                </div>
                <div class="centerobject">
                    <asp:TextBox ID="TextBox3" runat="server" placeholder="Telefono"></asp:TextBox>
                </div>
                <div class="centerobject">
                    <asp:TextBox ID="TextBox4" runat="server" placeholder="Contraseña" TextMode="Password" 
                        onkeyup="checkPasswordStrength(this.value)"></asp:TextBox>
                    <asp:Label ID="lblPasswordStrength" runat="server" Text=""></asp:Label>
                </div>
                <div class="centerobject">
                    <asp:CheckBox ID="cbxRestaurante" runat="server" Text="¿Es un restaurante?" />
                </div>
                <div class="centerobject">
                    <asp:Button ID="Button3" runat="server" Text="Create Account" OnClick="RegistrarUsu"></asp:Button>
                </div>
                <div class="centerobject">
                    <asp:Label ID="lblMessage" runat="server" Text="" Style="color: red;"></asp:Label>
                </div>
                <div class="centerobject">
                    Already have an account? <a runat="server" href="~/Login">Login</a>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function checkPasswordStrength(password) {
            var strengthLabel = document.getElementById('<%= lblPasswordStrength.ClientID %>');
            var strength = "Weak";
            var color = "Red";

            if (password.length >= 8) {
                var hasUpperCase = /[A-Z]/.test(password);
                var hasLowerCase = /[a-z]/.test(password);
                var hasNumbers = /\d/.test(password);
                var hasSpecialChars = /[!@#$%^&*(),.?":{}|<>]/.test(password);

                var strengthCount = [hasUpperCase, hasLowerCase, hasNumbers, hasSpecialChars].filter(Boolean).length;

                if (strengthCount >= 3) {
                    strength = "Strong";
                    color = "Green";
                } else if (strengthCount >= 2) {
                    strength = "Medium";
                    color = "Orange";
                }
            }

            strengthLabel.innerHTML = strength;
            strengthLabel.style.color = color;
        }
    </script>
</asp:Content>