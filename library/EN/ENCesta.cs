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
    public class EnCesta
    {
	    public EnCesta()
	    {
	    	public int id { get; set; } // Clave primaria
            public Cliente cliente { get; set; } // Relación con Cliente
            public List<Plato> Platos { get; set; } // Relación con Platos
	    }
    }
}
