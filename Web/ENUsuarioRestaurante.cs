using System;

namespace Web
{
    internal class ENUsuarioRestaurante
    {
        private string email;
        private string name;
        private string telefono;
        private bool tipo_usuario;
        private string contrasena;

        public ENUsuarioRestaurante(string email, string name, string telefono, bool tipo_usuario, string contrasena)
        {
            this.email = email;
            this.name = name;
            this.telefono = telefono;
            this.tipo_usuario = tipo_usuario;
            this.contrasena = contrasena;
        }

        internal bool Create()
        {
            throw new NotImplementedException();
        }
    }
}