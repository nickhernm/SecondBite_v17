using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using library;

namespace Web
{
    public partial class Platos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int platoId = Convert.ToInt32(Request.QueryString["PlatoId"]);
                CargarInformacionPlato(platoId);
                CargarComentariosPlato(platoId);
            }
        }

        private void CargarInformacionPlato(int platoId)
        {
            ENPlato plato = new ENPlato();  
            
        }

        private void CargarComentariosPlato(int platoId)
        {
            
        }

        protected void btnAgregarComentario_Click(object sender, EventArgs e)
        {
            

            // Limpiar los campos del formulario
            txtNombreUsuario.Text = string.Empty;
            txtComentario.Text = string.Empty;
            ddlPuntuacion.SelectedIndex = 0;

            // Recargar los comentarios 
        }
    }
}