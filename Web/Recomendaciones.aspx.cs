using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Recomendaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            txtContent.Text = "Sandwich Gourmet con un total 160 kcal /n Pan, Queso, Lechuga";
            txtPrice.Text = "1.30€";
        }
    }
}

