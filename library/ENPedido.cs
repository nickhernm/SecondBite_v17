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
            this.numPedido = null;
        }

        public ENPedido(int num)
        {
            this.numPedido = num;
        }

        public bool Create()
        {

        }

        public bool Update()
        {

        }

        public bool Delete()
        {

        }

        public bool Rate()
        {

        }
    }
}




