using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENOpinionPlato
    {
        public int IdPlato { get; set; }
        public int IdOpinion { get; set; }
        public List<ENOpinion> listaOpiniones { get; set; }

        public ENOpinionPlato()
        {

        }

        public ENOpinionPlato(int idPlato, int idOpinion)
        {
            this.IdPlato = idPlato;
            this.IdOpinion = idOpinion;
        }

        public bool Create()
        {
            CADOpinionPlato op = new CADOpinionPlato();
            bool create = op.Create(this);
            return create;
        }

        public bool Update()
        {
            CADOpinionPlato op = new CADOpinionPlato();
            bool update = op.Update(this);
            return update;
        }

        public bool Delete()
        {
            CADOpinionPlato op = new CADOpinionPlato();
            bool delete = op.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADOpinionPlato op = new CADOpinionPlato();
            bool read = op.Read(this);
            return read;
        }


        public List<ENOpinion> ReadAll(ENPlato en)
        {
            CADOpinionPlato op = new CADOpinionPlato();
            return op.ReadAll(en);
        }
    }
}

