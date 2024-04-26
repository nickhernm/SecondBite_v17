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
	    public ENDireccion()
	    {
	    	public int calle_num { get; set; } // Clave primaria
            public int cod_p { get; set; }
            public string ciudad { get; set; }
            public string comunidad { get; set; }
            public Restaurante restaurante { get; set; } // Relación con Restaurante
            public Cliente cliente { get; set; } // Relación con Cliente
	    }
    }
}