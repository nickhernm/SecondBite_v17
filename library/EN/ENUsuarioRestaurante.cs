using System;

namespace library
{
    public class ENUsuarioRestaurante
    {
        public string Nif { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Telefono { get; set; }

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

        public ENUsuarioRestaurante(string telefono, string nombre)
        {
            this.Telefono = telefono;
            this.Nombre = nombre;
        }

        public bool Create()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            bool create = usu.Create(this);
            return create;
        }

        public bool Update()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            bool update = usu.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            bool delete = usu.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            bool read = usu.Read(this);
            return read;
        }

        public bool CheckUser()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            bool read = usu.CheckUser(this);
            return read;
        }
    }
}

