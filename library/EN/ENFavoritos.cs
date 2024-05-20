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

namespace library {
    public class ENFavoritos
    {
        public int id { get; set; } // Arreglar tipo de dato Cliente y Plato
        public ENUsuarioRestaurante usuario { get; set; } // Relación con Cliente
        public List<ENPlato> Platos { get; set; } // Relación con Plato
        public ENFavoritos()
	    {

	    }

        public bool Create()
        {
            CADFavoritos lin = new CADFavoritos();
            bool create = lin.Create(this);
            return create;
        }

        public bool Update()
        {
            CADFavoritos lin = new CADFavoritos();
            bool update = lin.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADFavoritos lin = new CADFavoritos();
            bool delete = lin.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADFavoritos lin = new CADFavoritos();
            bool read = lin.Read(this);
            return read;
        }

        public List<ENFavoritos> ReadAll()
        {
            CADFavoritos fav = new CADFavoritos();
            return fav.ReadAll();
        }
    }
}
