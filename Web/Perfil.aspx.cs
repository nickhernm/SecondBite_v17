using library;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Perfil : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENUsuarioRestaurante usur = new ENUsuarioRestaurante();
            usur.Read();
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