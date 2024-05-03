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
        public int calle_num { get; set; } // Clave primaria
        public int cod_p { get; set; }
        public string ciudad { get; set; }
        public string comunidad { get; set; } // Arreglar tipo de dato Restaurante y Cliente
        //public Restaurante restaurante { get; set; } // Relación con Restaurante
        //public Cliente cliente { get; set; } // Relación con Cliente
        public ENDireccion()
	    {

	    }

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