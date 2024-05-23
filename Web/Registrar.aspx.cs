using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ContentPlaceHolder navigation = (ContentPlaceHolder)this.Master.FindControl("navBar");
            if (navigation != null)
            {
                navigation.Visible = false;
            }
        }

        protected void RegistrarUsu(object sender, EventArgs e)
        {
            try
            {
                string email = TextBox1.Text;
                string name = TextBox2.Text;
                string telefono = TextBox3.Text;
                string contrasena = TextBox4.Text;
                bool tipo_usuario = cbxRestaurante.Checked; // true si es restaurante, false si es cliente

                if (IsValidEmail(email))
                {
                    ENUsuarioRestaurante usuario = new ENUsuarioRestaurante(email, name, telefono, tipo_usuario, contrasena);

                    if (usuario.Create())
                    {
                        Response.Redirect("Pedidos.aspx");
                    }
                    else
                    {
                        lblMessage.Text = "Datos faltantes y/o incorrectos";
                        TextBox2.Text = "";
                    }
                }
                else
                {
                    lblMessage.Text = "Correo electrónico no válido";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Ha ocurrido un error: " + ex.Message;
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}