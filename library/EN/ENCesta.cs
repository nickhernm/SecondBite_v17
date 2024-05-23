using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;
using System.Configuration;
using library;
using library.library;

namespace library
{
    public class ENCesta
    {
        public int Id { get; set; }
        public int? NumPedido { get; set; }

        public ENCesta()
        {
        }

        public ENCesta(int id, int? numPedido)
        {
            Id = id;
            NumPedido = numPedido;
        }

        public bool Create()
        {
            CADCesta cad = new CADCesta();
            return cad.Create(this);
        }

        public bool Update()
        {
            CADCesta cad = new CADCesta();
            return cad.Update(this);
        }

        public bool Delete()
        {
            CADCesta cad = new CADCesta();
            return cad.Delete(this);
        }

        public bool Read()
        {
            CADCesta cad = new CADCesta();
            return cad.Read(this);
        }
    }
}

