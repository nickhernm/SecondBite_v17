using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Restaurantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRestaurantes();
                CargarComunidades();
                CargarTipos();
                CargarPuntuaciones();
            }
        }

        // Método para cargar los restaurantes desde la base de datos y mostrarlos en el Repeater
        private void CargarRestaurantes()
        {
            string connectionString = "DataBase.mdf";
            string query = "SELECT Nombre, Localidad, Tipo, Puntuacion, Descripcion, RestauranteId FROM RESTAURANTE";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(table);

                    if (table.Rows.Count > 0)
                    {
                        RepeaterRestaurantes.DataSource = table;
                        RepeaterRestaurantes.DataBind();
                    }
                    else
                    {
                        // No se encontraron restaurantes
                        // Puedes mostrar un mensaje o realizar alguna otra acción
                    }
                }
                catch (Exception ex)
                {
                    // Manejar la excepción
                    // Puedes registrar el error en un log o mostrar un mensaje de error al usuario
                }
            }
        }

        // Método para cargar las comunidades en el DropDownList
        private void CargarComunidades()
        {
            // Aquí debes implementar la lógica para obtener las comunidades desde la base de datos
            // y agregarlas al DropDownList DdlComunidades
        }

        // Método para cargar los tipos de restaurante en el DropDownList
        private void CargarTipos()
        {
            // Aquí debes implementar la lógica para obtener los tipos de restaurante desde la base de datos
            // y agregarlos al DropDownList DdlTipo
        }

        // Método para cargar las puntuaciones en el DropDownList
        private void CargarPuntuaciones()
        {
            // Aquí debes implementar la lógica para obtener las puntuaciones desde la base de datos
            // y agregarlas al DropDownList DdlPuntuacion
        }

        // Evento del botón de búsqueda
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            // Aquí puedes implementar la lógica de búsqueda
            // Por ejemplo, podrías volver a cargar los restaurantes filtrados
            // utilizando los valores seleccionados en los DropDownList y el TextBox de búsqueda
        }

        // Evento del botón de limpiar filtros
        protected void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            // Limpia los valores de los DropDownList y el TextBox de búsqueda
            TxtBuscarRestaurante.Text = string.Empty;
            DdlComunidades.SelectedIndex = 0;
            DdlTipo.SelectedIndex = 0;
            DdlPuntuacion.SelectedIndex = 0;

            // Vuelve a cargar los restaurantes sin filtros
            CargarRestaurantes();
        }
    }
}