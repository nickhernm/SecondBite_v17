using System;
using System.Collections.Generic;
using System.Web.UI;
using library;

namespace Web
{
    /*public partial class Platos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int platoId = Convert.ToInt32(Request.QueryString["PlatoId"]);
                CargarDetallesPlato(platoId);
                CargarValoracionesPlato(platoId);
            }
        }

        protected void btnAgregarValoracion_Click(object sender, EventArgs e)
        {
            int platoId = Convert.ToInt32(Request.QueryString["PlatoId"]);
            string usuario = txtUsuario.Text;
            int puntuacion = Convert.ToInt32(ddlPuntuacion.SelectedValue);
            string comentario = txtComentario.Text;

            ENValoracion valoracion = new ENValoracion();
            valoracion.PlatoId = platoId;
            valoracion.Usuario = usuario;
            valoracion.Puntuacion = puntuacion;
            valoracion.Comentario = comentario;
            valoracion.Create();

            CargarValoracionesPlato(platoId);
            LimpiarCamposValoracion();
        }

        private void CargarDetallesPlato(int platoId)
        {
            ENPlato plato = new ENPlato();
            plato.Id = platoId;
            if (plato.Read())
            {
                fvPlato.DataSource = new List<ENPlato> { plato };
                fvPlato.DataBind();
            }
        }

        private void CargarValoracionesPlato(int platoId)
        {
            ENValoracion enValoracion = new ENValoracion();
            List<ENValoracion> valoraciones = enValoracion.ObtenerValoracionesPlato(platoId);
            gvValoraciones.DataSource = valoraciones;
            gvValoraciones.DataBind();
        }

        private void LimpiarCamposValoracion()
        {
            txtUsuario.Text = string.Empty;
            ddlPuntuacion.SelectedIndex = 0;
            txtComentario.Text = string.Empty;
        }
    }*/
}