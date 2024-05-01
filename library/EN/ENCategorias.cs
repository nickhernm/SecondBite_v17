using System;

namespace library 
{ 
		public class ENCategorias
		{
			public int Id { get; set; }
			public string Nombre { get; set; }
			public string Descripcion { get; set; }
			public int Valoracion { get; set; }
			
			// Constructor
			public ENCategoria(int id, string nombre, string descripcion, float valoracion)
			{
				Id = id;
				Nombre = nombre;
				Descripcion = descripcion;
				Valoracion = valoracion;
			}

		}
}
