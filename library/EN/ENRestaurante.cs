﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace library {
    public class ENRestaurante
    {
        public int Cod { get; set; } // Clave primaria
        public string Nombre { get; set; }
        public string Localidad { get; set; }
        public string Tipo { get; set; }
        public float Puntuacion { get; set; }

        public ENRestaurante()
        {

        }

        public bool Create()
        {
            CADRestaurante res = new CADRestaurante();
            bool create = res.Create(this);
            return create;
        }

        public bool Update()
        {
            CADRestaurante res = new CADRestaurante();
            bool update = res.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADRestaurante res = new CADRestaurante();
            bool delete = res.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADRestaurante res = new CADRestaurante();
            bool read = res.Read(this);
            return read;
        }
    }
}
