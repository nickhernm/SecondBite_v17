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

namespace library {
    public class ENCliente
    {
        public string dni { get; set; } // Clave primaria
        public string correo { get; set; }
        public string nombre { get; set; } // Arreglar problme con tipo de dato Direccion
       // public Direccion direccion { get; set; } // Relación con Direccion
        public string telefono { get; set; }
        public ENCliente()
	    {

	    }
        public bool Create()
        {
            CADCliente cli = new CADCliente();
            bool create = cli.Create(this);
            return create;
        }

        public bool Update()
        {
            CADCliente cli = new CADCliente();
            bool update = cli.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADCliente cli = new CADCliente();
            bool delete = cli.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADCliente cli = new CADCliente();
            bool read = cli.Read(this);
            return read;
        }
    }
}
