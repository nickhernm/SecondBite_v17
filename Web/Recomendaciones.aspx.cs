using System;
using System.Collections.Generic;
using System.Web.UI;
using library;

namespace Web
{
    public partial class Recomendaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRestaurantesRecomendados();
                CargarPlatosRecomendados();
            }
        }

        private void CargarRestaurantesRecomendados()
        {
            ENRestaurante enRestaurante = new ENRestaurante();
            List<ENRestaurante> restaurantes = enRestaurante.ObtenerRestaurantesRecomendados();
            rptRestaurantes.DataSource = restaurantes;
            rptRestaurantes.DataBind();
        }

        private void CargarPlatosRecomendados()
        {
            ENPlato enPlato = new ENPlato();
            List<ENPlato> platos = enPlato.ObtenerPlatosRecomendados();
            rptPlatos.DataSource = platos;
            rptPlatos.DataBind();
        }
    }
}
