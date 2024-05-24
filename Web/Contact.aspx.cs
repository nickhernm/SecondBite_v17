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
                lblConfirmacion.Visible = true;
                txtNombre.Text = string.Empty;
                txtCorreo.Text = string.Empty;
                txtMensaje.Text = string.Empty;
            }
        }
    }
}
