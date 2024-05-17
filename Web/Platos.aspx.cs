using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

namespace Web
{
    public partial class Platos : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int platoId = Convert.ToInt32(Request.QueryString["PlatoId"]);
                CargarInformacionPlato(platoId);
                CargarComentariosPlato(platoId);
            }
        }

        private void CargarInformacionPlato(int platoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Nombre, Descripcion, Precio, Alergenos FROM Platos WHERE PlatoId = @PlatoId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatoId", platoId);
                SqlDataReader reader = command.ExecuteReader();
                FormViewPlato.DataSource = reader;
                FormViewPlato.DataBind();
            }
        }

        private void CargarComentariosPlato(int platoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT NombreUsuario, Comentario, Puntuacion FROM Comentarios WHERE PlatoId = @PlatoId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatoId", platoId);
                SqlDataReader reader = command.ExecuteReader();
                RepeaterComentarios.DataSource = reader;
                RepeaterComentarios.DataBind();
            }
        }

        protected void btnAgregarComentario_Click(object sender, EventArgs e)
        {
            int platoId = Convert.ToInt32(Request.QueryString["PlatoId"]);
            string nombreUsuario = txtNombreUsuario.Text;
            string comentario = txtComentario.Text;
            int puntuacion = Convert.ToInt32(ddlPuntuacion.SelectedValue);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Comentarios (PlatoId, NombreUsuario, Comentario, Puntuacion) VALUES (@PlatoId, @NombreUsuario, @Comentario, @Puntuacion)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatoId", platoId);
                command.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                command.Parameters.AddWithValue("@Comentario", comentario);
                command.Parameters.AddWithValue("@Puntuacion", puntuacion);
                command.ExecuteNonQuery();
            }

            // Limpiar los campos del formulario
            txtNombreUsuario.Text = string.Empty;
            txtComentario.Text = string.Empty;
            ddlPuntuacion.SelectedIndex = 0;

            // Recargar los comentarios actualizados
            CargarComentariosPlato(platoId);
        }
    }
}