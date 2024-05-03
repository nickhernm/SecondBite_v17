using System;

namespace library
{

    public class ENPlato
<<<<<<< HEAD
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Alergenos { get; set; }
        public ENPlato()
        {

        }
        public bool Create()
        {
            CADPlato pla = new CADPlato();
            bool create = pla.Create(this);
            return create;
        }

        public bool Update()
        {
            CADPlato pla = new CADPlato();
            bool update = pla.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADPlato pla = new CADPlato();
            bool delete = pla.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADPlato pla = new CADPlato();
            bool read = pla.Read(this);
            return read;
        }
=======
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
   
>>>>>>> BK5734575
    }
}
