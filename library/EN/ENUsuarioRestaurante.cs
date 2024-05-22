using System;

namespace library
{
    public class ENUsuarioRestaurante
    {
        public string Correo { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public bool Tipo_usuario { get; set; }

        public string Metodo_pago { get; set; }

        public string Contrasena { get; set; }

        public ENUsuarioRestaurante()
        {
            this.Correo = null;
            this.Nombre = null;
            this.Telefono = null;
            this.Tipo_usuario = false;
            this.Metodo_pago = null;
            this.Contrasena = null;
        }

        public ENUsuarioRestaurante(string correo, string nombre, string telefono, bool tipo_usuario, string metodo_pago, string contrasena)
        {
            this.Correo = correo;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Tipo_usuario = tipo_usuario;
            this.Metodo_pago = metodo_pago;
            this.Contrasena = contrasena;
        }

        public ENUsuarioRestaurante(string correo, string nombre, string telefono, bool tipo_usuario, string contrasena)
        {
            this.Correo = correo;
            this.Nombre = nombre;
            this.Telefono = telefono;
            this.Tipo_usuario = tipo_usuario;
            this.Contrasena = contrasena;
            System.Diagnostics.Debug.WriteLine("dest?: ", tipo_usuario);
        }

        public ENUsuarioRestaurante(string contrasena, string nombre)
        {
            this.Contrasena = contrasena;
            this.Nombre = nombre;
        }

        public bool Create()
        {
            CADUsuarioRestaurante usu = new CADUsuarioRestaurante();
            System.Diagnostics.Debug.WriteLine("Rest?: ", Tipo_usuario);
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

