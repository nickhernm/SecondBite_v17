using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace library
{
    public class ENFAQ
    {
        public int Id { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }

        public ENFAQ() { }

        public ENFAQ(int id, string pregunta, string respuesta)
        {
            this.Id = id;
            this.Pregunta = pregunta;
            this.Respuesta = respuesta;
        }

        public bool Create()
        {
            CADFAQ cad = new CADFAQ();
            return cad.Create(this);
        }

        public bool Read()
        {
            CADFAQ cad = new CADFAQ();
            return cad.Read(this);
        }

        public bool Update()
        {
            CADFAQ cad = new CADFAQ();
            return cad.Update(this);
        }

        public bool Delete()
        {
            CADFAQ cad = new CADFAQ();
            return cad.Delete(this);
        }
    }
}
