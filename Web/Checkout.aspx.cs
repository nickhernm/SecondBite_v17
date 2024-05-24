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
                
                decimal total = 00.00m; 
                lblTotalCheckout.Text = $"Total: {total:C}";
            }
        }

        protected void ddlMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlCardDetails.Visible = ddlMetodoPago.SelectedValue == "Card";

            btnPagar.ValidationGroup = ddlMetodoPago.SelectedValue == "Card" ? "CardGroup" : "";
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            if (ddlMetodoPago.SelectedValue == "Card")
            {
                Page.Validate("CardGroup");
            }

            if (Page.IsValid)
            {
                string direccion = txtDireccion.Text;
                string metodoPago = ddlMetodoPago.SelectedValue;
                string numeroTarjeta = metodoPago == "Card" ? txtNumeroTarjeta.Text : null;
                string fechaVencimiento = metodoPago == "Card" ? txtFechaVencimiento.Text : null;
                string usuarioCorreo = "usuario@example.com";

                GuardarMetodoPago(metodoPago, numeroTarjeta, fechaVencimiento, usuarioCorreo);

                Response.Redirect("Default.aspx");
            }
        }

        private void GuardarMetodoPago(string tipo, string numeroTarjeta, string fechaVencimiento, string usuarioCorreo)
        {
           /* connectionString = ConfigurationManager.ConnectionStrings["DataBase"].ConnectionString; // Reemplaza con tu cadena de conexión
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
            }*/
        }
    }
}