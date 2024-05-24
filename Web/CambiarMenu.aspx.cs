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
                int platoId = Convert.ToInt32(gvPlatos.DataKeys[index].Value);
                CargarPlatoParaEditar(platoId);
            }
            else if (e.CommandName == "Eliminar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int platoId = Convert.ToInt32(gvPlatos.DataKeys[index].Value);
                EliminarPlato(platoId);
                CargarPlatos();
            }
        }

        protected void gvPlatos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPlatos.PageIndex = e.NewPageIndex;
            CargarPlatos();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string alergenos = txtAlergenos.Text;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                return;
            }

            ENPlato plato = new ENPlato
            {
                Nombre = nombre,
                Alergenos = alergenos
            };

            if (plato.Id == 0)
            {
                plato.Create();
            }
            else
            {
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
            ENPlato plato = new ENPlato { Id = platoId };
            if (plato.Read())
            {
                txtNombre.Text = plato.Nombre;
                txtAlergenos.Text = plato.Alergenos;
            }
        }

        private void EliminarPlato(int platoId)
        {
            ENPlato plato = new ENPlato { Id = platoId };
            plato.Delete();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtAlergenos.Text = string.Empty;
        }
    }
}