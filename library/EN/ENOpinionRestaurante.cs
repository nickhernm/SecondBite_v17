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
    public class ENOpinionRestaurante
    {
        public int cod_restaurante { get; set; }
        public int id_opion { get; set; }
        

        // Constructor vacío
        public ENOpinionRestaurante() { }

        public bool Create()
        {
            CADOpinionRestaurante dir = new CADOpinionRestaurante();
            bool create = dir.Create(this);
            return create;
        }

        public bool Update()
        {
            CADOpinionRestaurante dir = new CADOpinionRestaurante();
            bool update = dir.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADOpinionRestaurante dir = new CADOpinionRestaurante();
            bool delete = dir.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADDireccCADOpinionRestauranteion dir = new CADCADOpinionRestauranteireccion();
            bool read = dir.Read(this);
            return read;
        }

    }
}
