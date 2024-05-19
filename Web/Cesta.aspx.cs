using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace Web
{
    public partial class Cesta : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
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
             using (SqlConnection con = new SqlConnection(connectionString))
             {
                 string query = "SELECT Id, Nombre, Precio, Cantidad FROM CESTA";
                 SqlCommand cmd = new SqlCommand(query, con);
                 con.Open();
                 SqlDataReader reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     items.Add(new ItemCesta(
                         (int)reader["Id"],
                         (string)reader["Nombre"],
                         (decimal)reader["Precio"],
                         (int)reader["Cantidad"]
                     ));
                 }
             }
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
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CESTA";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        protected void gvCesta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int itemId = Convert.ToInt32(gvCesta.DataKeys[index].Value);

            if (e.CommandName == "Eliminar")
            {
                EliminarItemCestaDeBaseDeDatos(itemId);
                Response.Redirect(Request.RawUrl);
            }
            else if (e.CommandName == "DisminuirCantidad")
            {
                DisminuirCantidad(itemId);
                CargarCesta();
            }
            else if (e.CommandName == "AumentarCantidad")
            {
                AumentarCantidad(itemId);
                CargarCesta();
            }

        }

        private void EliminarItemCestaDeBaseDeDatos(int itemId)
        {
            // Lógica para eliminar el elemento de la cesta en la posición 'item' de la base de datos
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM CESTA WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", itemId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private void AumentarCantidad(int itemId)
        {
            // Obtener el artículo correspondiente
            ItemCesta item = ObtenerItemsCestaDesdeBaseDeDatos()[itemId];
            // Aumentar la cantidad
            item.Cantidad++;
            // Lógica para actualizar la cantidad en la base de datos si es necesario
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE CESTA SET Cantidad = Cantidad + 1 WHERE Id = @Id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Id", itemId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void DisminuirCantidad(int itemId)
        {
            // Obtener el artículo correspondiente
            ItemCesta item = ObtenerItemsCestaDesdeBaseDeDatos()[itemId];
            // Disminuir la cantidad si es mayor que 1
            if (item.Cantidad > 1)
            {
                item.Cantidad--;
                // Lógica para actualizar la cantidad en la base de datos si es necesario
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE CESTA SET Cantidad = Cantidad - 1 WHERE Id = @Id AND Cantidad > 1";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", itemId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
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