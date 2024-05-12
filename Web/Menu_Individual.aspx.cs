using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Web
{
    public partial class Menu_Individual : System.Web.UI.Page
    {
        public string RestauranteNombre { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el ID del restaurante desde la URL o la sesión
                int restauranteId = Convert.ToInt32(Request.QueryString["restauranteId"]);

                // Cargar el nombre del restaurante
                CargarRestauranteNombre(restauranteId);

                // Cargar los platos del menú
                CargarPlatos(restauranteId);
            }
        }

        private void CargarRestauranteNombre(int restauranteId)
        {
            string connectionString = "TU_CADENA_DE_CONEXION";
            string query = "SELECT Nombre FROM Restaurantes WHERE Id = @RestauranteId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RestauranteId", restauranteId);

                connection.Open();
                RestauranteNombre = (string)command.ExecuteScalar();
            }
        }

        private void CargarPlatos(int restauranteId)
        {
            string connectionString = "TU_CADENA_DE_CONEXION";
            string query = "SELECT PlatoId, Nombre, Descripcion, Precio, Alergenos FROM Platos WHERE RestauranteId = @RestauranteId";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RestauranteId", restauranteId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                List<Plato> platos = new List<Plato>();

                while (reader.Read())
                {
                    Plato plato = new Plato
                    {
                        //PlatoId = (int)reader["PlatoId"],
                        //Nombre = reader["Nombre"].ToString(),
                        //Descripcion = reader["Descripcion"].ToString(),
                        //Precio = (decimal)reader["Precio"],
                        //Alergenos = reader["Alergenos"].ToString()
                    };

                    platos.Add(plato);
                }

                reader.Close();

                RepeaterPlatos.DataSource = platos;
                RepeaterPlatos.DataBind();
            }
        }

        protected void BtnAnadirCesta_Click(object sender, EventArgs e)
        {
            int platoId = Convert.ToInt32((sender as Button).CommandArgument);

            // Lógica para añadir el plato a la cesta de compra
            // ...
        }
    }
}