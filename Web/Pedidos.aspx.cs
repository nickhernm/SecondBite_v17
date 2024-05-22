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
            List<ENPedido> listPedido = pedido.ReadAll();
            System.Diagnostics.Debug.WriteLine("aaaaa");
            System.Diagnostics.Debug.WriteLine(listPedido);
            System.Diagnostics.Debug.WriteLine("aaaaa");
            System.Diagnostics.Debug.WriteLine(listPedido[0]);
            System.Diagnostics.Debug.WriteLine("aaaaaimp");
            System.Diagnostics.Debug.WriteLine(listPedido[0].lineasPedido[0].importe);
            Repeater1.DataSource = listPedido;
            Repeater1.DataBind();
            //productList = listPedido;


        }

        protected void Delete(object sender, EventArgs e)
        {
            // Your delete logic here
        }

        protected string GetCardContent()
        {
            // Logic to retrieve dynamic content
            return "Dynamic card content";
        }
    }
}