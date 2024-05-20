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

            /*txtTitle.Text = "Sandwich Gourmet Universitario (Vegano) 160 kcal";
            txtContent.Text = "Sandwich Gourmet con un total 160 kcal /n Pan, Queso, Lechuga";
            txtPrice.Text = "1.30€";
            txtOrder.Text = "Pedido nº:02-05-2024:000001";
            txtPriceTotal.Text = "Total: 2.60€";*/
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