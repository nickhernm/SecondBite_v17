using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarDatosPerfil();
            }
        }

        private void CargarDatosPerfil()
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
            string query = "SELECT NombreUsuario, Correo, FechaNacimiento, Direccion, Ciudad, CodigoPostal FROM Usuarios WHERE UsuarioID = @UsuarioID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UsuarioID", 1); // Reemplaza con el ID del usuario actual

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            lblNombreUsuario.Text = reader["NombreUsuario"].ToString();
                            lblCorreo.Text = reader["Correo"].ToString();
                            lblFechaNacimiento.Text = Convert.ToDateTime(reader["FechaNacimiento"]).ToString("dd/MM/yyyy");
                            lblDireccion.Text = reader["Direccion"].ToString();
                            lblCiudad.Text = reader["Ciudad"].ToString();
                            lblCodigoPostal.Text = reader["CodigoPostal"].ToString();
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Manejar excepción
                    Response.Write(ex.Message);
                }
            }
        }
    }
}