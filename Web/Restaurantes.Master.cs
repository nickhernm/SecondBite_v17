using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Restaurantes : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Simular una lista de restaurantes
                List<Restaurante> listaRestaurantes = ObtenerListaRestaurantes();

            }
        }

        private List<Restaurante> ObtenerListaRestaurantes()
        {
            // Aquí simulamos una lista de restaurantes
            List<Restaurante> lista = new List<Restaurante>();
            lista.Add(new Restaurante("Restaurante 1", "Descripción del Restaurante 1"));
            lista.Add(new Restaurante("Restaurante 2", "Descripción del Restaurante 2"));
            lista.Add(new Restaurante("Restaurante 3", "Descripción del Restaurante 3"));
            return lista;
        }
    }

    public class Restaurante
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Restaurante(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }
    }
}