using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using library;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace Web
{
    public partial class Login : Page
    {
        private ENUsuarioRestaurante usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            ContentPlaceHolder navigation = (ContentPlaceHolder)this.Master.FindControl("navBar");
            if (navigation != null)
            {
                navigation.Visible = false;
            }
        }

        protected void LoginUsu(object sender, EventArgs e)
        {
            try
            {
                string name = TextBox1.Text;
                string contrasena = TextBox2.Text;


                usuario = new ENUsuarioRestaurante(contrasena, name);
                if (usuario.CheckUser())
                {
                    Response.Redirect("Pedidos.aspx");
                }
                else
                {
                    lblMessage.Text = "Usuario Incorrecto";
                    TextBox2.Text = "";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Login has failed. Error: {0}", ex.Message);
            }

        }

        protected string GetCardContent()
        {
            // Logic to retrieve dynamic content
            return "Dynamic card content";
        }
    }
}