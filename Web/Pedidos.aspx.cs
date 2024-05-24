using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Web
{
    public partial class Pedidos : Page
    {
        private ENPedido pedido;
        protected void Page_Load(object sender, EventArgs e)
        {

            pedido = new ENPedido();
            //pedido.ReadAll();
            List<ENPedido> listPedido = pedido.ReadpedidosUsu(User.Identity.Name);
            System.Diagnostics.Debug.WriteLine("aaaaa");
            System.Diagnostics.Debug.WriteLine(listPedido);
            System.Diagnostics.Debug.WriteLine("aaaaa");
            System.Diagnostics.Debug.WriteLine("aaaaaimp");
            Repeater1.DataSource = listPedido;
            Repeater1.DataBind();
            //productList = listPedido;


        }

        protected void Delete(object sender, EventArgs e)
        {
        }

        protected string GetCardContent()
        {
            return "Dynamic card content";
        }
    }
}