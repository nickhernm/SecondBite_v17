using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Web
{
    public partial class Menu_Individual : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int restauranteId = Convert.ToInt32(Request.QueryString["RestauranteId"]);
                CargarMenuRestaurante(restauranteId);
            }
        }

        private void CargarMenuRestaurante(int restauranteId)
        {
            
        }

        protected void btnAnadirCesta_Click(object sender, EventArgs e)
        {
         
        }
    }
}