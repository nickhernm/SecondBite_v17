using library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Web.Contact;

namespace Web
{
    public partial class FAQS : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadFAQs();
        }

        private void LoadFAQs()
        {
            // Simulación de preguntas frecuentes
            List<ENFAQ> faqs = new List<ENFAQ>
            {
                new ENFAQ { Pregunta = "¿Cuál es el horario de atención?", Respuesta = "Nuestro horario de atención es de lunes a viernes de 9:00 AM a 1:00 AM." },
                new ENFAQ { Pregunta = "¿Cómo puedo realizar un pedido?", Respuesta = "Puedes realizar un pedido a través de nuestra página web o contactándonos por teléfono o correo electrónico." },
                new ENFAQ { Pregunta = "¿Cuál es el tiempo de entrega?", Respuesta = "El tiempo de entrega varía según la ubicación y el tipo de producto. Contáctanos para más información." },
                new ENFAQ { Pregunta = "¿Cómo puedo añadir mi restaurante a su plataforma?", Respuesta = " Puedes registrarte como usuario y seguir las instrucciones para añadir tu restaurante. Nuestro equipo revisará la información y se pondrá en contacto contigo." },
                new ENFAQ { Pregunta = "¿Cómo se indica si un plato contiene alérgenos?", Respuesta = "Cada plato en nuestro sitio tiene una lista de alérgenos incluidos, como soja, pescado y más." },
                new ENFAQ { Pregunta = "¿Cómo puedo dejar una opinión sobre un restaurante o un plato?", Respuesta = "Debes estar registrado en nuestra plataforma. Una vez registrado, puedes dejar opiniones y puntuaciones en la página del restaurante o del plato." },
                new ENFAQ { Pregunta = "¿Cómo puedo contactar con el servicio de atención al cliente?", Respuesta = " Puedes enviarnos un mensaje a través de la sección de contacto en nuestro sitio o llamarnos al número de teléfono proporcionado." }
            };

            // Asignar los datos al repeater
            rptFAQs.DataSource = faqs;
            rptFAQs.DataBind();
        }

    }
}