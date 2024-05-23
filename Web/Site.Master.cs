using library;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;

namespace Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UpdateButtonVisibility();
            }
        }

        private void UpdateButtonVisibility()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                PanelAnonymous.Visible = false;
                PanelAuthenticated.Visible = true;

                // Obtener el correo electrónico del usuario autenticado desde la vista
                string correoUsuario = ObtenerCorreoUsuarioAutenticado();

                // Mostrar el correo electrónico en la barra de navegación
                lnkUsername.Text = correoUsuario;
                lnkUsername.PostBackUrl = "~/Perfil.aspx"; // Redirigir a la página de perfil al hacer clic

                // Verificar si el usuario es un restaurante
                bool esRestaurante = VerificarUsuarioRestaurante(correoUsuario);
                //PanelRestaurante.Visible = esRestaurante;
            }
            else
            {
                PanelAnonymous.Visible = true;
                PanelAuthenticated.Visible = false;
                //PanelRestaurante.Visible = false;
            }
        }

        private bool VerificarUsuarioRestaurante(string correoUsuario)
        {
            ENUsuarioRestaurante usuario = new ENUsuarioRestaurante();
            usuario.Correo = correoUsuario;

            if (usuario.Read())
            {
                return usuario.Tipo_usuario; // True si es restaurante, false si es cliente
            }

            return false; // Si no se encuentra el usuario, se asume que no es un restaurante
        }

        private string ObtenerCorreoUsuarioAutenticado()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT TOP 1 correo FROM UsuariosAutenticados";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        object result = command.ExecuteScalar();
                        return result != null ? result.ToString() : string.Empty;
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener el correo del usuario autenticado: " + ex.Message);
                return string.Empty;
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }

        protected void lnkUsername_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }
    }
}