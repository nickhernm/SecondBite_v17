using System;
using System.Collections.Generic;
using System.Web.UI;
using library;

namespace Web
{
    public partial class Pedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPedidos();
            }
        }

        private void CargarPedidos()
        {
            ENPedido pedido = new ENPedido();
            List<ENPedido> listaPedidos = pedido.ReadAll();
            rptPedidos.DataSource = listaPedidos;
            rptPedidos.DataBind();
        }
    }
}