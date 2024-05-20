using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Registrar : System.Web.UI.Page
    {
        private ENUsuarioRestaurante usuario;
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
                bool tipo_usuario = false;

                
usuario = new ENUsuarioRestaurante(email, name, telefono, tipo_usuario, contrasena);                if (usuario.Create())
                {
                    Response.Redirect("Pedidos.aspx");
                }
                else
                {
                    lblMessage.Text = "Datos faltantes y/o incorrectos";
                    TextBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Register has failed. Error: {0}", ex.Message);
            }
        }

        protected string GetCardContent()
        {
            // Logic to retrieve dynamic content
            return "Dynamic card content";
        }
    }
}