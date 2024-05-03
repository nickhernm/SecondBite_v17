using System;

namespace library
{
	public class ENLinea
	{
        public int Linea
        {
            get { return Linea; }
            set { Linea = value; }
        }

        public int Importe
        {
            get { return Importe; }
            set { Importe = value; }
        }

        public int Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }

		public ENLinea()
		{
            this.Linea = 0;
            this.Importe = 0;
            this.Cantidad = 0;
		}

        public ENLinea(int linea, int importe, int cantidad)
        {
            this.Linea = linea;
            this.Importe = importe;
            this.Cantidad = cantidad;
        }

        public bool Create()
        {
            CADLinea lin = new CADLinea();
            bool create = lin.Create(this);
            return create;
        }

        public bool Update()
        {
            CADLinea lin = new CADLinea();
            bool update = lin.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADLinea lin = new CADLinea();
            bool delete = lin.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADLinea lin = new CADLinea();
            bool read = lin.Read(this);
            return read;
        }
    }
}
