using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Restaurante_Individual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int restauranteId = Convert.ToInt32(Request.QueryString["RestauranteId"]);
                CargarDetallesRestaurante(restauranteId);
                CargarValoracionesRestaurante(restauranteId);
            }
        }

        protected void btnVerMenu_Click(object sender, EventArgs e)
        {
            Button btnVerMenu = (Button)sender;
            int restauranteId = Convert.ToInt32(btnVerMenu.CommandArgument);
            Response.Redirect("Menu_Individual.aspx?RestauranteId=" + restauranteId);
        }

        protected void btnAgregarValoracion_Click(object sender, EventArgs e)
        {
            
        }

        private void CargarDetallesRestaurante(int restauranteId)
        {
            ENRestaurante restaurante = new ENRestaurante();
            restaurante.Cod = restauranteId;
            if (restaurante.Read())
            {
                fvRestaurante.DataSource = new List<ENRestaurante> { restaurante };
                fvRestaurante.DataBind();
            }
        }

        private void CargarValoracionesRestaurante(int restauranteId)
        {
          
        }

        private void LimpiarCamposValoracion()
        {
            txtUsuario.Text = string.Empty;
            ddlPuntuacion.SelectedIndex = 0;
            txtComentario.Text = string.Empty;
        }
    }
}