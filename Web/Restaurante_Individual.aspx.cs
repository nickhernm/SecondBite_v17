using System;
using System.Data.SqlClient;

namespace Web
{
    public partial class Restaurante_Individual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí deberías agregar el código para obtener la información del restaurante de la base de datos
                // Por ejemplo, supongamos que tienes una función GetRestauranteInfo que devuelve un objeto Restaurante con la información del restaurante
                Restaurante restaurante = GetRestauranteInfo();

                // Luego asigna la información obtenida a los controles del formulario
                if (restaurante != null)
                {
                    lblNombre.Text = "Nombre: " + restaurante.Nombre;
                    lblLocalidad.Text = "Localidad: " + restaurante.Localidad;
                    lblTipo.Text = "Tipo: " + restaurante.Tipo;
                    lblPuntuacion.Text = "Puntuación: " + restaurante.Puntuacion.ToString();
                    lblDireccion.Text = "Dirección: " + restaurante.Direccion;
                    lblPlato.Text = "Plato: " + restaurante.Plato;
                }
            }
        }

        // Método para obtener la información del restaurante desde la base de datos
        private Restaurante GetRestauranteInfo()
        {
            // Conexión a la base de datos
            string connectionString = "Data Source=tu_servidor;Initial Catalog=tu_base_de_datos;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Consulta SQL para obtener la información del restaurante
                string query = "SELECT nombre, localidad, tipo, puntuacion, direccion, plato FROM RESTAURANTE WHERE cod = @codRestaurante";
                SqlCommand command = new SqlCommand(query, connection);
                //command.Parameters.AddWithValue("@codRestaurante", cod);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        // Crear un objeto Restaurante y devolverlo con la información obtenida de la base de datos
                        Restaurante restaurante = new Restaurante();
                        restaurante.Nombre = reader["nombre"].ToString();
                        restaurante.Localidad = reader["localidad"].ToString();
                        restaurante.Tipo = reader["tipo"].ToString();
                        restaurante.Puntuacion = Convert.ToDouble(reader["puntuacion"]);
                        restaurante.Direccion = reader["direccion"].ToString();
                        restaurante.Plato = reader["plato"].ToString();
                        return restaurante;
                    }
                }
                catch (Exception ex)
                {
                    // Manejar excepciones
                    Console.WriteLine(ex.Message);
                }
            }
            return null;
        }
    }

    // Clase Restaurante para representar la información del restaurante
    public class Restaurante
    {
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public string Tipo { get; set; }
        public double Puntuacion { get; set; }
        public string Direccion { get; set; }
        public string Plato { get; set; }
    }
}
