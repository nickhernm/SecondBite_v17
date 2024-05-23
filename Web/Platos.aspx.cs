using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Platos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatos();
            }
        }

        private void CargarPlatos()
        {
            ENPlato enPlato = new ENPlato();
            List<ENPlato> listaPlatos = enPlato.ReadAll();
            rptPlatos.DataSource = listaPlatos;
            rptPlatos.DataBind();
        }

        protected void rptPlatos_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "VerDetalles")
            {
                int platoId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Plato_Individual.aspx");
            }
        }
    }
}