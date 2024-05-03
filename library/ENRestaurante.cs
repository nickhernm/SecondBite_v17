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

namespace libraty {
	public class ENRestaurante
	{
		public ENRestaurante()
		{
			public int cod { get; set; } // Clave primaria
	    	public string nombre { get; set; }
	    	public string localidad { get; set; }
	    	public Direccion direccion { get; set; } // Relación con Direccion
	    	public string tipo { get; set; }
	    	public float puntuacion { get; set; }
		}
	}
}
