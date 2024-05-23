using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using library;

namespace Web
{
    public partial class Login : Page
    {
        private string username;
        private ENUsuarioRestaurante usuario;

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
                // Autenticar al usuario
                FormsAuthentication.RedirectFromLoginPage(username, false);
                GuardarUsuarioAutenticado(usuario);

                return true;
            }

            return false;
        }

        private void GuardarUsuarioAutenticado(ENUsuarioRestaurante usuario)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["Database"].ConnectionString;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Eliminar todos los registros
                    string queryVistaEliminar = "DELETE FROM UsuariosAutenticados";
                    using (SqlCommand deleteCommand = new SqlCommand(queryVistaEliminar, connection))
                    {
                        deleteCommand.ExecuteNonQuery();
                    }

                    // Insertar el usuario autenticado
                    string queryVistaInsertar = "INSERT INTO UsuariosAutenticados (Correo, Nombre, Tipo_usuario) VALUES (@Correo, @Nombre, @Tipo_usuario)";
                    using (SqlCommand insertCommand = new SqlCommand(queryVistaInsertar, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@Correo", usuario.Correo);
                        insertCommand.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        insertCommand.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                        insertCommand.Parameters.AddWithValue("@Tipo_usuario", usuario.Tipo_usuario);

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