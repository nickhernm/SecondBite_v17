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
            if (!IsPostBack)
            {
                UpdateButtonVisibility();
            }
        }

        private void UpdateButtonVisibility()
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                PanelAnonymous.Visible = false;
                PanelAuthenticated.Visible = true;
            }
            else
            {
                PanelAnonymous.Visible = true;
                PanelAuthenticated.Visible = false;
            }
        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx");
        }
    }
}