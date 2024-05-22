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

<<<<<<< HEAD
        public int Cantidad
        {
            get { return Cantidad; }
            set { Cantidad = value; }
        }
        public int NumPed
        {
            get { return NumPed; }
            set { NumPed = value; }
        }
        public string Plato
        {
            get { return Plato; }
            set { Plato = value; }
        }
=======
>>>>>>> 3784e0f9a5a284fb2dadee21a13f5465d9ff2d5f

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
<<<<<<< HEAD

        internal void Add(ENLinea linea)
        {
            throw new NotImplementedException();
=======
        
        public List<ENLinea> ReadAllPed()
        {
            CADLinea lin = new CADLinea();
            return lin.ReadAllPed(this);
>>>>>>> 3784e0f9a5a284fb2dadee21a13f5465d9ff2d5f
        }
    }
}
