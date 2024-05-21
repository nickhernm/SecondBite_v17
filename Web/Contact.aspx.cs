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
                new FAQ { Pregunta = "¿Cuál es el horario de atención?", Respuesta = "Nuestro horario de atención es de lunes a viernes de 9:00 AM a 1:00 AM." },
                new FAQ { Pregunta = "¿Cómo puedo realizar un pedido?", Respuesta = "Puedes realizar un pedido a través de nuestra página web o contactándonos por teléfono o correo electrónico." },
                new FAQ { Pregunta = "¿Cuál es el tiempo de entrega?", Respuesta = "El tiempo de entrega varía según la ubicación y el tipo de producto. Contáctanos para más información." },
                new FAQ { Pregunta = "¿Cómo puedo añadir mi restaurante a su plataforma?", Respuesta = " Puedes registrarte como usuario y seguir las instrucciones para añadir tu restaurante. Nuestro equipo revisará la información y se pondrá en contacto contigo." },
                new FAQ { Pregunta = "¿Cómo se indica si un plato contiene alérgenos?", Respuesta = "Cada plato en nuestro sitio tiene una lista de alérgenos incluidos, como soja, pescado y más." },
                new FAQ { Pregunta = "¿Cómo puedo dejar una opinión sobre un restaurante o un plato?", Respuesta = "Debes estar registrado en nuestra plataforma. Una vez registrado, puedes dejar opiniones y puntuaciones en la página del restaurante o del plato." },
                new FAQ { Pregunta = "¿Cómo puedo contactar con el servicio de atención al cliente?", Respuesta = " Puedes enviarnos un mensaje a través de la sección de contacto en nuestro sitio o llamarnos al número de teléfono proporcionado." }
            };

            // Asignar los datos al repeater
            rptFAQs.DataSource = faqs;
            rptFAQs.DataBind();
        }

        // Clase para representar una pregunta frecuente
        public class FAQ
        {
            public int Id { get; set; }
            public string Pregunta { get; set; }
            public string Respuesta { get; set; }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
           
        }

 
    }
}