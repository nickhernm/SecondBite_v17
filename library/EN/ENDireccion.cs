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
    public class ENDireccion
    {
        public string NombreCalle { get; set; }
        public int CalleNumero { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Comunidad { get; set; }
        public int RestauranteId { get; set; } // Clave foránea para la tabla Restaurante
        public string ClienteCorreo { get; set; } // Clave foránea para la tabla Usuario

        // Constructor vacío
        public ENDireccion() { }

        public bool Create()
        {
            CADDireccion dir = new CADDireccion();
            bool create = dir.Create(this);
            return create;
        }

        public bool Update()
        {
            CADDireccion dir = new CADDireccion();
            bool update = dir.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADDireccion dir = new CADDireccion();
            bool delete = dir.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADDireccion dir = new CADDireccion();
            bool read = dir.Read(this);
            return read;
        }

    }
}