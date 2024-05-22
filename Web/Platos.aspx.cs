using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Platos : System.Web.UI.Page
    {
        protected GridView gvPlatosDestacados;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatosDestacados();
            }
        }

        private void CargarPlatosDestacados()
        {
            ENPlato enPlato = new ENPlato();
            List<ENPlato> platosDestacados = enPlato.ObtenerPlatosDestacados();
            //gvPlatosDestacados.DataSource = platosDestacados;
            //gvPlatosDestacados.DataBind();
            // MIRAR COMO ARREGLAR ESTO
        }

        private void CargarOpinionesPlato(int platoId)
        {
            ENOpinionPlato enOpinionPlato = new ENOpinionPlato();
            List<ENOpinion> opiniones = enOpinionPlato.ObtenerOpinionesPlato(platoId);
            DataBind();
        }

        private void CargarInformacionPlato(int platoId)
        {
            ENPlato plato = new ENPlato();
            plato.Id = platoId;
            if (plato.Read())
            {
                fvPlato.DataSource = new List<ENPlato> { plato };
                fvPlato.DataBind();
            }
        }

        protected void btnAgregarComentario_Click(object sender, EventArgs e)
        {
            int platoId = Convert.ToInt32(Request.QueryString["PlatoId"]);
            string usuario = txtUsuario.Text;
            string comentario = txtComentario.Text;
            int puntuacion = Convert.ToInt32(ddlPuntuacion.SelectedValue);

            ENOpinion opinion = new ENOpinion();
            opinion.Descripcion = comentario;
            opinion.Valoracion = puntuacion;
            opinion.UsuarioCorreo = usuario;

            if (opinion.Create())
            {
                ENOpinionPlato opinionPlato = new ENOpinionPlato();
                opinionPlato.IdPlato = platoId;
                opinionPlato.IdOpinion = opinion.Id;
                opinionPlato.Create();

                CargarOpinionesPlato(platoId);
                LimpiarCamposOpinion();
            }
            else
            {
            }
        }

        private void LimpiarCamposOpinion()
        {
            txtUsuario.Text = string.Empty;
            txtComentario.Text = string.Empty;
            ddlPuntuacion.SelectedIndex = 0;
        }
    }
}