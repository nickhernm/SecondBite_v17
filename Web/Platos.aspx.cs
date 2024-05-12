using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Platos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatos();
                CargarAlergenos();
                CargarPuntuaciones();
            }
        }

        private void CargarPlatos()
        {
            string connectionString = "TU_CADENA_DE_CONEXION";
            string query = "SELECT id, nombre, alergenos, puntuacion FROM PLATO";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<Plato> platos = new List<Plato>();

                while (reader.Read())
                {
                    Plato plato = new Plato
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["nombre"].ToString(),
                        Alergenos = reader["alergenos"].ToString(),
                        Puntuacion = (float)reader["puntuacion"]
                    };

                    platos.Add(plato);
                }

                reader.Close();

                RepeaterPlatos.DataSource = platos;
                RepeaterPlatos.DataBind();
            }
        }

        private void CargarAlergenos()
        {
            DdlAlergenos.Items.Add(new ListItem("Todos los alérgenos", ""));
            DdlAlergenos.Items.Add(new ListItem("Mariscos", "masricos"));
            DdlAlergenos.Items.Add(new ListItem("Pescado", "pescado"));
            DdlAlergenos.Items.Add(new ListItem("Soja", "soja"));
        }

        private void CargarPuntuaciones()
        {
            DdlPuntuacion.Items.Add(new ListItem("Todas las puntuaciones", ""));
            DdlPuntuacion.Items.Add(new ListItem("1 estrella", "1"));
            DdlPuntuacion.Items.Add(new ListItem("2 estrellas", "2"));
            DdlPuntuacion.Items.Add(new ListItem("3 estrellas", "3"));
            DdlPuntuacion.Items.Add(new ListItem("4 estrellas", "4"));
            DdlPuntuacion.Items.Add(new ListItem("5 estrellas", "5"));
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string busqueda = TxtBuscarPlato.Text.Trim();
            string alergeno = DdlAlergenos.SelectedValue;
            float puntuacion = float.Parse(DdlPuntuacion.SelectedValue);

            List<Plato> platosResultado = ObtenerPlatosFiltrados(busqueda, alergeno, puntuacion);

            RepeaterPlatos.DataSource = platosResultado;
            RepeaterPlatos.DataBind();
        }

        private List<Plato> ObtenerPlatosFiltrados(string busqueda, string alergeno, float puntuacion)
        {
            string connectionString = "TU_CADENA_DE_CONEXION";
            string query = "SELECT id, nombre, alergenos, puntuacion FROM PLATO WHERE 1=1";

            if (!string.IsNullOrEmpty(busqueda))
            {
                query += " AND nombre LIKE @Busqueda";
            }

            if (!string.IsNullOrEmpty(alergeno))
            {
                query += " AND alergenos = @Alergeno";
            }

            if (puntuacion > 0)
            {
                query += " AND puntuacion = @Puntuacion";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                if (!string.IsNullOrEmpty(busqueda))
                {
                    command.Parameters.AddWithValue("@Busqueda", "%" + busqueda + "%");
                }

                if (!string.IsNullOrEmpty(alergeno))
                {
                    command.Parameters.AddWithValue("@Alergeno", alergeno);
                }

                if (puntuacion > 0)
                {
                    command.Parameters.AddWithValue("@Puntuacion", puntuacion);
                }

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                List<Plato> platos = new List<Plato>();

                while (reader.Read())
                {
                    Plato plato = new Plato
                    {
                        Id = (int)reader["id"],
                        Nombre = reader["nombre"].ToString(),
                        Alergenos = reader["alergenos"].ToString(),
                        Puntuacion = (float)reader["puntuacion"]
                    };

                    platos.Add(plato);
                }

                reader.Close();

                return platos;
            }
        }

        protected void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            TxtBuscarPlato.Text = string.Empty;
            DdlAlergenos.SelectedIndex = 0;
            DdlPuntuacion.SelectedIndex = 0;

            CargarPlatos();
        }

        protected void BtnAnadirCesta_Click(object sender, EventArgs e)
        {
            int platoId = int.Parse((sender as Button).CommandArgument);

            // Lógica para añadir el plato a la cesta de compra
            // ...
        }
    }

    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Alergenos { get; set; }
        public float Puntuacion { get; set; }
    }
}