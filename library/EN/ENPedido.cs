using System;
using System.Collections.Generic;

namespace library
{
    public class ENPedido
    {

        public int numPedido { get; set; }

        public string fechaPedido { get; set; }

        public string emailPedido { get; set; }

        public List<ENLinea> lineasPedido { get; set; }

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

        public List<ENPedido> ReadAll()
        {
            CADPedido ped = new CADPedido();
            return ped.ReadAll();
        }


        public List<ENPedido> ReadpedidosUsu(string value)
        {
            CADPedido ped = new CADPedido();
            return ped.ReadAllUser(value);
        }
    }
}




