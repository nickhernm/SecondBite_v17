using library;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Login : Page
    {
        private string username;

        protected void Page_Load(object sender, EventArgs e)
        {
            ContentPlaceHolder navigation = (ContentPlaceHolder)this.Master.FindControl("navBar");
            if (navigation != null)
            {
                navigation.Visible = false;
            }
        }

        protected void LoginUsu(object sender, EventArgs e)
        {
            try
            {
                username = txtUsuario.Text;
                string contrasena = txtContrasena.Text;

                if (AuthenticateUser(username, contrasena))
                {
                    // Autenticar al usuario y establecer la sesión
                    FormsAuthentication.SetAuthCookie(username, false);
                    GuardarUsuarioAutenticado(username); // Pasar el nombre de usuario
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    lblMessage.Text = "Usuario o contraseña incorrectos. Verifique sus credenciales o regístrese.";
                    txtContrasena.Text = "";
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Login has failed. Error: {0}", ex.Message);
            }
        }

        protected void cbxMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.TextMode = cbxMostrarContrasena.Checked ? TextBoxMode.SingleLine : TextBoxMode.Password;
        }

        private bool AuthenticateUser(string username, string password)
        {
            ENUsuarioRestaurante usuario = new ENUsuarioRestaurante();
            usuario.Correo = username;
            usuario.Contrasena = password;

            if (usuario.CheckUser())
            {
                // Usuario autenticado correctamente
                return true;
            }

            return false;
        }

        private void GuardarUsuarioAutenticado(string correo)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Eliminar todos los registros en la vista
                    string queryVistaEliminar = "DELETE FROM UsuariosAutenticados";
                    using (SqlCommand deleteCommand = new SqlCommand(queryVistaEliminar, connection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Insertar el usuario autenticado en la vista
                    string queryVistaInsertar = "INSERT INTO UsuariosAutenticados (correo, nombre, tipo_usuario) " +
                                                "SELECT correo, nombre, tipo_usuario FROM USUARIO WHERE correo = @Correo";
                    using (SqlCommand insertCommand = new SqlCommand(queryVistaInsertar, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Correo", correo);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Debug.WriteLine("Error al guardar el usuario autenticado: " + ex.Message);
            }
        }
    }
}