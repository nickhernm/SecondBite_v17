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
            string query = "SELECT TOP 1 Correo FROM UsuariosAutenticados";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                        
                            lblCorreo.Text = reader["correo"].ToString();
                        
                            //lblDireccion.Text = reader["direccion"].ToString();

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