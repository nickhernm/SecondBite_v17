using System;

namespace library { 

	public class ENCategorias
	{
		public int Id { get; set; }
		public string Nombre { get; set; }
		public string Descripcion { get; set; }
		public int Valoracion { get; set; }

		public ENCategorias()
		{

		}

		public ENCategorias(int id, string nombre, string desc, int valoracion)
        {
			this.Id = id;
			this.Nombre = nombre;
			this.Descripcion = desc;
			this.Valoracion = valoracion;
        }

        public bool Create()
        {
            CADCategorias cat = new CADCategorias();
            bool create = cat.Create(this);
            return create;
        }

        public bool Update()
        {
            CADCategorias cat = new CADCategorias();
            bool update = cat.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADCategorias cat = new CADCategorias();
            bool delete = cat.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADCategorias cat = new CADCategorias();
            bool read = cat.Read(this);
            return read;
        }
    }
}

