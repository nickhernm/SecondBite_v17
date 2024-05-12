using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Web
{
    public partial class CambiarMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lógica para cargar el menú actual del restaurante
                CargarMenuActual();
            }
        }

        private void CargarMenuActual()
        {
            // Lógica para cargar el menú actual del restaurante desde la base de datos
            // Por ahora, solo simularé la carga de datos con un DataTable vacío

            DataTable dtMenuActual = new DataTable();
            dtMenuActual.Columns.Add("Nombre", typeof(string));
            dtMenuActual.Columns.Add("Alergenos", typeof(string));
            dtMenuActual.Columns.Add("Puntuacion", typeof(float));

            // Agregamos algunas filas de ejemplo
            dtMenuActual.Rows.Add("Plato 1", "Gluten", 4.5f);
            dtMenuActual.Rows.Add("Plato 2", "Lácteos", 3.8f);
            dtMenuActual.Rows.Add("Plato 3", "Frutos secos", 4.2f);

            // Asignamos el DataTable como origen de datos del GridView
            gridMenuActual.DataSource = dtMenuActual;
            gridMenuActual.DataBind();
        }

    }
}
