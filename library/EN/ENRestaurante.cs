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
        public int cod { get; set; } // Clave primaria
        public string nombre { get; set; }
        public string localidad { get; set; }
        //public Direccion direccion { get; set; } // Relación con Direccion || Arreglar tipo de dato Direccion
        public string tipo { get; set; }
        public float puntuacion { get; set; }
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
