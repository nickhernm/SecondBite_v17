using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Pedidos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtTitle.Text = "Sandwich Gourmet Universitario (Vegano) 160 kcal";
            txtContent.Text = "Sandwich Gourmet con un total 160 kcal /n Pan, Queso, Lechuga";
            txtPrice.Text = "1.30€";
            txtOrder.Text = "Pedido nº:02-05-2024:000001";
            txtPriceTotal.Text = "Total: 2.60€";
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