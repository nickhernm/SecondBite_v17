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
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Platos.PlatoId, Platos.Nombre, Platos.Descripcion, Platos.Precio, Platos.Alergenos, Restaurantes.Nombre AS RestauranteNombre " +
                               "FROM Platos " +
                               "INNER JOIN Restaurantes ON Platos.RestauranteId = Restaurantes.RestauranteId " +
                               "WHERE Platos.RestauranteId = @RestauranteId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RestauranteId", restauranteId);
                SqlDataReader reader = command.ExecuteReader();
                rptPlatos.DataSource = reader;
                rptPlatos.DataBind();

                if (reader.Read())
                {
                    ltlRestauranteNombre.Text = reader["RestauranteNombre"].ToString();
                }
            }
        }

        protected void btnAnadirCesta_Click(object sender, EventArgs e)
        {
            Button btnAnadirCesta = (Button)sender;
            int platoId = Convert.ToInt32(btnAnadirCesta.CommandArgument);

            // lógica para añadir el plato a la cesta del cliente
         
        }
    }
}