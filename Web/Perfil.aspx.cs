using library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.UI;

namespace Web
{
    public partial class Perfil : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPerfil();
                CargarOpiniones();
            }
        }

        private void CargarPerfil()
        {
            ENUsuarioRestaurante usuario = ObtenerUsuarioAutenticado();
            if (usuario != null)
            {
                lblNombreUsuario.Text = usuario.Nombre;
                lblCorreo.Text = usuario.Correo;
                lblNombre.Text = usuario.Nombre;
                lblTelefono.Text = usuario.Telefono;
            }
            else
            {
                // Mostrar mensaje si no se encuentra el usuario
                lblMensajeOpiniones.Text = "No se ha podido cargar el perfil del usuario.";
                lblMensajeOpiniones.Visible = true;
            }
        }

        private ENUsuarioRestaurante ObtenerUsuarioAutenticado()
        {
            ENUsuarioRestaurante usuario = null;
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT correo, nombre, telefono, tipo_usuario FROM prueba";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        usuario = new ENUsuarioRestaurante
                        {
                            Correo = reader["correo"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            Telefono = reader["telefono"].ToString(),
                            Tipo_usuario = Convert.ToBoolean(reader["tipo_usuario"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener el usuario autenticado: " + ex.Message);
            }

            return usuario;
        }

        private void GuardarUsuarioAutenticado(string correo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Eliminar la vista si existe
                    string queryVistaEliminar = "IF OBJECT_ID('dbo.prueba', 'V') IS NOT NULL DROP VIEW dbo.prueba;";
                    using (SqlCommand deleteCommand = new SqlCommand(queryVistaEliminar, connection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Crear la vista con el usuario autenticado
                    string queryVistaCrear = @"
                CREATE VIEW prueba AS 
                SELECT correo, nombre, telefono, tipo_usuario 
                FROM USUARIO 
                WHERE correo = @Correo;
            ";
                    using (SqlCommand createCommand = new SqlCommand(queryVistaCrear, connection))
                    {
                        createCommand.Parameters.AddWithValue("@Correo", correo);
                        createCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Debug.WriteLine("Error al guardar el usuario autenticado: " + ex.Message);
            }
        }

        private void CargarOpiniones()
        {
            List<ENOpinion> opiniones = ObtenerOpinionesDeUsuario();

            if (opiniones != null && opiniones.Count > 0)
            {
                rptOpiniones.DataSource = opiniones;
                rptOpiniones.DataBind();
            }
            else
            {
                // Mostrar mensaje si no hay opiniones
                lblMensajeOpiniones.Text = "No hay opiniones disponibles.";
                lblMensajeOpiniones.Visible = true;
            }
        }

        private List<ENOpinion> ObtenerOpinionesDeUsuario()
        {
            List<ENOpinion> opiniones = new List<ENOpinion>();
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Descripcion, Valoracion FROM OPINION WHERE Usuario = @Correo";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Correo", lblCorreo.Text);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    ENOpinion opinion = new ENOpinion
                    {
                        Descripcion = reader["Descripcion"].ToString(),
                        Valoracion = (float)Convert.ToDouble(reader["Valoracion"])
                    };
                    opiniones.Add(opinion);
                }
            }

            return opiniones;
        }
    }
}