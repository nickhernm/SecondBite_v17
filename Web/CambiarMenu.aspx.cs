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
    public partial class CambiarMenu : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        private int platoId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatos();
                LimpiarCampos();
            }
        }

        protected void gvPlatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                platoId = Convert.ToInt32(e.CommandArgument);
                CargarPlatoParaEditar(platoId);
                ltlTituloAccion.Text = "Editar Plato";
            }
            else if (e.CommandName == "Eliminar")
            {
                platoId = Convert.ToInt32(e.CommandArgument);
                EliminarPlato(platoId);
                CargarPlatos();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePlato.Text;
            string descripcion = txtDescripcion.Text;
            decimal precio = Convert.ToDecimal(txtPrecio.Text);
            string categoria = ddlCategoria.SelectedValue;
            string alergenos = string.Join(", ", cblAlergenos.Items.Cast<ListItem>().Where(item => item.Selected).Select(item => item.Value));

            if (platoId == 0)
            {
                AgregarPlato(nombre, descripcion, precio, categoria, alergenos);
            }
            else
            {
                ActualizarPlato(platoId, nombre, descripcion, precio, categoria, alergenos);
            }

            CargarPlatos();
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void CargarPlatos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Nombre, Descripcion, Precio, Categoria, Alergenos FROM Platos";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                gvPlatos.DataSource = reader;
                gvPlatos.DataBind();
            }
        }

        private void CargarPlatoParaEditar(int platoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Nombre, Descripcion, Precio, Categoria, Alergenos FROM Platos WHERE Id = @PlatoId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatoId", platoId);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtNombrePlato.Text = reader["Nombre"].ToString();
                    txtDescripcion.Text = reader["Descripcion"].ToString();
                    txtPrecio.Text = reader["Precio"].ToString();
                    ddlCategoria.SelectedValue = reader["Categoria"].ToString();
                    string[] alergenos = reader["Alergenos"].ToString().Split(',');
                    foreach (ListItem item in cblAlergenos.Items)
                    {
                        item.Selected = alergenos.Contains(item.Value.Trim());
                    }
                }
            }
        }

        private void AgregarPlato(string nombre, string descripcion, decimal precio, string categoria, string alergenos)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Platos (Nombre, Descripcion, Precio, Categoria, Alergenos) VALUES (@Nombre, @Descripcion, @Precio, @Categoria, @Alergenos)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@Precio", precio);
                command.Parameters.AddWithValue("@Categoria", categoria);
                command.Parameters.AddWithValue("@Alergenos", alergenos);
                command.ExecuteNonQuery();
            }
        }

        private void ActualizarPlato(int platoId, string nombre, string descripcion, decimal precio, string categoria, string alergenos)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Platos SET Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio, Categoria = @Categoria, Alergenos = @Alergenos WHERE Id = @PlatoId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatoId", platoId);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@Precio", precio);
                command.Parameters.AddWithValue("@Categoria", categoria);
                command.Parameters.AddWithValue("@Alergenos", alergenos);
                command.ExecuteNonQuery();
            }
        }

        private void EliminarPlato(int platoId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Platos WHERE Id = @PlatoId";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@PlatoId", platoId);
                command.ExecuteNonQuery();
            }
        }

        private void LimpiarCampos()
        {
            txtNombrePlato.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtPrecio.Text = string.Empty;
            ddlCategoria.SelectedIndex = 0;
            foreach (ListItem item in cblAlergenos.Items)
            {
                item.Selected = false;
            }
            platoId = 0;
            ltlTituloAccion.Text = "Agregar Plato";
        }
    }
}