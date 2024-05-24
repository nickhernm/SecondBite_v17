using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Recomendaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRecomendaciones();
            }
        }

        private void CargarRecomendaciones()
        {
            ENRestaurante enRestaurante = new ENRestaurante();
            List<ENRestaurante> restaurantesRecomendados = enRestaurante.ObtenerRestaurantesRecomendados();
            rptRestaurantes.DataSource = restaurantesRecomendados;
            rptRestaurantes.DataBind();

            ENPlato enPlato = new ENPlato();
            List<ENPlato> platosRecomendados = enPlato.ObtenerPlatosRecomendados();
            rptPlatos.DataSource = platosRecomendados;
            rptPlatos.DataBind();
        }

        protected void btnVerMenu_Click(object sender, EventArgs e)
        {
            Button btnVerMenu = (Button)sender;
            int restauranteId = Convert.ToInt32(btnVerMenu.CommandArgument);
            Response.Redirect("Menu_Individual.aspx?RestauranteId=" + restauranteId);
        }

        protected void btnVerDetallesPlato_Click(object sender, EventArgs e)
        {
            Button btnVerDetalles = (Button)sender;
            int platoId = Convert.ToInt32(btnVerDetalles.CommandArgument);
            Response.Redirect("Plato_Individual.aspx?PlatoId=" + platoId);
        }
    }
}
