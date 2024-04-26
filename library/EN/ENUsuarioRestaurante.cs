using System;

namespace library 
{
	public class ENUsuarioRestaurante
	{
        public string Nif
        {
            get { return Nif; }
            set { Nif = value; }
        }

        public string Nombre
        {
            get { return Nombre; }
            set { Nombre = value; }
        }

        public string Correo
        {
            get { return Correo; }
            set { Correo = value; }
        }

        public string Telefono
        {
            get { return Telefono; }
            set { Telefono = value; }
        }

        public ENUsuarioRestaurante()
		{
            this.Nif = null;
            this.Nombre = null;
            this.Correo = null;
            this.Telefono = null;
        }

		public ENUsuarioRestaurante(string nif, string nombre, string correo, string telefono)
        {
            this.Nif = nif;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Telefono = telefono;
        }

        public bool Create()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            bool create = usu.Create(this);
        }

        public bool Update()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            bool update = usu.Update(this);
        }

        public bool Delete()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            bool delete = usu.Delete(this);
        }

        public bool Read()
        {
            CADUsuarioRestaurante lin = new CADUsuarioRestaurante();
            bool read = usu.Read(this);
        }
    }
}

