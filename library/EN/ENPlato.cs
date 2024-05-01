using System;

namespace library
{

    public class ENPlato
    {       
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Alergenos { get; set; }

        // Constructor
        public ENPlato(int id, string nombre, string alergenos)
        {
            Id = id;
            Nombre = nombre;
            Alergenos = alergenos;
        }
   
    }
}
