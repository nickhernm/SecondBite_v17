using System;

namespace library
{
    // Clase CADPlato
    public class CADPlato
    {
        private string connectionString;

        public CADPlato()
        {
            connectionString = ConfigurationManager.ConnectionStrings["Database"].ToString();
        }

        public bool Create(ENPlato en)
        {
            // Implementación del método Create
            return false;
        }

        public bool Read(ENPlato en)
        {
            // Implementación del método Read
            return false;
        }

        public bool Update(ENPlato en)
        {
            // Implementación del método Update
            return false;
        }

        public bool Delete(ENPlato en)
        {
            // Implementación del método Delete
            return false;
        }
    }
}