using System;
using System.Web.UI;

namespace Web
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Aquí puedes agregar el código para procesar el mensaje de contacto,
                // como enviarlo por correo electrónico o guardarlo en una base de datos.

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
