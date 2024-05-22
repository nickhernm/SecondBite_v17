using System;
using System.Collections.Generic;

namespace library
{
	public class ENLinea
	{
        public int linea { get; set; }

        public int pedido { get; set; }

        public float importe { get; set; }

        public float cantidad { get; set; }

        public int platoId { get; set; }

        public ENPlato plato { get; set; }

        public ENLinea()
		{
            this.linea = 0;
            this.pedido = 0;
            this.importe = 0;
            this.cantidad = 0;
            this.platoId = 0;
		}

        public ENLinea(int linea, int pedido, int importe, int cantidad, int platoId)
        {
            this.linea = 0;
            this.pedido = 0;
            this.importe = 0;
            this.cantidad = 0;
            this.platoId = 0;
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

        internal void Add(ENLinea linea)
        {
            throw new NotImplementedException();

        }
    }
}
