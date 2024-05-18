using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Restaurantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComunidades();
                CargarTipos();
                CargarRestaurantes();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarRestaurantes();
        }

        protected void btnVerDetalles_Click(object sender, EventArgs e)
        {
            Button btnVerDetalles = (Button)sender;
            int restauranteId = Convert.ToInt32(btnVerDetalles.CommandArgument);
            Response.Redirect("Restaurante_Individual.aspx?RestauranteId=" + restauranteId);
        }

        private void CargarComunidades()
        {
            ENRestaurante enRestaurante = new ENRestaurante();
            List<string> comunidades = enRestaurante.ObtenerComunidades();
            ddlComunidad.DataSource = comunidades;
            ddlComunidad.DataBind();
            ddlComunidad.Items.Insert(0, new ListItem("Todas", ""));
        }

        private void CargarTipos()
        {
            ENRestaurante enRestaurante = new ENRestaurante();
            List<string> tipos = enRestaurante.ObtenerTipos();
            ddlTipo.DataSource = tipos;
            ddlTipo.DataBind();
            ddlTipo.Items.Insert(0, new ListItem("Todos", ""));
        }

        private void CargarRestaurantes()
        {
            string busqueda = txtBuscar.Text;
            string comunidad = ddlComunidad.SelectedValue;
            string tipo = ddlTipo.SelectedValue;
            string puntuacion = ddlPuntuacion.SelectedValue;

            ENRestaurante enRestaurante = new ENRestaurante();
            List<ENRestaurante> restaurantes = enRestaurante.ObtenerRestaurantes(busqueda, comunidad, tipo, puntuacion);
            RepeaterRestaurantes.DataSource = restaurantes;
            RepeaterRestaurantes.DataBind();
        }
    }
}