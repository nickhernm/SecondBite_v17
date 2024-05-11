using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GoSignIn(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }
        protected void GoLogIn(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
        protected void GoPerfil(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }
    }
}