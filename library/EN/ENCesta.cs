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

namespace library
{
    public class ENCesta
    {
        public int Id { get; set; } // Arreglar tipo de datos Cliente y Plato
        //public Cliente cliente { get; set; } // Relación con Cliente
        //public List<Plato> Platos { get; set; } // Relación con Platos
        public int? NumPedido { get; set; }
        public ENCesta()
        {

        }

        public bool Create()
        {
            CADCesta ces = new CADCesta();
            bool create = ces.Create(this);
            return create;
        }

        public bool Update()
        {
            CADCesta ces = new CADCesta();
            bool update = ces.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADCesta ces = new CADCesta();
            bool delete = ces.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADCesta ces = new CADCesta();
            bool read = ces.Read(this);
            return read;
        }
    }
}
