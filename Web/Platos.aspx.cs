using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Platos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAnadirCesta_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string platoId = btn.CommandArgument;
            Console.WriteLine("Se ha añadido el plato con ID: " + platoId + " a la cesta.");
        }
    }
}