using System;

namespace library
{

    public class CADCategoria
{
    private string connectionString;

    public CADCategoria()
    {
        connectionString = ConfigurationManager.ConnectionStrings["Database"].ToString();
    }

    public bool Create(ENCategoria en)
    {
        // Implementación del método Create
        return false;
    }

    public bool Read(ENCategoria en)
    {
        // Implementación del método Read
        return false;
    }

    public bool Update(ENCategoria en)
    {
        // Implementación del método Update
        return false;
    }

    public bool Delete(ENCategoria en)
    {
        // Implementación del método Delete
        return false;
    }
}
}