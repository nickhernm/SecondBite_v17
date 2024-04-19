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
	    public ENCliente()
	    {
	    	public string dni { get; set; } // Clave primaria
            public string correo { get; set; }
            public string nombre { get; set; }
            public Direccion direccion { get; set; } // Relación con Direccion
            public string telefono { get; set; }
	    }
    }
}
