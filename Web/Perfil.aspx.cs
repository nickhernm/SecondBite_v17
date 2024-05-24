using library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
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

        protected void Logout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Login.aspx");
        }

        private void CargarPerfil()
        {
            ENUsuario usuario = ObtenerUsuarioAutenticado();
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

        private ENUsuario ObtenerUsuarioAutenticado()
        {
            ENUsuario usuario = null;
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT correo, nombre, telefono, tipo_usuario FROM USUARIO WHERE correo = @correo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@correo", User.Identity.Name);

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        usuario = new ENUsuario
                        {
                            Correo = reader["correo"].ToString(),
                            Nombre = reader["nombre"].ToString(),
                            Telefono = reader["telefono"].ToString(),
                            TipoUsuario = Convert.ToBoolean(reader["tipo_usuario"])
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener el usuario autenticado: " + ex.Message);
            }

            return usuario;
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

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Descripcion, Valoracion FROM OPINION WHERE Usuario = @correo";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@correo", User.Identity.Name);

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
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener opiniones: " + ex.Message);
            }

            return opiniones;
        }
    }
}
