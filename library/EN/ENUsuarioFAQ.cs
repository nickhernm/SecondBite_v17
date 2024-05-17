using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.EN
{
    public class ENUsuarioFAQ
    {
        public int Id { get; set; }
        public string IdUsuario { get; set; }
        public int IdFaq { get; set; }

        public ENUsuarioFAQ() { }

        public ENUsuarioFAQ(int id, string idUsuario, int idFaq)
        {
            this.Id = id;
            this.IdUsuario = idUsuario;
            this.IdFaq = idFaq;
        }

        public bool Create()
        {
            CADUsuarioFAQ cad = new CADUsuarioFAQ();
            return cad.Create(this);
        }

        public bool Read()
        {
            CADUsuarioFAQ cad = new CADUsuarioFAQ();
            return cad.Read(this);
        }

        public bool Update()
        {
            CADUsuarioFAQ cad = new CADUsuarioFAQ();
            return cad.Update(this);
        }

        public bool Delete()
        {
            CADUsuarioFAQ cad = new CADUsuarioFAQ();
            return cad.Delete(this);
        }
    }
}
