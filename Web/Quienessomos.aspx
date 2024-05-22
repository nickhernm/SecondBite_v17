<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Quienessomos.aspx.cs" Inherits="Web.Quienessomos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-12 text-center">
            <asp:Image ID="CoverImage" runat="server" ImageUrl="~/Images/cover2.jpeg" AlternateText="Cover Image" CssClass="img-fluid" Height="619px" Width="1264px" />
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 offset-md-2 text-center">
                
                <h1>Quiénes Somos</h1>
                <p>
                    Somos una empresa comprometida con la reducción del desperdicio de alimentos y el apoyo a los restaurantes locales. Nuestra plataforma permite a los restaurantes vender su exceso de comida a precios reducidos, brindando a nuestros clientes la oportunidad de disfrutar de deliciosos platillos a precios accesibles.
                </p>
                <p>
                    En un mundo donde el desperdicio de alimentos es un problema creciente, creemos firmemente en la importancia de utilizar recursos de manera responsable. Trabajamos en estrecha colaboración con los restaurantes para garantizar que los alimentos excedentes se redistribuyan de manera efectiva y no se desperdicien.
                </p>
                <p>
                    Nuestro objetivo es no solo proporcionar una solución económica para los clientes, sino también contribuir positivamente al medio ambiente al reducir la cantidad de alimentos que se desperdician diariamente. ¡Únete a nosotros en nuestra misión de hacer del mundo un lugar mejor, un bocado a la vez!
                </p>
                </div>
        </div>
        <div class="row">
            <div class="col-md-6 offset-md-3">
                
                <h2>Nuestra Misión</h2>
                <p>
                    Mejorar la calidad de vida al reducir el desperdicio de alimentos, apoyando a los restaurantes locales y proporcionando comidas asequibles a nuestros clientes.
                </p>
                
                <h2>Nuestra Visión</h2>
                <p>
                    Ser líderes en la lucha contra el desperdicio de alimentos y en el apoyo a la comunidad local, promoviendo un futuro más sostenible y equitativo.
                </p>

                <h2>Valores</h2>
                <p>
                    <strong>Sostenibilidad:</strong> Creemos en el uso responsable de los recursos para proteger nuestro planeta.
                </p>
                <p>
                    <strong>Colaboración:</strong> Trabajamos juntos con restaurantes y clientes para crear un impacto positivo.
                </p>
                <p>
                    <strong>Innovación:</strong> Buscamos continuamente maneras nuevas y efectivas de reducir el desperdicio de alimentos.
                </p>
                   </div>
                  </div>
                <div class="row">
                    <div class="col-md-6 offset-md-3">             
                <h2>Nuestro Equipo</h2>
                <p>
                    <strong>Jaime Hernandez Delgado</strong> - Fundador
                    <br>Jaime, con una pasión por la sostenibilidad y la tecnología, fundó SecondBite para hacer frente al problema del desperdicio de alimentos mediante soluciones innovadoras.
                </p>
                <p>
                    <strong>Yaroslav</strong> - Co-Fundador
                    <br>Yaroslav, experto en gestión de alimentos, se unió a SecondBite para garantizar que los alimentos excedentes lleguen a quienes más los necesitan.
                </p>
                <p>
                    <strong>Nada Benaissa</strong> - COO
                    <br>Nada supervisa las operaciones diarias de SecondBite, asegurando que nuestra misión se cumpla eficientemente.
                </p>
                <p>
                    <strong>Dario Simon Franco</strong> - CTO
                    <br>Dario, con amplia experiencia en tecnología y desarrollo de software, lidera los esfuerzos tecnológicos para mejorar la plataforma de SecondBite.
                </p>
                </div>
                </div>
                <div class="row">
                    <div class="col-md-6 offset-md-3">
                <h2>Contacto</h2>
                <p>
                    <strong>Teléfono:</strong> 678-456-329
                    <br><strong>Email:</strong> <a href="mailto:secondbiteweb@gmail.com">secondbiteweb@gmail.com</a>
                </p>

                <h2>Newsletter</h2>
                <p>
                    ¡Suscríbete a nuestro boletín para recibir las últimas noticias y ofertas exclusivas!
                </p>
                <!--<form action="#" method="post">-->
                    <div class="form-group">
                        <label for="txtNombre">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group">
                        <label for="txtCorreo">Correo Electrónico</label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="Correo Electrónico"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="El correo electrónico es obligatorio." CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revCorreo" runat="server" ControlToValidate="txtCorreo" ErrorMessage="Formato de correo electrónico inválido" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" CssClass="text-danger" Display="Dynamic"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-check">
                        <input type="checkbox" class="form-check-input" id="politicaPrivacidad">
                        <label class="form-check-label" for="politicaPrivacidad">Acepto la Política de Privacidad, Cookies y Términos de uso</label>
                    </div>
                    <button type="submit" class="btn btn-primary">¡Me Apunto!</button>
                <!--</form>-->

               
            </div>
        </div>
    </div>

</asp:Content>
