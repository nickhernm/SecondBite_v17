using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENMenu
    {
        public int RestauranteId { get; set; }
        public int PlatoId { get; set; }

        public ENMenu()
        {

        }

        public bool Create()
        {
            CADMenu menu = new CADMenu();
            bool create = menu.Create(this);
            return create;
        }

        public bool Delete()
        {
            CADMenu menu = new CADMenu();
            bool delete = menu.Delete(this);
            return delete;
        }

        public bool Read()
        {
            CADMenu menu = new CADMenu();
            bool read = menu.Read(this);
            return read;
        }
    }
}
