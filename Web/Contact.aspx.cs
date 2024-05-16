using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail; // Agregar esta línea para usar la clase SmtpClient

namespace Web
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Cargar las preguntas frecuentes
                LoadFAQs();
            }

        }

        private void LoadFAQs()
        {
            // Simulación de preguntas frecuentes
            List<FAQ> faqs = new List<FAQ>
            {
                new FAQ { Pregunta = "¿Cuál es el horario de atención?", Respuesta = "Nuestro horario de atención es de lunes a viernes de 9:00 AM a 5:00 PM." },
                new FAQ { Pregunta = "¿Cómo puedo realizar un pedido?", Respuesta = "Puedes realizar un pedido a través de nuestra página web o contactándonos por teléfono o correo electrónico." },
                new FAQ { Pregunta = "¿Cuál es el tiempo de entrega?", Respuesta = "El tiempo de entrega varía según la ubicación y el tipo de producto. Contáctanos para más información." }
            };

            // Asignar los datos al repeater
            rptFAQs.DataSource = faqs;
            rptFAQs.DataBind();
        }

        // Clase para representar una pregunta frecuente
        public class FAQ
        {
            public string Pregunta { get; set; }
            public string Respuesta { get; set; }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
           
        }

 
    }
}