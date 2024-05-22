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
    public partial class Checkout : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                decimal total = 100.00m; // Ejemplo de total
                lblTotalCheckout.Text = $"Total: {total:C}";
            }
        }

        protected void ddlMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Mostrar u ocultar los detalles de la tarjeta según el método de pago seleccionado
            pnlCardDetails.Visible = ddlMetodoPago.SelectedValue == "Card";

            // Cambiar el grupo de validación del botón de pagar
            btnPagar.ValidationGroup = ddlMetodoPago.SelectedValue == "Card" ? "CardGroup" : "";
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            // Validar el grupo específico si el método de pago es Tarjeta
            if (ddlMetodoPago.SelectedValue == "Card")
            {
                Page.Validate("CardGroup");
            }

            if (Page.IsValid)
            {
                // Obtener la dirección de envío y método de pago
                string direccion = txtDireccion.Text;
                string metodoPago = ddlMetodoPago.SelectedValue;
                string numeroTarjeta = metodoPago == "Card" ? txtNumeroTarjeta.Text : null;
                string fechaVencimiento = metodoPago == "Card" ? txtFechaVencimiento.Text : null;
                string usuarioCorreo = "usuario@example.com"; // Deberías obtener esto del usuario autenticado

                // Lógica para procesar el pago y crear el pedido
                GuardarMetodoPago(metodoPago, numeroTarjeta, fechaVencimiento, usuarioCorreo);

                // Redirigir a la página de inicio
                Response.Redirect("Default.aspx");
            }
        }

        private void GuardarMetodoPago(string tipo, string numeroTarjeta, string fechaVencimiento, string usuarioCorreo)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString; // Reemplaza con tu cadena de conexión
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO METODO_PAGO (tipo, numero_tarjeta, fecha_vencimiento, usuario_correo) VALUES (@tipo, @numero_tarjeta, @fecha_vencimiento, @usuario_correo)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@tipo", tipo);
                    command.Parameters.AddWithValue("@numero_tarjeta", numeroTarjeta ?? (object)DBNull.Value);
                    command.Parameters.AddWithValue("@fecha_vencimiento", string.IsNullOrEmpty(fechaVencimiento) ? (object)DBNull.Value : DateTime.ParseExact(fechaVencimiento, "MM/yy", null));
                    command.Parameters.AddWithValue("@usuario_correo", usuarioCorreo);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}