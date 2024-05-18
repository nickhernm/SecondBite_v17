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

                if (CestaEstaVacia())
                {
                    lblMensajeCestaVacia.Visible = true;
                    lblTotalEuros.Visible = false; //ocultar el precio total si la cesta esta vacia
                }
                else
                {
                    lblMensajeCestaVacia.Visible = false;
                    lblTotalEuros.Visible = true;
                }

                // Calcular y mostrar el precio total en euros
                double totalEuros = CalcularPrecioTotalEnEuros();
                lblTotalEuros.Text = totalEuros.ToString("C", System.Globalization.CultureInfo.CreateSpecificCulture("es-ES"));
            }

            
        }
        private bool CestaEstaVacia()
        {
            // Lógica para verificar si la cesta está vacía
            return gvCesta.Rows.Count == 0;
        }

        private double CalcularPrecioTotalEnEuros()
        {
            List<ItemCesta> items = ObtenerItemsCestaDesdeBaseDeDatos();
            double totalEuros = items.Sum(item => Convert.ToDouble(item.Precio));
            return totalEuros;
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
            VaciarCestaEnBaseDeDatos();

            // Recargar la página para reflejar los cambios
            Response.Redirect(Request.RawUrl);
        }
        private void VaciarCestaEnBaseDeDatos()
        {
            // Lógica para vaciar la cesta en la base de datos
            // Esto podría implicar eliminar todos los registros de la tabla que representa la cesta
        }

        protected void gvCesta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // Lógica para eliminar el elemento de la cesta en la posición 'index'
                //eliminar el elemento de la base de datos en la posición 'index'
                EliminarItemCestaDeBaseDeDatos(index);

                // Recargar la página para reflejar los cambios
                Response.Redirect(Request.RawUrl);
            }
            if (e.CommandName == "DisminuirCantidad")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // Disminuir la cantidad del artículo en la posición 'index'
                DisminuirCantidad(index);
                // Recargar la cesta
                CargarCesta();
            }
            else if (e.CommandName == "AumentarCantidad")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                // Aumentar la cantidad del artículo en la posición 'index'
                AumentarCantidad(index);
                // Recargar la cesta
                CargarCesta();
            }

        }

        private void EliminarItemCestaDeBaseDeDatos(int index)
        {
            // Lógica para eliminar el elemento de la cesta en la posición 'index' de la base de datos
        }
        private void AumentarCantidad(int index)
        {
            // Obtener el artículo correspondiente
            ItemCesta item = ObtenerItemsCestaDesdeBaseDeDatos()[index];
            // Aumentar la cantidad
            item.Cantidad++;
            // Lógica para actualizar la cantidad en la base de datos si es necesario
        }

        private void DisminuirCantidad(int index)
        {
            // Obtener el artículo correspondiente
            ItemCesta item = ObtenerItemsCestaDesdeBaseDeDatos()[index];
            // Disminuir la cantidad si es mayor que 1
            if (item.Cantidad > 1)
            {
                item.Cantidad--;
                // Lógica para actualizar la cantidad en la base de datos si es necesario
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