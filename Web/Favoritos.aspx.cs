using library;
using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        private static List<ENPlato> platosFavoritos;
        private static List<ENPlato> compras;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatosFavoritos();
            }
        }

        private void CargarPlatosFavoritos()
        {
            List<ENPlato> platosFavoritos = ObtenerPlatosFavoritos();
            Repeater1.DataSource = platosFavoritos;
        }

        private List<ENPlato> ObtenerPlatosFavoritos()
        {
            return new List<ENPlato>
            {
                new ENPlato { Id = 1, Nombre = "Paella", Alergenos = "Mariscos, Pescado", Puntuacion = 4.5f  },
                new ENPlato { Id = 2, Nombre = "Tacos", Alergenos = "Gluten, Lactosa", Puntuacion = 4.8f},
                new ENPlato { Id = 3, Nombre = "Sushi", Alergenos = "Pescado, Soja", Puntuacion = 4.7f },
                new ENPlato { Id = 4, Nombre = "Pizza", Alergenos = "Gluten, Lactosa", Puntuacion = 4.6f },
                new ENPlato { Id = 5, Nombre = "Hamburguesa", Alergenos = "Gluten", Puntuacion = 4.9f }
            };
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int platoId = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "RemoveFavorite")
            {
                EliminarPlatoFavorito(platoId);
            }
            else if (e.CommandName == "Buy")
            {
                ComprarPlato(platoId);
            }
        }

        private void EliminarPlatoFavorito(int platoId)
        {
            ENPlato plato = platosFavoritos.Find(p => p.Id == platoId);
            if (plato != null)
            {
                platosFavoritos.Remove(plato);
                CargarPlatosFavoritos();
                Response.Write($"Plato '{plato.Nombre}' eliminado de favoritos.");
            }
        }

        private void ComprarPlato(int platoId)
        {

            ENPlato plato = platosFavoritos.Find(p => p.Id == platoId);
            if (plato != null)
            {
                compras.Add(plato);
                Response.Write($"Plato '{plato.Nombre}' comprado.");
            }
        }
    }
}