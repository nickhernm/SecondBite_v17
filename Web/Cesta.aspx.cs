using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Cesta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Lógica para cargar la cesta desde la base de datos
                CargarCesta();
            }
        }

        private void CargarCesta()
        {
            // Lógica para cargar la cesta desde la base de datos
            List<ItemCesta> items = ObtenerItemsCestaDesdeBaseDeDatos();
            gvCesta.DataSource = items;
            gvCesta.DataBind();
        }

        private List<ItemCesta> ObtenerItemsCestaDesdeBaseDeDatos()
        {
            List<ItemCesta> items = new List<ItemCesta>();
            // Agregar elementos a la lista (desde una base de datos)
            return items;
        }

        protected void btnVaciarCesta_Click(object sender, EventArgs e)
        {
            // Lógica para vaciar la cesta
            //eliminar todos los elementos de la base de datos
        }

        protected void gvCesta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // Lógica para eliminar el elemento de la cesta en la posición 'index'
                //eliminar el elemento de la base de datos en la posición 'index'
            }
        }
    }

    public class ItemCesta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public ItemCesta(int Id, string nombre, decimal precio, int cantidad)
        {
            //Id = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}