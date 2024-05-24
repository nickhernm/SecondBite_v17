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

                string correoUsuario = ObtenerCorreoUsuarioAutenticado();

                lnkUsername.Text = correoUsuario;
                lnkUsername.PostBackUrl = "~/Perfil.aspx"; 
                bool esRestaurante = VerificarUsuarioRestaurante(correoUsuario);
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
                return usuario.Tipo_usuario; 
            }

            return false; 
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