using System;

namespace library
{
    public class ENPedido
    {
        private int numPedido;

        /*
            Hablar con el grupo para ver como mejorar el 
            pedido/linea de pedido
         */

        public int NumPedido
        {
            get { return numPedido; }
            set { numPedido = value; }
        }

        public ENPedido()
        {
            this.numPedido = 0;
        }

        public ENPedido(int num)
        {
            this.numPedido = num;
        }

        public bool Create()
        {
            CADPedido ped = new CADPedido();
            bool create = ped.Create(this);
            return create;
        }

        public bool Update()
        {
            CADPedido ped = new CADPedido();
            bool update = ped.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADPedido ped = new CADPedido();
            bool delete = ped.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADPedido ped = new CADPedido();
            bool read = ped.Read(this);
            return read;
        }
    }
}




