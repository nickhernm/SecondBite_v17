using System;
using System.Web.UI;

namespace Web
{
    public partial class Quienes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contact.aspx");
        }
    }
}
