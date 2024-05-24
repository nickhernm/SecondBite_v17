using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Favoritos : Page
    {
        private ENFavoritos favorito;
        protected void Page_Load(object sender, EventArgs e)
        {
            favorito = new ENFavoritos();
            //List<ENFavoritos> listFavorito = favorito.ReadAll();
            List<ENPlato> lista = favorito.ReadFavoritosUsu(User.Identity.Name);
            Repeater1.DataSource = lista;
            Repeater1.DataBind();
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