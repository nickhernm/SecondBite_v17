using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Platos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatos();
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            CargarPlatos();
        }

        private void CargarPlatos()
        {
            List<ENPlato> platos = ObtenerPlatosFiltrados();
            if (platos != null && platos.Count > 0)
            {
                rptPlatos.DataSource = platos;
                rptPlatos.DataBind();
            }
            else
            {
                lblMensaje.Text = "No hay platos disponibles con los filtros seleccionados.";
                lblMensaje.Visible = true;
                rptPlatos.DataSource = null;
                rptPlatos.DataBind();
            }
        }

        private List<ENPlato> ObtenerPlatosFiltrados()
        {
            List<ENPlato> platos = new List<ENPlato>();
            string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;

            string filtroAlergenos = ddlAlergenos.SelectedValue;
            string filtroPuntuacion = ddlPuntuacion.SelectedValue;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT Id, Nombre, Alergenos, Puntuacion FROM PLATO WHERE 1=1";

                    if (!string.IsNullOrEmpty(filtroAlergenos))
                    {
                        query += " AND Alergenos = @Alergenos";
                    }

                    if (!string.IsNullOrEmpty(filtroPuntuacion))
                    {
                        if (filtroPuntuacion == "5")
                        {
                            query += " AND Puntuacion = 5";
                        }
                        else if (filtroPuntuacion == "4")
                        {
                            query += " AND Puntuacion >= 4";
                        }
                        else if (filtroPuntuacion == "3")
                        {
                            query += " AND Puntuacion >= 3";
                        }
                    }

                    SqlCommand command = new SqlCommand(query, connection);

                    if (!string.IsNullOrEmpty(filtroAlergenos))
                    {
                        command.Parameters.AddWithValue("@Alergenos", filtroAlergenos);
                    }

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ENPlato plato = new ENPlato
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Alergenos = reader["Alergenos"].ToString(),
                            Puntuacion = Convert.ToSingle(reader["Puntuacion"])
                        };
                        platos.Add(plato);
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine("Error al obtener los platos: " + ex.Message);
            }

            return platos;
        }

        protected void btnVerDetalles_Click(object sender, EventArgs e)
        {
            int platoId = Convert.ToInt32((sender as Button).CommandArgument);
            Response.Redirect("Plato_Individual.aspx?PlatoId=" + platoId);
        }
    }
}
