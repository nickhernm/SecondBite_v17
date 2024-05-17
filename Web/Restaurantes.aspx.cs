using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using library;

namespace Web
{
    public partial class Restaurantes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarRestaurantes();
                CargarComunidades();
                CargarTipos();
                CargarPuntuaciones();
            }
        }

        // Método para cargar los restaurantes desde la base de datos y mostrarlos en el Repeater
        private void CargarRestaurantes()
        {
            ENRestaurante resta = new ENRestaurante();
            if(resta.Read())
            {
                text_Nombre.Text = resta.Nombre.ToString();
                text_Localidad.Text = resta.Localidad.ToString();
                text_Tipo.Text = resta.Tipo.ToString();
                text_Puntuacion.Text = resta.Puntuacion.ToString();
            }

        }

        // Método para cargar las comunidades en el DropDownList
        private void CargarComunidades()
        {
            
        }

        private void CargarTipos()
        {
            
        }

        // Método para cargar las puntuaciones en el DropDownList
        private void CargarPuntuaciones()
        {
            
        }

        // Evento del botón de búsqueda
        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        // Evento del botón de limpiar filtros
        protected void BtnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            
            TxtBuscarRestaurante.Text = string.Empty;
            DdlComunidades.SelectedIndex = 0;
            DdlTipo.SelectedIndex = 0;
            DdlPuntuacion.SelectedIndex = 0;

            
            CargarRestaurantes();
        }
    }
}