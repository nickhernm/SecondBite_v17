using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Menu : System.Web.UI.Page
    {
        //private object gvPlatosDestacados;
        protected GridView gvPlatosDestacados;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatosDestacados();
            }
        }

        private void CargarPlatosDestacados()
        {
            ENPlato enPlato = new ENPlato();
            List<ENPlato> platosDestacados = enPlato.ObtenerPlatosDestacados();
            gvPlatosDestacados.DataSource = platosDestacados;
            gvPlatosDestacados.DataBind();
        }
    }
}