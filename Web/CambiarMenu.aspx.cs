using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using library;

namespace Web
{
    public partial class CambiarMenu : System.Web.UI.Page
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ConexionBD"].ConnectionString;
        private int platoId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatos();
                LimpiarCampos();
            }
        }

        protected void gvPlatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void CargarPlatos()
        {
            
        }

        private void CargarPlatoParaEditar(int platoId)
        {
           
        }

        private void AgregarPlato(string nombre, string descripcion, decimal precio, string categoria, string alergenos)
        {
           
        }

        private void ActualizarPlato(int platoId, string nombre, string descripcion, decimal precio, string categoria, string alergenos)
        {
            
        }

        private void EliminarPlato(int platoId)
        {
            
        }

        private void LimpiarCampos()
        {
            
        }
    }
}