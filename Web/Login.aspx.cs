using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void LoginUsu(object sender, EventArgs e)
        {
            string username = txtUsuario.Text;
            string password = txtContrasena.Text;

            if (AuthenticateUser(username, password))
            {
                // Establecer la cookie de autenticación
                FormsAuthentication.SetAuthCookie(username, false);
                Response.Redirect("Perfil.aspx");
            }
            else
            {
                lblMessage.Text = "Usuario o contraseña incorrectos.";
            }
        }

        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT COUNT(*) FROM USUARIO WHERE correo = @username AND contrasena = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    isAuthenticated = (count > 0);
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según sea necesario
                Console.WriteLine("Error al autenticar el usuario: " + ex.Message);
            }

            return isAuthenticated;
        }
    }
}
