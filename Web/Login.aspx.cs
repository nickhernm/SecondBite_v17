<<<<<<< HEAD

ï»¿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using library;
=======
>>>>>>> ea3ffb7fb036a07add0a211820e65dc767a2a630
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using library;
using static System.Runtime.CompilerServices.RuntimeHelpers;

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
                    Response.Redirect("Perfil.aspx");
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
<<<<<<< HEAD

=======
>>>>>>> ea3ffb7fb036a07add0a211820e65dc767a2a630

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

                    // Crear o actualizar la vista con el usuario autenticado
                    string queryVistaActualizar = @"
                IF OBJECT_ID('dbo.prueba', 'V') IS NOT NULL
                BEGIN
                    DROP VIEW dbo.prueba;
                END;
                CREATE VIEW prueba AS 
                SELECT correo, nombre, telefono, tipo_usuario 
                FROM USUARIO 
                WHERE correo = @Correo;
            ";
                    using (SqlCommand command = new SqlCommand(queryVistaActualizar, connection))
                    {
                        command.Parameters.AddWithValue("@Correo", correo);
                        command.ExecuteNonQuery();
                    }

                    Debug.WriteLine("Vista actualizada con el usuario autenticado.");
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