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
        public ENCliente(string dni, string correo, string nombre, string telefono)
	    {
            this.dni = dni;
            this.correo = correo;
            this.nombre = nombre;
            this.telefono = telefono;
	    }

        public bool EsRestaurante(string username)
        {
            // Lógica para verificar si el usuario es un restaurante
            // Puedes utilizar la base de datos o cualquier otra forma de verificación
            // Devuelve true si el usuario es un restaurante, false en caso contrario

            // Ejemplo de implementación utilizando una consulta a la base de datos
            CADCliente cadUsuario = new CADCliente();
            return cadUsuario.EsRestaurante(username);
        }

    }
}
