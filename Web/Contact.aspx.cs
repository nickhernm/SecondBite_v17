using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail; // Agregar esta línea para usar la clase SmtpClient

namespace Web
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar las preguntas frecuentes
                
            }

        }
        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string nombre = txtNombre.Text;
                string correo = txtCorreo.Text;
                string mensaje = txtMensaje.Text;

                // Mostrar el mensaje de confirmación
                lblConfirmacion.Visible = true;

                // Limpiar los campos del formulario
                txtNombre.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtMensaje.Text = string.Empty;
            }

        }

 
    }
}