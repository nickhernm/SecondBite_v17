using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Menu_Individual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int restauranteId = Convert.ToInt32(Request.QueryString["RestauranteId"]);
                CargarPlatosRestaurante(restauranteId);
            }
        }

        protected void btnAnadirCesta_Click(object sender, EventArgs e)
        {
            Button btnAnadirCesta = (Button)sender;
            int platoId = Convert.ToInt32(btnAnadirCesta.CommandArgument);
            // PENDINTE
        }

        protected void btnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btnVerDetalles = (Button)sender;
            int platoId = Convert.ToInt32(btnVerDetalles.CommandArgument);
            Response.Redirect("Platos.aspx?PlatoId=" + platoId);
        }

        private void CargarPlatosRestaurante(int restauranteId)
        {
            ENPlato enPlato = new ENPlato();
            List<ENPlato> platos = enPlato.ObtenerPlatosRestaurante(restauranteId);
            gvPlatos.DataSource = platos;
            gvPlatos.DataBind();
        }
    }
}