using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class CambiarMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPlatos();
            }
        }

        protected void gvPlatos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPlatos.Rows[index];
                int platoId = Convert.ToInt32(row.Cells[0].Text);
                CargarPlatoParaEditar(platoId);
            }
            else if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPlatos.Rows[index];
                int platoId = Convert.ToInt32(row.Cells[0].Text);
                EliminarPlato(platoId);
                CargarPlatos();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string alergenos = txtAlergenos.Text;
            float puntuacion = Convert.ToSingle(txtPuntuacion.Text);

            if (string.IsNullOrWhiteSpace(nombre))
            {
                // Mostrar mensaje de error o realizar alguna acción
                return;
            }

            ENPlato plato = new ENPlato();
            plato.Nombre = nombre;
            plato.Alergenos = alergenos;
            plato.Puntuacion = puntuacion;

            if (plato.Id == 0)
            {
                // Agregar nuevo plato
                plato.Create();
            }
            else
            {
                // Actualizar plato existente
                plato.Update();
            }

            CargarPlatos();
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void CargarPlatos()
        {
            ENPlato enPlato = new ENPlato();
            List<ENPlato> platos = enPlato.ReadAll();
            gvPlatos.DataSource = platos;
            gvPlatos.DataBind();
        }

        private void CargarPlatoParaEditar(int platoId)
        {
            ENPlato plato = new ENPlato();
            plato.Id = platoId;
            if (plato.Read())
            {
                txtNombre.Text = plato.Nombre;
                txtAlergenos.Text = plato.Alergenos;
                txtPuntuacion.Text = plato.Puntuacion.ToString();
            }
        }

        private void EliminarPlato(int platoId)
        {
            ENPlato plato = new ENPlato();
            plato.Id = platoId;
            plato.Delete();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtAlergenos.Text = string.Empty;
            txtPuntuacion.Text = string.Empty;
        }
    }
}