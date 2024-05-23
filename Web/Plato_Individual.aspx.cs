using System;
using System.Collections.Generic;
using System.Web.UI;
using library;

namespace Web
{
    public partial class Plato_Individual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int platoId = Convert.ToInt32(Request.QueryString["PlatoId"]);
                CargarDetallesPlato(platoId);
            }
        }

        private void CargarDetallesPlato(int platoId)
        {
            ENPlato plato = new ENPlato();
            plato.Id = platoId;
            if (plato.Read())
            {
                fvPlato.DataSource = new List<ENPlato> { plato };
                fvPlato.DataBind();
            }
        }
    }
}