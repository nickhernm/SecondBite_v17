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
        public string dni { get; set; } 
        public string correo { get; set; }
        public string nombre { get; set; } 
       // public Direccion direccion { get; set; } 
        public string telefono { get; set; }
        public ENCliente(string dni, string correo, string nombre, string telefono)
	    {
            this.dni = dni;
            this.correo = correo;
            this.nombre = nombre;
            this.telefono = telefono;
	    }

        public bool EsRestaurante(string username)
        {
            CADCliente cadUsuario = new CADCliente();
            return cadUsuario.EsRestaurante(username);
        }

    }
}
